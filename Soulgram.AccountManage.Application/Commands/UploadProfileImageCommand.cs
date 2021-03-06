using MediatR;
using Microsoft.AspNetCore.Http;
using Soulgram.AccountManage.Application.Converters;
using Soulgram.AccountManage.Domain.Entities;
using Soulgram.AccountManage.Persistence;
using Soulgram.File.Manager.Interfaces;

namespace Soulgram.AccountManage.Application.Commands;

public class UploadProfileImageCommand : IRequest<string>
{
    public UploadProfileImageCommand(IFormFile img, string userId)
    {
        Img = img;
        UserId = userId;
    }

    public IFormFile Img { get; }
    public string UserId { get; }
}

internal class UploadProfileImageCommandHandler : IRequestHandler<UploadProfileImageCommand, string>
{
    private readonly SoulgramContext _dbContext;
    private readonly IFileManager _fileManager;

    public UploadProfileImageCommandHandler(IFileManager fileManager, SoulgramContext dbContext)
    {
        _fileManager = fileManager;
        _dbContext = dbContext;
    }

    public async Task<string> Handle(UploadProfileImageCommand request, CancellationToken cancellationToken)
    {
        var file = request.Img.ToFileInfo();
        var filePath = await _fileManager.UploadFileAsync(file, request.UserId);

        var profileImg = new ProfileImage
        {
            ImgUrl = filePath,
            Id = Guid.NewGuid().ToString(),
            CreationDate = DateTime.UtcNow,
            UserId = request.UserId
        };
        _dbContext.ProfileImages.Add(profileImg);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return filePath;
    }
}