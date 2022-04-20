using MediatR;
using Soulgram.AccountManage.Application.Commands;
using Soulgram.AccountManage.Infrastracture.Converters;
using Soulgram.AccountManage.Infrastracture.IntegrationEvents.Events;
using Soulgram.Eventbus.Interfaces;

namespace Soulgram.AccountManage.Infrastracture.IntegrationEvents.EventHandling;

public class SuccessedUserRegistrationEventHandler : IIntegrationEventHandler<SuccessedUserRegistrationEvent>
{
    private readonly IMediator _mediator;

    public SuccessedUserRegistrationEventHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Handle(SuccessedUserRegistrationEvent @event)
    {
        var createUserCommand = new CreateUserCommand()
        {
            RequestModel = @event.ToCreateUserRequest()
        };

        try
        {
            await _mediator.Send(createUserCommand);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}