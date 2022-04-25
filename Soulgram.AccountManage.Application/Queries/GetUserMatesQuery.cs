using MediatR;
using Microsoft.EntityFrameworkCore;
using Soulgram.AccountManage.Application.Models.Response;
using Soulgram.AccountManage.Persistence;

namespace Soulgram.AccountManage.Application.Queries;

public class GetUserMatesQuery : IRequest<IEnumerable<CompactUserInfoResponse>?>
{
    public GetUserMatesQuery(string userId)
    {
        UserId = userId;
    }

    public string UserId { get; }
}

internal class GetUserMatesQueryHandler : IRequestHandler<GetUserMatesQuery,IEnumerable<CompactUserInfoResponse>?>
{
    private readonly SoulgramContext _dbContext;
    private readonly IMediator _mediator;
    
    public GetUserMatesQueryHandler(SoulgramContext dbContext, IMediator mediator)
    {
        _dbContext = dbContext;
        _mediator = mediator;
    }

    public async Task<IEnumerable<CompactUserInfoResponse>?> Handle(GetUserMatesQuery request, CancellationToken cancellationToken)
    {
        var matesIds = await _dbContext
            .UserMates
            .AsNoTracking()
            .Where(um => um.UserId == request.UserId || um.MateId == request.UserId)
            .Select(um => um.UserId == request.UserId ? um.MateId : um.UserId)
            .ToArrayAsync(cancellationToken);

        var getMatesInfosRequest = new GetCompactUsersQuery(matesIds);
        return await _mediator.Send(getMatesInfosRequest, cancellationToken);
    }
}