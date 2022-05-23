using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Soulgram.AccountManage.Persistence;
using Soulgram.File.Manager.Interfaces;

namespace Soulgram.AccountManage.Application.Commands;

public class DeleteUserProfileImg : IRequest
{
    public DeleteUserProfileImg(string userId, string imgId)
    {
        UserId = userId;
        ImgId = imgId;
    }

    public string UserId { get; }
    public string ImgId { get; }
}

internal class DeleteUserProfileImgHandler : IRequestHandler<DeleteUserProfileImg>
{
    private readonly SoulgramContext _dbContext;
    private readonly IFileManager _fileManager;
    private readonly ILogger<DeleteUserCommandHandler> _logger;

    public DeleteUserProfileImgHandler(
        IFileManager fileManager,
        SoulgramContext dbContext,
        ILogger<DeleteUserCommandHandler> logger)
    {
        _fileManager = fileManager;
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteUserProfileImg request, CancellationToken cancellationToken)
    {
        var imageToRemove = await _dbContext.ProfileImages
            .SingleOrDefaultAsync(_ => _.Id == request.ImgId && _.UserId == request.UserId
                , cancellationToken);

        if (imageToRemove == null)
        {
            return Unit.Value;
        }
        
        await using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            await _fileManager.DeleteFileAsync(imageToRemove.ImgUrl);

            _dbContext.ProfileImages.Remove(imageToRemove ?? throw new InvalidOperationException(
                $"Img with url {request.ImgId} doesn't exit"));

            await _dbContext.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while deleting profile img {request}", request);

            await transaction.RollbackAsync(cancellationToken);
            throw;
        }

        return Unit.Value;
    }
}