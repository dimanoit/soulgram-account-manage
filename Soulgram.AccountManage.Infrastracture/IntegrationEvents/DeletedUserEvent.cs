using MediatR;
using Soulgram.AccountManage.Application.Commands;
using Soulgram.Eventbus;
using Soulgram.Eventbus.Interfaces;

namespace Soulgram.AccountManage.Infrastracture.IntegrationEvents;

public class DeletedUserEvent : IntegrationEvent
{
    public DeletedUserEvent(string userId)
    {
        UserId = userId;
    }

    public string UserId { get; }
}

public class DeletedUserEventHandler : IIntegrationEventHandler<DeletedUserEvent>
{
    private readonly IMediator _mediator;

    public DeletedUserEventHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Handle(DeletedUserEvent @event)
    {
        var userId = @event.UserId;
        var deleteCommand = new DeleteUserCommand(userId);

        await _mediator.Send(deleteCommand);
    }
}