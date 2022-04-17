using Soulgram.Eventbus;

namespace Soulgram.AccountManage.Infrastracture.IntegrationEvents.Events;

public class DeletedUserEvent : IntegrationEvent
{
    public DeletedUserEvent(string userId)
    {
        UserId = userId;
    }

    public string UserId { get; }
}