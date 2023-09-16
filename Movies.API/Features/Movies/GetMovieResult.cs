using Movies.API.Entities;

namespace Movies.API.Features.Movies;

public class GetMovieResult
{
    public GetMovieResult(bool isSuccess, Movie? movie)
    {
        IsSuccess= isSuccess;
        Movie = movie;
    }

    public bool IsSuccess { get; set; }
    public Movie? Movie { get; set; }
}
