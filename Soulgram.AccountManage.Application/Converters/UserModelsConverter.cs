using Soulgram.AccountManage.Application.Model.Requests;
using Soulgram.AccountManage.Application.Model.Response;
using Soulgram.AccountManage.Application.Models.Response;
using Soulgram.AccountManage.Domain.Entities;

namespace Soulgram.AccountManage.Application.Converters;

internal static class UserModelsConverter
{
    internal static UserInfo ToUserInfo(this CreateUserRequestModel userRequestModel)
    {
        return new UserInfo
        {
            Email = userRequestModel.Email,
            Nickname = userRequestModel.Nickname,
            Birthdate = userRequestModel.Birthday,
            UserId = userRequestModel.UserId,
            Fullname = userRequestModel.Fullname
        };
    }

    internal static CompactUserInfoResponse ToCompactUserInfoResponse(
        this UserInfo userInfo,
        string imgUrl)
    {
        return new CompactUserInfoResponse
        {
            Id = userInfo.UserId,
            Nickname = userInfo.Nickname,
            Fullname = userInfo.Fullname,

            ImgUrl = imgUrl,
        };
    }
}