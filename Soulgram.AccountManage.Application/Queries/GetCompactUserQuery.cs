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

    public async Task<CompactUserInfoResponse?> Handle(GetCompactUserQuery request, CancellationToken cancellationToken)
    {
        var profileImg = await _dbContext
            .ProfileImages
            .Where(pi => pi.UserId == request.UserId)
            .OrderByDescending(pi => pi.CreationDate)
            .Select(pi => pi.ImgUrl)
            .LastOrDefaultAsync(cancellationToken);

        var userInfo = await _dbContext
            .UserInfos
            .Where(ui => ui.UserId == request.UserId)
            .Select(u => u.ToCompactUserInfoResponse(profileImg))
            .SingleOrDefaultAsync(cancellationToken);

        return userInfo;
    }
}