using MediatR;
using Microsoft.AspNetCore.Http;

namespace Soulgram.AccountManage.Application.Commands;

public class UploadProfileImageCommand : IRequest<string>
{
    public IFormFile Img { get; init; }
    public string UserId { get; init; }
}