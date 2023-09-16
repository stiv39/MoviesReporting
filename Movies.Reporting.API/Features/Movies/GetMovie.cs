using MediatR;
using Microsoft.EntityFrameworkCore;
using Movies.Reporting.API.Database;

namespace Movies.Reporting.API.Features.Movies;

public static class GetMovie
{
    public class Query : IRequest<MovieResponse>
    {
        public Query(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }

    internal sealed class Handler : IRequestHandler<Query, MovieResponse>
    {
        private readonly ApplicationDbContext _dbContext;

        public Handler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MovieResponse> Handle(Query request, CancellationToken cancellationToken)
        {
            var movieResponse = await _dbContext
                .Movies
                .AsNoTracking()
                .Where(movie => movie.Id == request.Id)
                .Select(movie => new MovieResponse
                {
                    Id = movie.Id,
                    CreatedOnUtc = movie.CreatedOnUtc,
                    Events = _dbContext.MovieEvents
                                            .Where(movieEvent => movieEvent.Id == movie.Id)
                                            .Select(movieEvent => new MovieEventResponse
                                            {
                                                Id = movieEvent.Id,
                                                EventType = movieEvent.EventType,
                                                CreatedOnUtc = movieEvent.CreatedOnUtc
                                            }).ToList()
                })
                .FirstOrDefaultAsync();

            if(movieResponse is null)
            {
                return new MovieResponse { IsSuccess = false };
            }

            movieResponse.IsSuccess = true;
            return movieResponse;
        }
    }
}
