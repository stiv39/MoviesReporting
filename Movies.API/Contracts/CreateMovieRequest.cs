namespace Movies.API.Contracts;

public class CreateMovieRequest
{
    public string Title { get; set; } = string.Empty;

    public string Genre { get; set; } = string.Empty;

    public int Year { get; set; }
}
