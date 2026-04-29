using Katalog.ApiService.Data;
using Katalog.ApiService.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Katalog.ApiService.Features.Movies;

// /movies
public class MoviesController(ApplicationDbContext context) : ApplicationController
{
    [HttpGet] // GET /movies
    public async Task<ActionResult<List<MoviesResponse>>> Index()
    {
        List<MoviesResponse> movies = await context.Movies
            .Select(m => new MoviesResponse(m))
            .ToListAsync();

        return movies;
    }

    [HttpGet("{id:int}")] // GET /movies/{id}
    public async Task<ActionResult<MovieResponse>> GetById(int id)
    {
        MovieResponse? movie = await context.Movies
            .Where(m => m.Id == id)
            .Select(m => new MovieResponse(m))
            .FirstOrDefaultAsync();

        if (movie is null)
            return NotFound();

        return movie;
    }

    [HttpPost] // POST /movies
    public async Task<ActionResult> New(MovieRequest movieRequest)
    {
        Movie movie = new Movie()
        {
            Title = movieRequest.Title,
            Description = movieRequest.Description,
            ReleaseDate = movieRequest.ReleaseDate,
            Rating = movieRequest.Rating,
            Duration = movieRequest.Duration,
            Director = movieRequest.Director,
            Genre = movieRequest.Genre,
            VoteAverage = 0.0m,
            CoverImage = "https://placehold.co/600x400/EEE/31343C"
        };

        context.Movies.Add(movie);
        await context.SaveChangesAsync();

        return Created();
    }
}
