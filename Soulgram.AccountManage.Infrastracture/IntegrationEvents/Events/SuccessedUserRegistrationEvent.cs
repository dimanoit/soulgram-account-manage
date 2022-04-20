using Soulgram.Eventbus;

namespace Soulgram.AccountManage.Infrastracture.IntegrationEvents.Events;

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