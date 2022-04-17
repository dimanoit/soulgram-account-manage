using MediatR;
using Soulgram.AccountManage.Appliaction.Converters;
using Soulgram.AccountManage.Domain.Entities;
using Soulgram.AccountManage.Persistence;

namespace Soulgram.AccountManage.Appliaction.Commands;

internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
    private readonly SoulgramContext _soulgramContext;

    public CreateUserCommandHandler(SoulgramContext soulgramContext)
    {
        _soulgramContext = soulgramContext;
    }

    public async Task<Unit> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var userInfo = command.RequestModel.ToUserInfo();

        _soulgramContext.UserInfos.Add(userInfo);

        var countOfUpdatedRows = await _soulgramContext.SaveChangesAsync(cancellationToken);

        if (countOfUpdatedRows != 1)
            //TODO solve problem with logging and string interpolation
        {
            throw new Exception($"Should add 1 {typeof(UserInfo)} but added ${countOfUpdatedRows}");
        }

        return await Unit.Task;
    }
}