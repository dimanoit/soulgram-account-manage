using MediatR;
using Microsoft.EntityFrameworkCore;
using Soulgram.AccountManage.Application.Converters;
using Soulgram.AccountManage.Domain.Entities;
using Soulgram.AccountManage.Persistence;

namespace Soulgram.AccountManage.Application.Commands.Handlers;

public class SendMateRequestCommandHandler : IRequestHandler<SendMateRequestCommand>
{
    private readonly SoulgramContext _dbContext;

    public SendMateRequestCommandHandler(SoulgramContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(SendMateRequestCommand request, CancellationToken cancellationToken)
    {
        var mateRequest = MateConverter.ToMateRequest(request.SenderId, request.RecipientId);

        _dbContext.MateRequests.Add(mateRequest);

        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }

    private async Task ThrowIfAlreadyExist(string currentUserId, CancellationToken cancellationToken)
    {
        var isRequestAlreadyExist = await _dbContext.MateRequests
            .AsNoTracking()
            .Where(mr => mr.RecipientId == currentUserId || mr.SenderId == currentUserId)
            .AnyAsync(cancellationToken);

        if (isRequestAlreadyExist)
        {
            throw new Exception("Mate request with this user already exits");
        }
        

    }
}