using System.Linq.Expressions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Soulgram.AccountManage.Application.Converters;
using Soulgram.AccountManage.Application.Models.Response;
using Soulgram.AccountManage.Domain.Entities;
using Soulgram.AccountManage.Persistence;

namespace Soulgram.AccountManage.Application.Queries;

public class GetCompactUsersQuery : IRequest<IEnumerable<CompactUserInfoResponse>?>
{
    public GetCompactUsersQuery(string[] usersIds)
    {
        UsersIds = usersIds;
    }

    public string[] UsersIds { get; }
}

internal class
    GetCompactUsersQueryHandler : IRequestHandler<GetCompactUsersQuery, IEnumerable<CompactUserInfoResponse>?>
{
    private readonly SoulgramContext _dbContext;

    public GetCompactUsersQueryHandler(SoulgramContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<CompactUserInfoResponse>?> Handle(GetCompactUsersQuery request,
        CancellationToken cancellationToken)
    {
        var usersInfos = await _dbContext
            .UserInfos
            .Where(ui => request.UsersIds.Any(id => id == ui.UserId))
            .Include(ui => ui.ProfileImages)
            .Select(UserInfoSelector())
            .ToArrayAsync(cancellationToken);

        return usersInfos;
    }

    private static Expression<Func<UserInfo, CompactUserInfoResponse>> UserInfoSelector()
    {
        return ui => ui
            .ToCompactUserInfoResponse(ui.ProfileImages
                .OrderBy(pi => pi.CreationDate)
                .Select(pi => pi.ImgUrl)
                .LastOrDefault()
            );
    }
}