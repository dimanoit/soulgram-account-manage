using MediatR;
using Soulgram.AccountManage.Domain.Entities;
using Soulgram.AccountManage.Persistence;

namespace Soulgram.AccountManage.Application.Commands;

public class AddHobbyToUserCommandHandler: IRequestHandler<AddHobbyToUserCommand>
{
    private readonly SoulgramContext _dbContext;

    public AddHobbyToUserCommandHandler(SoulgramContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(AddHobbyToUserCommand request, CancellationToken cancellationToken)
    {
        var userHobby = new UserHobby()
        {
            HobbieId = request.HobbyId,
            UserId = request.UserId,
            CreationDate = DateTime.UtcNow
        };

        _dbContext.UserHobbies.Add(userHobby);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}