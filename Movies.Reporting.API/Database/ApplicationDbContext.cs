using Microsoft.EntityFrameworkCore;
using Movies.Reporting.API.Entities;

namespace Movies.Reporting.API.Database;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options)
	{
	}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MovieEvent>().HasOne<Movie>().WithMany();
    }

    public DbSet<Movie> Movies { get; set; }

    public DbSet<MovieEvent> MovieEvents { get; set; }
}
