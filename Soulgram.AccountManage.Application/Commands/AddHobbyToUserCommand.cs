using MediatR;

namespace Soulgram.AccountManage.Application.Commands;

public class AddHobbyToUserCommand : IRequest
{
    public string UserId { get; init; }  
    public string HobbyId { get; init; }
}