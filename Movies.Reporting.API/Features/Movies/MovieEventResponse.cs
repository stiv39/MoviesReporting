using Movies.Reporting.API.Entities;

namespace Movies.Reporting.API.Features.Movies;

public class MovieEventResponse
{
    public Guid Id { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public MovieEventType EventType { get; set; }
}
