using Katalog.ApiService.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Katalog.ApiService.Features.Signup;

public class SignupController(UserManager<User> userManager) : ApplicationController
{
    [HttpPost]
    public async Task<IActionResult> CreateUser(SignupRequest signupRequest)
    {
        User user = new User()
        {
            UserName = signupRequest.Email,
            Email = signupRequest.Email,
            BirthDate = signupRequest.BirthDate,
            Cpf = signupRequest.Cpf
        };

        IdentityResult newUser = await userManager.CreateAsync(user, signupRequest.Password);

        if (!newUser.Succeeded)
        {
            return BadRequest();
        }

        return Created();
    }
}
