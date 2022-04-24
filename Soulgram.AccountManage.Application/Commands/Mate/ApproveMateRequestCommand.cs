using MediatR;
using Soulgram.AccountManage.Application.Models.Requests;
using Soulgram.AccountManage.Application.Services;
using Soulgram.AccountManage.Domain.Entities;

namespace Soulgram.AccountManage.Application.Commands.Mate;

public class ApproveMateRequestCommand : IRequest
{
    public ApproveMateRequestCommand(MateRequestModel model)
    {
        Model = model;
    }

    public MateRequestModel Model { get; }
}

internal class ApproveMateRequestCommandHandler : IRequestHandler<ApproveMateRequestCommand>
{
    private readonly IMateService _mateService;
    private readonly IMediator _mediator;

    public ApproveMateRequestCommandHandler(IMateService mateService, IMediator mediator)
    {
        _mateService = mateService;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(ApproveMateRequestCommand request, CancellationToken cancellationToken)
    {
        await _mateService.EditRequestAsync(request.Model, MateRequestStatus.Approved, cancellationToken);
        
        var addUserMateCommand = new AddUserMateCommand(request.Model);
        await _mediator.Send(addUserMateCommand, cancellationToken);

        return Unit.Value;
    }
}