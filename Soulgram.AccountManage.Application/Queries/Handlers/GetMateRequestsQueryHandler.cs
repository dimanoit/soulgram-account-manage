using MediatR;
using Microsoft.EntityFrameworkCore;
using Soulgram.AccountManage.Application.Converters;
using Soulgram.AccountManage.Application.Model.Response;
using Soulgram.AccountManage.Domain.Entities;
using Soulgram.AccountManage.Persistence;

namespace Soulgram.AccountManage.Application.Queries.Handlers;

public class GetMateRequestsQueryHandler : IRequestHandler<GetMateRequestsQuery, IEnumerable<MateRequestResponse>?>
{
    private readonly SoulgramContext _dbContext;

    public GetMateRequestsQueryHandler(SoulgramContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<MateRequestResponse>?> Handle(GetMateRequestsQuery request, CancellationToken cancellationToken)
    {
        var requests = await _dbContext.MateRequests
            .AsNoTracking()
            .Where(u => u.SenderId == request.UserId || u.RecipientId == request.UserId)
            .ToArrayAsync(cancellationToken);


        var response = requests.ToMateRequestResponses();
        return response;
    }
}