using MediatR;
using Microsoft.EntityFrameworkCore;
using Soulgram.AccountManage.Application.Converters;
using Soulgram.AccountManage.Application.Models.Response;
using Soulgram.AccountManage.Persistence;

namespace Soulgram.AccountManage.Application.Queries;

public class GetUserProfileImagesQuery : IRequest<UserProfileImageResponseModel[]>
{
    public GetUserProfileImagesQuery(string userId)
    {
        UserId = userId;
    }

    public string UserId { get; }
}

internal class GetUserProfileImagesHandler
    : IRequestHandler<GetUserProfileImagesQuery, UserProfileImageResponseModel[]>
{
    private readonly SoulgramContext _dbContext;

    public GetUserProfileImagesHandler(SoulgramContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserProfileImageResponseModel[]> Handle(
        GetUserProfileImagesQuery request,
        CancellationToken cancellationToken)
    {
        return await _dbContext.ProfileImages
            .Where(_ => _.UserId == request.UserId)
            .Select(_ => _.ToUserProfileImageResponseModel())
            .ToArrayAsync(cancellationToken);
    }
}