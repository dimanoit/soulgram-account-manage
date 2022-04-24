using MediatR;
using Soulgram.AccountManage.Application.Commands;
using Soulgram.AccountManage.Infrastracture.Converters;
using Soulgram.Eventbus;
using Soulgram.Eventbus.Interfaces;

namespace Soulgram.AccountManage.Infrastracture.IntegrationEvents;

public class SuccessedUserRegistrationEvent : IntegrationEvent
{
    public SuccessedUserRegistrationEvent(
        string nickname,
        string email,
        string userId,
        string fullname,
        DateTime birthday)
    {
        Nickname = nickname;
        Email = email;
        UserId = userId;
        Birthday = birthday;
        Fullname = fullname;
    }

    public string Nickname { get; }
    public string Fullname { get; }
    public string Email { get; }
    public DateTime Birthday { get; }
    public string UserId { get; }
}

public class SuccessedUserRegistrationEventHandler : IIntegrationEventHandler<SuccessedUserRegistrationEvent>
{
    private readonly IMediator _mediator;

    public SuccessedUserRegistrationEventHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Handle(SuccessedUserRegistrationEvent @event)
    {
        var model = @event.ToCreateUserRequest();
        var createUserCommand = new CreateUserCommand(model);

        await _mediator.Send(createUserCommand);
    }
}