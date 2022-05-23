using Soulgram.AccountManage.Application.Models.Response;
using Soulgram.AccountManage.Domain.Entities;

namespace Soulgram.AccountManage.Application.Converters;

public static class ProfileImageConverter
{
    internal static UserProfileImageResponseModel ToUserProfileImageResponseModel(this ProfileImage image)
    {
        return new UserProfileImageResponseModel
        {
            Id = image.Id,
            ImgUrl = image.ImgUrl,
            CreationDate = image.CreationDate,
            UserId = image.UserId
        };
    }
}