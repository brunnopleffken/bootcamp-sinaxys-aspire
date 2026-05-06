using System.Security.Authentication;
using System.Security.Claims;
using Katalog.ApiService.Data;
using Katalog.ApiService.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Katalog.ApiService.Features.Reviews;

public class ReviewsController(ApplicationDbContext context) : ApplicationController
{
    [HttpGet("{movieId:int}")] // GET /reviews/{movieId}
    public async Task<ActionResult<List<ReviewResponse>>> GetByMovieId(int movieId)
    {
        Movie? movie = await context.Movies.FirstOrDefaultAsync(m => m.Id == movieId);

        if (movie is null)
            return NotFound();

        List<ReviewResponse> reviews = await context.Reviews
            .Where(r => r.Movie == movie)
            .Select(r => new ReviewResponse(
                Id: r.Id,
                Comment: r.Comment,
                Rating: r.Rating,
                CreatedAt: r.CreatedAt,
                User: new ReviewUserResponse(r.User.UserName ?? "Anônimo")))
            .ToListAsync();

        return reviews;
    }

    [Authorize]
    [HttpPost("{movieId:int}")] // POST /reviews/{movieId}
    public async Task<ActionResult> Create(int movieId, ReviewRequest reviewRequest)
    {
        // Obtém entidade User para associar ao review
        User? user = await context.Users
            .FirstOrDefaultAsync(u => u.Id == UserId); // Esse UserId vem do ApplicationController

        if (user is null)
            return Unauthorized();

        // Obtém a entidade Movie para associar ao review
        Movie? movie = await context.Movies
            .FirstOrDefaultAsync(m => m.Id == movieId);

        if (movie is null)
            return BadRequest("Movie not found");

        // Agora sim, finalmente, bora criar o objeto Review
        Review review = new Review()
        {
            Comment = reviewRequest.Comment,
            Rating = reviewRequest.Rating,
            Movie = movie,
            User = user
        };

        context.Reviews.Add(review);
        await context.SaveChangesAsync();

        return Created();
    }
}
