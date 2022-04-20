using MediatR;

namespace Soulgram.AccountManage.Application.Commands;

public class DeleteUserCommand : IRequest
{
    public string UserId { get;init; }
}