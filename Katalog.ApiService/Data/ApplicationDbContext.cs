using Katalog.ApiService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Katalog.ApiService.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>(e =>
        {
            e.Property(p => p.Name).HasMaxLength(30).IsRequired();
        });

        modelBuilder.Entity<Movie>(e =>
        {
            e.Property(p => p.Title).HasMaxLength(100).IsRequired();
            e.Property(p => p.Description).HasMaxLength(2000).IsRequired();
            e.Property(p => p.ReleaseDate).IsRequired();
            e.Property(p => p.CoverImage).HasMaxLength(200);
            e.Property(p => p.Rating).IsRequired();
            e.Property(p => p.VoteAverage).HasPrecision(2, 1);
            e.Property(p => p.Director).HasMaxLength(100);
            e.Property(p => p.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            e.Property(p => p.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<Review>(e =>
        {
            e.Property(p => p.Comment).HasMaxLength(2000);
            e.Property(p => p.Rating).IsRequired();
            e.Property(p => p.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<User>(e =>
        {
            e.Property(p => p.Cpf).IsRequired().HasMaxLength(11).IsFixedLength();
        });
    }
}
