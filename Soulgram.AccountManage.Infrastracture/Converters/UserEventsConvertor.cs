using Soulgram.AccountManage.Application.Model.Requests;
using Soulgram.AccountManage.Infrastracture.IntegrationEvents;

namespace Soulgram.AccountManage.Infrastracture.Converters;

public static class UserEventsConvertor
{
    public static CreateUserRequestModel ToCreateUserRequest(this SuccessedUserRegistrationEvent @event)
    {
        var requestModel = new CreateUserRequestModel
        {
            Birthday = @event.Birthday,
            Email = @event.Email,
            Nickname = @event.Nickname,
            UserId = @event.UserId,
            Fullname = @event.Fullname
        };

        return requestModel;
    }
}