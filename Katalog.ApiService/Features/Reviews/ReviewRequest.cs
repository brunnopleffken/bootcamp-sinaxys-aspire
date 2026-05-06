using System.ComponentModel.DataAnnotations;

namespace Katalog.ApiService.Features.Reviews;

public record ReviewRequest(
    [Required]
    string Comment,

    [Required]
    [Range(0, 5)]
    byte Rating);
