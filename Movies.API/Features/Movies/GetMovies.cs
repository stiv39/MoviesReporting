using MediatR;
using Microsoft.EntityFrameworkCore;
using Movies.API.Database;
using Movies.API.Entities;

namespace Movies.API.Features.Movies;

public static class GetMovies
{
    public class Query : IRequest<List<Movie>> { }

    internal sealed class Handler : IRequestHandler<Query, List<Movie>>
    {
        private readonly ApplicationDbContext _dbContext;

        public Handler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Movie>> Handle(Query request, CancellationToken cancellationToken)
        {
            var movies = await _dbContext.Movies.ToListAsync(cancellationToken);

            return movies;
        }
    }
}
