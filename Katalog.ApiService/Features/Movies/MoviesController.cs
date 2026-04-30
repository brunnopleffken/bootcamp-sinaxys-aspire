using Katalog.ApiService.Data;
using Katalog.ApiService.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Katalog.ApiService.Features.Movies;

// /movies
public class MoviesController(ApplicationDbContext context) : ApplicationController
{
    [HttpGet] // GET /movies
    public async Task<ActionResult<MoviesIndexResponse>> Index()
    {
        List<MoviesResponse> movies = await context.Movies
            .Select(m => new MoviesResponse(m))
            .ToListAsync();

        MoviesIndexResponse response = new MoviesIndexResponse(movies, movies.Count);

        return response;
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
        Genre? genre = context.Genres.FirstOrDefault(g => g.Id == movieRequest.Genre);

        if (genre is null)
            return BadRequest("Gênero de filme não encontrado");

        Movie movie = new Movie()
        {
            Title = movieRequest.Title,
            Description = movieRequest.Description,
            ReleaseDate = movieRequest.ReleaseDate,
            Rating = movieRequest.Rating,
            Duration = movieRequest.Duration,
            Director = movieRequest.Director,
            Genre = genre,
            VoteAverage = 0.0m,
            CoverImage = "https://placehold.co/600x400/EEE/31343C"
        };

        context.Movies.Add(movie);
        await context.SaveChangesAsync();

        return Created();
    }
}
