using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Katalog.ApiService.Services;

public class AuthTokenService(string email)
{
    public string GenerateToken()
    {
        List<Claim> claims =
        [
            new Claim(ClaimTypes.Email, email)
        ];

        SymmetricSecurityKey key = new (Encoding.UTF8.GetBytes("9mykGvSAdJSHnYtUNophaRBGdNoEkOac"));
        SigningCredentials credentials = new (key, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken jwt = new JwtSecurityToken(
            issuer: "Katalog",
            audience: "KatalogApp",
            claims: claims,
            expires: DateTime.Now.AddHours(12),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}
