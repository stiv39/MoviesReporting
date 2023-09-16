namespace Movies.Contracts;

public record MovieViewedEvent
{
    public Guid Id { get; set; }
    public DateTime ViewedOnUtc { get; set; }
}
