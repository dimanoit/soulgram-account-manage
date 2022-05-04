using MediatR;
using Soulgram.AccountManage.Application.Queries;
using Soulgram.AccountManage.Application.Services;
using Soulgram.AccountManage.Domain.Entities;
using Soulgram.AccountManage.Persistence;

namespace Soulgram.AccountManage.Application.Commands;

public class UpdateGenreListCommand : IRequest
{
}

public class UpdateGenreListCommandHandler : IRequestHandler<UpdateGenreListCommand>
{
    private readonly SoulgramContext _dbContext;
    private readonly IMediator _mediator;
    private readonly IMovieSearchService _movieSearchService;

    public UpdateGenreListCommandHandler(
        SoulgramContext dbContext,
        IMovieSearchService movieSearchService,
        IMediator mediator)
    {
        _dbContext = dbContext;
        _movieSearchService = movieSearchService;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(UpdateGenreListCommand request, CancellationToken cancellationToken)
    {
        var genres = await _movieSearchService.GetGenresAsync(cancellationToken);
        if (genres == null || genres.Count == 0)
        {
            return Unit.Value;
        }

        var dbGenres = await _mediator.Send(new GetGenresQuery(), cancellationToken);

        var newDbGenres = GetNewDbGenres(genres, dbGenres);

        _dbContext.Genres.AddRange(newDbGenres);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }

    private static List<Genre> GetNewDbGenres(
        ICollection<string> genres,
        ICollection<string>? dbGenres)
    {
        var newDbGenres = new List<Genre>();
        foreach (var serviceGenre in genres)
        {
            if (dbGenres != null && dbGenres.Contains(serviceGenre))
            {
                continue;
            }

            var newGenre = new Genre
            {
                Name = serviceGenre
            };

            newDbGenres.Add(newGenre);
        }

        return newDbGenres;
    }
}