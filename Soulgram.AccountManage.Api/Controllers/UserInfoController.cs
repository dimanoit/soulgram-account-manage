using MediatR;
using Microsoft.AspNetCore.Mvc;
using Soulgram.AccountManage.Application.Commands;
using Soulgram.AccountManage.Application.Models.Response;
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
    public async Task<CompactUserInfoResponse?> GetUserInfo(string userId, CancellationToken cancellationToken)
    {
        var getUserQuery = new GetCompactUserQuery(userId);
        return await _mediator.Send(getUserQuery, cancellationToken);
    }

    [HttpPatch("{userId}/profile-img")]
    public async Task<string> UploadProfilePicture(
        string userId,
        [FromForm] IFormFile picture,
        CancellationToken cancellationToken)
    {
        var uploadImageCommand = new UploadProfileImageCommand(picture, userId);

        return await _mediator.Send(uploadImageCommand, cancellationToken);
    }

    [HttpDelete("{userId}")]
    public async Task RemoveUserInfo(string userId, CancellationToken cancellationToken)
    {
        var deleteUserCommand = new DeleteUserCommand(userId);
        await _mediator.Send(deleteUserCommand, cancellationToken);
    }

    [HttpDelete("{userId}/profile-img/{imgId}")]
    public async Task DeleteUserProfileImage(
        string userId,
        string imgId,
        CancellationToken cancellationToken)
    {
        var deleteUserCommand = new DeleteUserProfileImg(userId, imgId);
        await _mediator.Send(deleteUserCommand, cancellationToken);
    }
}