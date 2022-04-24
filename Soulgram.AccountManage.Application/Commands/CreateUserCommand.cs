using MediatR;
using Soulgram.AccountManage.Application.Converters;
using Soulgram.AccountManage.Application.Model.Requests;
using Soulgram.AccountManage.Domain.Entities;
using Soulgram.AccountManage.Persistence;

namespace Soulgram.AccountManage.Application.Commands;

public sealed class CreateUserCommand : IRequest
{
    public CreateUserCommand(CreateUserRequestModel requestModelModel)
    {
        RequestModelModel = requestModelModel;
    }

    public CreateUserRequestModel RequestModelModel { get;  }
}

internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
    private readonly SoulgramContext _dbContext;

    public CreateUserCommandHandler(SoulgramContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var userInfo = command.RequestModelModel.ToUserInfo();

        _dbContext.UserInfos.Add(userInfo);

        var countOfUpdatedRows = await _dbContext.SaveChangesAsync(cancellationToken);

        if (countOfUpdatedRows != 1)
            //TODO solve problem with logging and string interpolation
        {
            throw new Exception($"Should add 1 {typeof(UserInfo)} but added ${countOfUpdatedRows}");
        }

        return await Unit.Task;
    }
}