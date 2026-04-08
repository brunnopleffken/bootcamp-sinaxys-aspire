using Katalog.ApiService.Entities.Enums;

namespace Katalog.ApiService.Entities;

public class Movie
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public required string CoverImage { get; set; }
    public TimeOnly Duration { get; set; }
    public Rating Rating { get; set; }
    public decimal VoteAverage { get; set; }
    public required string Director { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // FK de gênero de filme
    public required Genre Genre { get; set; }

    public ICollection<Review> Reviews { get; set; } = [];
}
