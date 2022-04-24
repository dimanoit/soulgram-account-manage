using MediatR;
using Microsoft.EntityFrameworkCore;
using Soulgram.AccountManage.Application.Converters;
using Soulgram.AccountManage.Application.Models.Requests;
using Soulgram.AccountManage.Persistence;

namespace Soulgram.AccountManage.Application.Commands;

public class SendMateRequestCommand: IRequest
{
    public SendMateRequestCommand(MateRequestModel model)
    {
        Model = model;
    }
    
    public MateRequestModel Model { get; }
}

internal class SendMateRequestCommandHandler : IRequestHandler<SendMateRequestCommand>
{
    private readonly SoulgramContext _dbContext;

    public SendMateRequestCommandHandler(SoulgramContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(SendMateRequestCommand request, CancellationToken cancellationToken)
    {
        if (request.Model.SenderId == null || request.Model.RecipientId == null)
        {
            throw new Exception();
        }
        
        await ThrowIfAlreadyExist(request.Model.SenderId, cancellationToken);
        
        var mateRequest = MateConverter.ToMateRequest(request.Model);
        
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