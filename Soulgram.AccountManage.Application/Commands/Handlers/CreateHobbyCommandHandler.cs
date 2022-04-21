using MediatR;
using Soulgram.AccountManage.Application.Converters;
using Soulgram.AccountManage.Persistence;

namespace Soulgram.AccountManage.Application.Commands;

public class CreateHobbyCommandHandler : IRequestHandler<CreateHobbyCommand>
{
    private readonly SoulgramContext _dbContext;

    public CreateHobbyCommandHandler(SoulgramContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(CreateHobbyCommand request, CancellationToken cancellationToken)
    {
        var entity = request.RequestModel.ToHobby();

        _dbContext.Hobbies.Add(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}