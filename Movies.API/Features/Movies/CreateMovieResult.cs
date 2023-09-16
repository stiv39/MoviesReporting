namespace Movies.API.Features.Movies;

public class CreateMovieResult
{
    public CreateMovieResult(bool isSuccess, Guid? id)
    {
        IsSuccess = isSuccess;
        Id = id;
    }

    public bool IsSuccess { get; set; }
    public Guid? Id { get; set; }
}
