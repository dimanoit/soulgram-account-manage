using MediatR;
using Soulgram.AccountManage.Application.Converters;
using Soulgram.AccountManage.Application.Models.Requests;
using Soulgram.AccountManage.Persistence;

namespace Soulgram.AccountManage.Application.Commands.Mate;

public class AddUserMateCommand : IRequest
{
    public AddUserMateCommand(MateRequestModel model)
    {
        Model = model;
    }

    public MateRequestModel Model { get; }
}

public class AddUserMateCommandHandler : IRequestHandler<AddUserMateCommand>
{
    private readonly SoulgramContext _dbContext;

    public AddUserMateCommandHandler(SoulgramContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(AddUserMateCommand request, CancellationToken cancellationToken)
    {
        var userMate = request.Model.ToUserMate();

        _dbContext.UserMates.Add(userMate);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}