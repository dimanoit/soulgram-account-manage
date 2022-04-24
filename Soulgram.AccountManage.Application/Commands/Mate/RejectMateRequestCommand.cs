using MediatR;
using Soulgram.AccountManage.Application.Models.Requests;
using Soulgram.AccountManage.Application.Services;
using Soulgram.AccountManage.Domain.Entities;

namespace Soulgram.AccountManage.Application.Commands.Mate;

public class RejectMateRequestCommand : IRequest
{
    public RejectMateRequestCommand(MateRequestModel model)
    {
        Model = model;
    }

    public MateRequestModel Model { get; }
}

internal class RejectMateRequestCommandHandler : IRequestHandler<RejectMateRequestCommand>
{
    private readonly IMateService _mateService;

    public RejectMateRequestCommandHandler(IMateService mateService)
    {
        _mateService = mateService;
    }
    
    public async Task<Unit> Handle(RejectMateRequestCommand request, CancellationToken cancellationToken)
    {
        await _mateService.EditRequestAsync(request.Model, MateRequestStatus.Rejected, cancellationToken);
        
        return Unit.Value;
    }
}