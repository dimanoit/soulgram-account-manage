using Soulgram.AccountManage.Application.Model.Requests;
using Soulgram.AccountManage.Domain.Entities;

namespace Soulgram.AccountManage.Application.Converters;

public static class HobbyModelsConverter
{
    public static Hobby ToHobby(this CreateHobbyRequest hobbyRequest)
    {
        return new Hobby
        {
            Id = Guid.NewGuid().ToString(),
            Name = hobbyRequest.Name,
            Desription = hobbyRequest.Desription,
            IsActive = hobbyRequest.IsActive,
            IsGroupOnly = hobbyRequest.IsGroupOnly
        };
    }
}