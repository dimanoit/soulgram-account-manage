using MediatR;
using Microsoft.AspNetCore.Mvc;
using Soulgram.AccountManage.Appliaction.Commands;

namespace Soulgram.AccountManage.Api.Controllers;

[Route("api/[controller]")]
public class UserInfoController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserInfoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("healthcheck")]
    public IActionResult HealthCheck()
    {
        return Ok();
    }

    [HttpDelete("{userId}")]
    public async Task RemoveUserInfo(string userId)
    {
        var deleteUserCommand = new DeleteUserCommand(userId);
        await _mediator.Send(deleteUserCommand);
    }
}