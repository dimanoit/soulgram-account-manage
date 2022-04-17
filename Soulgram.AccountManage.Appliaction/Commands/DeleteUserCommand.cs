using MediatR;

namespace Soulgram.AccountManage.Appliaction.Commands;

public class DeleteUserCommand : IRequest
{
    public DeleteUserCommand(string userId)
    {
        UserId = userId;
    }

    public string UserId { get; }
}