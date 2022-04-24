using MediatR;
using Microsoft.EntityFrameworkCore;
using Soulgram.AccountManage.Application.Converters;
using Soulgram.AccountManage.Application.Models.Response;
using Soulgram.AccountManage.Persistence;

namespace Soulgram.AccountManage.Application.Queries;

public class GetCompactUserQuery : IRequest<CompactUserInfoResponse?>
{
    public GetCompactUserQuery(string userId)
    {
        UserId = userId;
    }

    public string UserId { get; }
}

internal class GetCompactUserQueryHandler : IRequestHandler<GetCompactUserQuery, CompactUserInfoResponse?>
{
    private readonly SoulgramContext _dbContext;

    public GetCompactUserQueryHandler(SoulgramContext dbContext)
    {
        _dbContext = dbContext;
    }

    //TODO fix that
    public Task<CompactUserInfoResponse?> Handle(GetCompactUserQuery request, CancellationToken cancellationToken)
    {
        var userInfo = _dbContext.UserInfos
            .AsNoTracking()
            .Include(u => u.ProfileImages)
            .Select(u => u.ToCompactUserInfoResponse(i))
            .ToArrayAsync(cancellationToken);
    }
}