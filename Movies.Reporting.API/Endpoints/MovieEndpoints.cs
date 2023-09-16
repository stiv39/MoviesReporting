using Carter;
using MediatR;
using Movies.Reporting.API.Features.Movies;

namespace Movies.Reporting.API.Endpoints;

public class MovieEndpoints : ICarterModule
{
    private const string _moviesGroupPrefix = "api/movies";
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(_moviesGroupPrefix);

        group.MapGet("{id}", GetMovie);
    }

    public static async Task<IResult> GetMovie(Guid id, ISender sender)
    {
        var result = await sender.Send(new GetMovie.Query(id));

        if(!result.IsSuccess)
        {
            return Results.NotFound();
        }

        return Results.Ok(result);
    }
}
