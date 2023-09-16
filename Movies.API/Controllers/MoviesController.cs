using Microsoft.AspNetCore.Mvc;

namespace Movies.API.Controllers;

[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateMovie()
    {
        return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult GetMovie(Guid id)
    {
        return Ok();
    }
}
