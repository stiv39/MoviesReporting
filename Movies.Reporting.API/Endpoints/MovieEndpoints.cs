using Carter;

namespace Movies.Reporting.API.Endpoints;

public class MovieEndpoints : ICarterModule
{
    private const string _moviesGroupPrefix = "api/movies";
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(_moviesGroupPrefix);

        group.MapGet("", Get);
    }

    public static async Task<IResult> Get()
    {
        return Results.Ok();
    }
}
