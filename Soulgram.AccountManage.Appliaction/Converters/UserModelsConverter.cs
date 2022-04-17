using Soulgram.AccountManage.Appliaction.Model.Requests;
using Soulgram.AccountManage.Domain.Entities;

namespace Soulgram.AccountManage.Appliaction.Converters;

internal static class UserModelsConverter
{
    internal static UserInfo ToUserInfo(this CreateUserRequest userRequest)
    {
        return new UserInfo
        {
            Email = userRequest.Email,
            Nickname = userRequest.Nickname,
            Birthdate = userRequest.Birthday,
            UserId = userRequest.UserId
        };
    }
}