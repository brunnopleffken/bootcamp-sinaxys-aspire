using System.Security.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Katalog.ApiService.Features;

[ApiController]
[Route("[controller]")]
public class ApplicationController : ControllerBase
{
    // Equivalente a "protected int UserId { get => return int.TryParse(...); }"
    protected int UserId => int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int id)
        ? id
        : throw new AuthenticationException();

    // Equivalente a "protected string? UserEmail { get => return User.FindFirst(...); }"
    protected string? UserEmail => User.FindFirst(ClaimTypes.Email)?.Value;
}
