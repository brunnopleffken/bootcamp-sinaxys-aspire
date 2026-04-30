using Katalog.ApiService.Data;
using Katalog.ApiService.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Katalog.ApiService.Features.Genres;

public class GenresController(ApplicationDbContext context) : ApplicationController
{
    public async Task<ActionResult<List<Genre>>> Index()
    {
        List<Genre> genres = await context.Genres
            .OrderBy(g => g.Name)
            .ToListAsync();

        return genres;
    }
}
