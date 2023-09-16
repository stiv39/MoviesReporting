using FluentValidation;
using Movies.API.Entities;
using MediatR;
using Movies.API.Database;

namespace Movies.API.Features.Movies;

public static class CreateMovie
{
    public class Command : IRequest<CreateMovieResult>
    {
        public Command(string title, string genre, int year)
        {
            Title = title;
            Genre = genre;
            Year = year;
        }

        public string Title { get; set; } = string.Empty;

        public string Genre { get; set; } = string.Empty;

        public int Year { get; set; }

    }

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(m => m.Title).NotEmpty();
            RuleFor(m => m.Genre).NotEmpty();
            RuleFor(m => m.Year).NotEmpty();
        }
    }

    internal sealed class Handler : IRequestHandler<Command, CreateMovieResult>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IValidator<Command> _validator;

        public Handler(ApplicationDbContext dbContext, IValidator<Command> validator)
        {
            _dbContext = dbContext;
            _validator = validator;
        }

        public async Task<CreateMovieResult> Handle(Command request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);

            if(!validationResult.IsValid)
            {
                return new CreateMovieResult(false, null);
            }

            var movieId = Guid.NewGuid();
            var movieToAdd = new Movie
            {
                AddedOnUtc = DateTime.UtcNow,
                Genre = request.Genre,
                Year = request.Year,
                Title = request.Title,
                Id = movieId,
            }; 

            await _dbContext.Movies.AddAsync(movieToAdd);
            await _dbContext.SaveChangesAsync();

            return new CreateMovieResult(true, movieId);
        }
    }
}
