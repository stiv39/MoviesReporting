namespace Movies.API.Contracts;

public class MovieResponse
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Genre { get; set; } = string.Empty;

    public int Year { get; set; }

    public DateTime AddedOnUtc { get; set; }
}
