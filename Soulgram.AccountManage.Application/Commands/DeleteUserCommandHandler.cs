using MediatR;
using Soulgram.AccountManage.Domain.Entities;
using Soulgram.AccountManage.Persistence;

namespace Soulgram.AccountManage.Application.Commands;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly SoulgramContext _dbContext;

    public DeleteUserCommandHandler(SoulgramContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var userInfo = new UserInfo {UserId = request.UserId};

        _dbContext.Attach(userInfo);
        _dbContext.UserInfos.Remove(userInfo);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return await Unit.Task;
    }
}