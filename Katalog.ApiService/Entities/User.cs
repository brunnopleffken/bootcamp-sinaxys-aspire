using Microsoft.AspNetCore.Identity;

namespace Katalog.ApiService.Entities;

public class User : IdentityUser<int>
{
    public DateOnly? BirthDate { get; set; }

    public required string Cpf
    {
        get => field;
        set => field = value.Replace(".", "").Replace("-", "");
    }
}
