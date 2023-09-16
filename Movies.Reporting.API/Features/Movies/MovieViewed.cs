using MassTransit;
using Microsoft.EntityFrameworkCore;
using Movies.Contracts;
using Movies.Reporting.API.Database;
using Movies.Reporting.API.Entities;

namespace Movies.Reporting.API.Features.Movies;

public sealed class MovieViewedConsumer : IConsumer<MovieViewedEvent>
{
    private readonly ApplicationDbContext _dbContext;

    public MovieViewedConsumer(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Consume(ConsumeContext<MovieViewedEvent> context)
    {
        var movie = await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == context.Message.Id);

        if (movie == null)
        {
            return;
        }

        var movieEvent = new MovieEvent
        {
            Id = Guid.NewGuid(),
            MovieId = movie.Id,
            CreatedOnUtc = context.Message.ViewedOnUtc,
            EventType = MovieEventType.View
        };

        _dbContext.Add(movieEvent);

        await _dbContext.SaveChangesAsync();
    }
}
