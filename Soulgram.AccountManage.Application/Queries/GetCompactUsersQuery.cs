using MediatR;
using Soulgram.AccountManage.Application.Model.Response;
using Soulgram.AccountManage.Application.Models.Response;
using Soulgram.AccountManage.Persistence;

namespace Soulgram.AccountManage.Application.Queries;

public class GetCompactUsersQuery: IRequest<IEnumerable<CompactUserInfoResponse>?>
{
    public GetCompactUsersQuery(string[] usersIds)
    {
        UsersIds = usersIds;
    }

    public string[] UsersIds { get;  }
}

internal class GetCompactUsersQueryHandler : IRequestHandler<GetCompactUsersQuery,IEnumerable<CompactUserInfoResponse>?>
{
    private readonly SoulgramContext _dbContext;

    public GetCompactUsersQueryHandler(SoulgramContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<CompactUserInfoResponse>?> Handle(GetCompactUsersQuery request, CancellationToken cancellationToken)
    {
        var users 
    }
}