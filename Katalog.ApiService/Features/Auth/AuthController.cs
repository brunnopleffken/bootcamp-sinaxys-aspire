using Katalog.ApiService.Entities;
using Katalog.ApiService.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Katalog.ApiService.Features.Auth;

public class AuthController(UserManager<User> userManager) : ApplicationController
{
    public async Task<IActionResult> Authenticate(LoginRequest loginRequest)
    {
        User? user = await userManager.FindByEmailAsync(loginRequest.Email);

        if (user is null || !await userManager.CheckPasswordAsync(user, loginRequest.Password))
        {
            return Unauthorized();
        }

        AuthTokenService tokenService = new AuthTokenService(user.Email!);
        string token = tokenService.GenerateToken();

        return Ok(new { Token = token });
    }
}
