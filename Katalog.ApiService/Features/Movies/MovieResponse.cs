using Katalog.ApiService.Entities;
using Katalog.ApiService.Entities.Enums;

namespace Katalog.ApiService.Features.Movies;

public record MovieResponse
{
    public int Id { get; init; }
    public string Title { get; init; }
    public string? Description { get; init; }
    public DateOnly ReleaseDate { get; init; }
    public string? CoverImage { get; init; }
    public TimeOnly Duration { get; init; }
    public Rating Rating { get; init; }
    public decimal? VoteAverage { get; init; }
    public string? Director { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }

    public MovieResponse(Movie m)
    {
        Id = m.Id;
        Title = m.Title;
        Description = m.Description;
        ReleaseDate = m.ReleaseDate;
        CoverImage = m.CoverImage;
        Duration = m.Duration;
        Rating = m.Rating;
        VoteAverage = m.VoteAverage;
        Director = m.Director;
        CreatedAt = m.CreatedAt;
        UpdatedAt = m.UpdatedAt;
    }
}
