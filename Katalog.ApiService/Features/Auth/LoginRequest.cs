using System.ComponentModel.DataAnnotations;

namespace Katalog.ApiService.Features.Auth;

public record LoginRequest(
    [Required]
    [EmailAddress]
    string Email,

    [Required]
    string Password);
