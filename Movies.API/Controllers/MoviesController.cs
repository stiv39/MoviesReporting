using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movies.API.Contracts;
using Movies.API.Features.Movies;

namespace Movies.API.Controllers;

[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly ISender _sender;

    public MoviesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMovie(CreateMovieRequest request)
    {
        var command = request.Adapt<CreateMovie.Command>();

        var result = await _sender.Send(command);

        if(!result.IsSuccess)
        {
            return BadRequest();
        }

        return Ok(result.Id);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMovie(Guid id)
    {
        var query = new GetMovie.Query(id);

        var result = await _sender.Send(query);

        if(!result.IsSuccess)
        {
            return NotFound();
        }

        return Ok(result?.Movie?.Adapt<MovieResponse>());
    }

    [HttpGet]
    public async Task<IActionResult> GetMovies()
    {
        var result = await _sender.Send(new GetMovies.Query());

        return Ok(result);
    }
}
