using Microsoft.EntityFrameworkCore;

namespace Katalog.ApiService.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    // Tabelas (DbSet)

    // Fluent API
}
