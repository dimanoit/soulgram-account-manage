using MediatR;
using Microsoft.AspNetCore.Mvc;
using Soulgram.AccountManage.Application.Commands;
using Soulgram.AccountManage.Application.Model.Response;
using Soulgram.AccountManage.Application.Queries;

namespace Soulgram.AccountManage.Api.Controllers;

[Route("api/[controller]")]
public class UserInfoController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserInfoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{userId}")]
    public async Task<CompactUserInfoResponse> GetUserInfo(string userId, CancellationToken cancellationToken)
    {
        var getUserQuery = new GetUserQuery(userId);
        return await _mediator.Send(getUserQuery, cancellationToken);
    }

    [HttpPatch("{userId}/hobby/{hobbyId}")]
    public async Task AddHobbyToUser(string userId, string hobbyId,
        CancellationToken cancellationToken)
    {
        var addHobbyToUserCommand = new AddHobbyToUserCommand()
        {
            HobbyId = hobbyId,
            UserId = userId
        };

        await _mediator.Send(addHobbyToUserCommand, cancellationToken);
    }

    [HttpDelete("{userId}")]
    public async Task RemoveUserInfo(string userId, CancellationToken cancellationToken)
    {
        var deleteUserCommand = new DeleteUserCommand
        {
            UserId = userId
        };

        await _mediator.Send(deleteUserCommand, cancellationToken);
    }
}