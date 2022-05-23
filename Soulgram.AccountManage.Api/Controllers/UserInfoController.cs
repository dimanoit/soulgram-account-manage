using MediatR;
using Microsoft.AspNetCore.Mvc;
using Soulgram.AccountManage.Application.Commands;
using Soulgram.AccountManage.Application.Models.Response;
using Soulgram.AccountManage.Application.Queries;

namespace Soulgram.AccountManage.Api.Controllers;

[Route("api/user-info")]
public class UserInfoController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserInfoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{userId}")]
    public async Task<CompactUserInfoResponse?> GetUserInfo(string userId, CancellationToken cancellationToken)
    {
        var getUserQuery = new GetCompactUserQuery(userId);
        return await _mediator.Send(getUserQuery, cancellationToken);
    }

    [HttpDelete("{userId}")]
    public async Task RemoveUserInfo(string userId, CancellationToken cancellationToken)
    {
        var deleteUserCommand = new DeleteUserCommand(userId);
        await _mediator.Send(deleteUserCommand, cancellationToken);
    }
}