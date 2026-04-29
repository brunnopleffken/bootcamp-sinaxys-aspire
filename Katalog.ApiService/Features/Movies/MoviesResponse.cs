using Katalog.ApiService.Entities;

namespace Katalog.ApiService.Features.Movies;

public record MoviesResponse
{
    public int Id { get; init; }
    public string Title { get; init; }
    public DateOnly ReleaseDate { get; init; }
    public string CoverImage { get; init; }
    public decimal VoteAverage { get; init; }

    public MoviesResponse(Movie m)
    {
        Id = m.Id;
        Title = m.Title;
        ReleaseDate = m.ReleaseDate;
        CoverImage = m.CoverImage;
        VoteAverage = m.VoteAverage;
    }
}
