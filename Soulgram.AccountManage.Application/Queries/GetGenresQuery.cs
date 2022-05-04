using MediatR;
using Microsoft.EntityFrameworkCore;
using Soulgram.AccountManage.Persistence;

namespace Soulgram.AccountManage.Application.Queries;

public class GetGenresQuery : IRequest<ICollection<string>?>
{
    public GetGenresQuery()
    {
    }

    public GetGenresQuery(string genreName)
    {
        GenreName = genreName;
    }

    public string? GenreName { get; }
}

public class GetGenresQueryHandler : IRequestHandler<GetGenresQuery, ICollection<string>?>
{
    private readonly SoulgramContext _dbContext;

    public GetGenresQueryHandler(SoulgramContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ICollection<string>?> Handle(GetGenresQuery request, CancellationToken cancellationToken)
    {
        var genresQuery = _dbContext
            .Genres
            .AsNoTracking();

        if (!string.IsNullOrEmpty(request.GenreName))
        {
            genresQuery = genresQuery
                .Where(g => g.Name.Contains(request.GenreName));
        }

        var genresNames = await genresQuery
            .Select(g => g.Name)
            .ToArrayAsync(cancellationToken);

        return genresNames;
    }
}