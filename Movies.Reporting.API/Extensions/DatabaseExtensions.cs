using Microsoft.EntityFrameworkCore;
using Movies.Reporting.API.Database;

namespace Movies.Reporting.API.Extensions;

public static class DatabaseExtensions
{
    public static void ApplyMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        dbContext.Database.Migrate();
    }
}
