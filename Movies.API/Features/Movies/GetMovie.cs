using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Movies.API.Database;
using Movies.Contracts;

namespace Movies.API.Features.Movies;

public static class GetMovie
{
    public class Query : IRequest<GetMovieResult>
    {
        public Query(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }

    internal sealed class Handler : IRequestHandler<Query, GetMovieResult>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IPublishEndpoint _publishEndpoint;
        public Handler(ApplicationDbContext dbContext, IPublishEndpoint publishEndpoint)
        {
            _dbContext = dbContext;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<GetMovieResult> Handle(Query request, CancellationToken cancellationToken)
        {
           var movieFromDb = await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == request.Id);

            if(movieFromDb == null)
            {
                return new GetMovieResult(false, null);
            }

            await _publishEndpoint.Publish(new MovieViewedEvent
            {
                Id = movieFromDb.Id,
                ViewedOnUtc = DateTime.UtcNow,
            });

            return new GetMovieResult(true, movieFromDb);
        }
    }
}
