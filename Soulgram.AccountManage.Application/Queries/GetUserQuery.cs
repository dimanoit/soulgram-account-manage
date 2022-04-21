using MediatR;
using Soulgram.AccountManage.Application.Model.Response;

namespace Soulgram.AccountManage.Application.Queries;

public class GetUserQuery : IRequest<CompactUserInfoResponse?>
{
    public GetUserQuery(string userId)
    {
        UserId = userId;
    }

    public string UserId { get; }
}