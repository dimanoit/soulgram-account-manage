using MediatR;
using Microsoft.EntityFrameworkCore;
using Soulgram.AccountManage.Application.Converters;
using Soulgram.AccountManage.Application.Model.Response;
using Soulgram.AccountManage.Domain.Entities;
using Soulgram.AccountManage.Persistence;

namespace Soulgram.AccountManage.Application.Queries;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, CompactUserInfoResponse>
{
    private readonly SoulgramContext _dbContext;

    public GetUserQueryHandler(SoulgramContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CompactUserInfoResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var lastImageTask = _dbContext
            .ProfileImages
            .AsNoTracking()
            .Where(i => i.UserId == request.UserId)
            .OrderBy(i => i.CreationDate)
            .Select(i => i.ImgUrl)
            .LastOrDefaultAsync(cancellationToken);

        var userInfoTask = _dbContext
            .UserInfos
            .AsNoTracking()
            .Where(u => u.UserId == request.UserId)
            .Include(u => u.UserHobbies)
            .ThenInclude(u => u.Hobby)
            .Select(u => new
            {
                u,
                //TODO put 3 into config
                hobbies = u.UserHobbies.Select(c => c.Hobby.Name).Take(3)
            })
            .SingleOrDefaultAsync(cancellationToken);

        await Task.WhenAll(lastImageTask, userInfoTask);

        var userInfo = userInfoTask.Result.u.ToCompactUserInfoResponse(lastImageTask.Result, userInfoTask.Result.hobbies);

        return userInfo;
    }
}