using MediatR;
using Soulgram.AccountManage.Application.Model.Response;

namespace Soulgram.AccountManage.Application.Queries;

public class GetCompactUserQuery : IRequest<CompactUserInfoResponse?>
{
    public GetCompactUserQuery(string userId)
    {
        UserId = userId;
    }

    public string UserId { get; }
}