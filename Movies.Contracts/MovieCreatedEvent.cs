namespace Movies.Contracts;

public record MovieCreatedEvent
{
    public Guid Id { get; set; }
    public DateTime CreatedOnUtc { get; set; }
}