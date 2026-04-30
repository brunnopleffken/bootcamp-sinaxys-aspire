using Katalog.ApiService.Data;
using Katalog.ApiService.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Katalog.ApiService.Features.Reviews;

public class ReviewsController(ApplicationDbContext context) : ApplicationController
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<ReviewResponse>>> GetById(int id)
    {
        Movie? movie = await context.Movies.FirstOrDefaultAsync(m => m.Id == id);

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
}
