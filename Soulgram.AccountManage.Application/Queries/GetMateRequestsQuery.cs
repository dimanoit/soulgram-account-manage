using MediatR;
using Soulgram.AccountManage.Application.Model.Response;

namespace Soulgram.AccountManage.Application.Queries;

public class GetMateRequestsQuery : IRequest<IEnumerable<MateRequestResponse>?>
{
    public string UserId { get; init; }
}