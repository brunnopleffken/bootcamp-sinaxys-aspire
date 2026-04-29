using System.ComponentModel.DataAnnotations;
using Katalog.ApiService.Entities;
using Katalog.ApiService.Entities.Enums;

namespace Katalog.ApiService.Features.Movies;

public record MovieRequest(
    [Required]
    [MaxLength(100)]
    string Title,

    [Required]
    [MaxLength(2000)]
    string Description,

    [Required]
    DateOnly ReleaseDate,

    [Required]
    Rating Rating,

    [Required]
    TimeOnly Duration,

    [Required]
    [MaxLength(100)]
    string Director,

    [Required]
    Genre Genre);
