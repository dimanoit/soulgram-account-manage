using Soulgram.AccountManage.Appliaction.Model.Requests;
using Soulgram.AccountManage.Infrastracture.IntegrationEvents.Events;

namespace Soulgram.AccountManage.Infrastracture.Converters;

public static class UserEventsConvertor
{
    public static CreateUserRequest ToCreateUserRequest(this SuccessedUserRegistrationEvent @event)
    {
        return new CreateUserRequest
        {
            Birthday = @event.Birthday,
            Email = @event.Email,
            Nickname = @event.Nickname,
            UserId = @event.UserId
        };
    }
}