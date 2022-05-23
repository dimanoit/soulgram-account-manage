using MediatR;
using Microsoft.AspNetCore.Mvc;
using Soulgram.AccountManage.Application.Commands;
using Soulgram.AccountManage.Application.Models.Response;
using Soulgram.AccountManage.Application.Queries;

namespace Soulgram.AccountManage.Api.Controllers;

[Route("api/images")]
public class ImagesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ImagesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<UserProfileImageResponseModel[]> GetAllProfileImages(
        string userId,
        CancellationToken cancellationToken)
    {
        var uploadImageCommand = new GetUserProfileImagesQuery(userId);
        return await _mediator.Send(uploadImageCommand, cancellationToken);
    }

    [HttpPatch]
    public async Task<string> UploadProfilePicture(
        string userId,
        [FromForm] IFormFile picture,
        CancellationToken cancellationToken)
    {
        var uploadImageCommand = new UploadProfileImageCommand(picture, userId);

        return await _mediator.Send(uploadImageCommand, cancellationToken);
    }

    [HttpDelete("{imgId}")]
    public async Task DeleteUserProfileImage(
        string imgId,
        string userId,
        CancellationToken cancellationToken)
    {
        var deleteUserCommand = new DeleteUserProfileImg(userId, imgId);
        await _mediator.Send(deleteUserCommand, cancellationToken);
    }
}