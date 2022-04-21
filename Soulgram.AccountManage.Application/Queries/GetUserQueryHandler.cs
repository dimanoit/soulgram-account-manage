using System.Linq.Expressions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Soulgram.AccountManage.Application.Converters;
using Soulgram.AccountManage.Application.Model.Response;
using Soulgram.AccountManage.Domain.Entities;
using Soulgram.AccountManage.Persistence;

namespace Soulgram.AccountManage.Application.Queries;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, CompactUserInfoResponse?>
{
    private readonly SoulgramContext _dbContext;

    public GetUserQueryHandler(SoulgramContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CompactUserInfoResponse?> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var lastImage = await _dbContext
            .ProfileImages
            .AsNoTracking()
            .Where(i => i.UserId == request.UserId)
            .OrderBy(i => i.CreationDate)
            .Select(i => i.ImgUrl)
            .LastOrDefaultAsync(cancellationToken);

        var userInfo = await _dbContext
            .UserInfos
            .AsNoTracking()
            .Where(u => u.UserId == request.UserId)
            .Include(u => u.UserHobbies)
            .ThenInclude(u => u.Hobby)
            .Select(UserInfoWithHobbySelector(lastImage))
            .SingleOrDefaultAsync(cancellationToken);

        return userInfo;
    }

    private static Expression<Func<UserInfo, CompactUserInfoResponse>> UserInfoWithHobbySelector(string? lastImage)
    {
        return u =>
            u.ToCompactUserInfoResponse(
                lastImage,
                u.UserHobbies
                    .Select(uh => uh.Hobby)
                    .OrderBy(h => h.CountOfUsage)
                    //TODO get 3 from Config
                    .Take(3)
                    .Select(h => h.Name));
    }
}