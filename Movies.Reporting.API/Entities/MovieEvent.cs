namespace Movies.Reporting.API.Entities;

public class MovieEvent
{
    public Guid Id { get; set; }

    public Guid MovieId { get; set; }

    public MovieEventType EventType { get; set; }

    public DateTime CreatedOnUtc { get; set; }
}
