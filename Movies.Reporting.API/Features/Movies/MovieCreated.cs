using MassTransit;
using Movies.Contracts;
using Movies.Reporting.API.Database;
using Movies.Reporting.API.Entities;

namespace Movies.Reporting.API.Features.Movies
{
    public sealed class MovieCreatedConsumer : IConsumer<MovieCreatedEvent>
    {
        private readonly ApplicationDbContext _dbContext;

        public MovieCreatedConsumer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Consume(ConsumeContext<MovieCreatedEvent> context)
        {
            var movie = new Movie
            {
                Id = context.Message.Id,
                CreatedOnUtc = context.Message.CreatedOnUtc
            };

            _dbContext.Add(movie);

            await _dbContext.SaveChangesAsync();
        }
    }
}
