using System.ComponentModel.DataAnnotations;

namespace Katalog.ApiService.Features.Signup;

public record SignupRequest(
    [Required, EmailAddress]
    string Email,

    [Required, MinLength(8)]
    string Password,

    DateOnly? BirthDate,

    [Required, Length(11,15)]
    string Cpf);
