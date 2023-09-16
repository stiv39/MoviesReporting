namespace Movies.Reporting.API.Features.Movies;

public class MovieResponse
{
    public bool IsSuccess { get; set; }
    public Guid Id { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public List<MovieEventResponse> Events { get; set; } = new();
}
