using MediatR;
using Soulgram.AccountManage.Appliaction.Commands;
using Soulgram.AccountManage.Infrastracture.IntegrationEvents.Events;
using Soulgram.Eventbus.Interfaces;

namespace Soulgram.AccountManage.Infrastracture.IntegrationEvents.EventHandling;

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

        await _mediator.Publish(deleteCommand);

        throw new NotImplementedException();
    }
}