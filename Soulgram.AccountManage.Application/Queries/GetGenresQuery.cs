using MediatR;
using Microsoft.EntityFrameworkCore;
using Soulgram.AccountManage.Persistence;

namespace Soulgram.AccountManage.Application.Queries;

public class GetGenresQuery : IRequest<ICollection<string>?>
{
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
        var genresNames = await _dbContext
            .Genres
            .AsNoTracking()
            .Select(g => g.Name)
            .ToArrayAsync(cancellationToken);

        return genresNames;
    }
}