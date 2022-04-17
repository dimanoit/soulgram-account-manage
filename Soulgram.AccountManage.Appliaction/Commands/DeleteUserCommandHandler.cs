using MediatR;
using Soulgram.AccountManage.Domain.Entities;
using Soulgram.AccountManage.Persistence;

namespace Soulgram.AccountManage.Appliaction.Commands;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly SoulgramContext _soulgramContext;

    public DeleteUserCommandHandler(SoulgramContext soulgramContext)
    {
        _soulgramContext = soulgramContext;
    }

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var userInfo = new UserInfo {UserId = request.UserId};

        _soulgramContext.Attach(userInfo);
        _soulgramContext.UserInfos.Remove(userInfo);

        await _soulgramContext.SaveChangesAsync(cancellationToken);

        return await Unit.Task;
    }
}