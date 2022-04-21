using Soulgram.AccountManage.Application.Model.Requests;
using Soulgram.AccountManage.Application.Model.Response;
using Soulgram.AccountManage.Domain.Entities;

namespace Soulgram.AccountManage.Application.Converters;

internal static class UserModelsConverter
{
    internal static UserInfo ToUserInfo(this CreateUserRequest userRequest)
    {
        return new UserInfo
        {
            Email = userRequest.Email,
            Nickname = userRequest.Nickname,
            Birthdate = userRequest.Birthday,
            UserId = userRequest.UserId,
            Fullname = userRequest.Fullname
        };
    }

    internal static CompactUserInfoResponse ToCompactUserInfoResponse(
        this UserInfo userInfo,
        string imgUrl,
        IEnumerable<string> hobbies)
    {
        return new CompactUserInfoResponse
        {
            Id = userInfo.UserId,
            Nickname = userInfo.Nickname,
            Fullname = userInfo.Fullname,

            ImgUrl = imgUrl,
            Hobbies = hobbies
        };
    }
}