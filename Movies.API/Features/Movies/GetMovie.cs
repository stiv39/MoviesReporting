using MediatR;
using Microsoft.EntityFrameworkCore;
using Movies.API.Database;

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

        public Handler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetMovieResult> Handle(Query request, CancellationToken cancellationToken)
        {
           var movieFromDb = await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == request.Id);

            if(movieFromDb == null)
            {
                return new GetMovieResult(false, null);
            }

            return new GetMovieResult(true, movieFromDb);
        }
    }
}
