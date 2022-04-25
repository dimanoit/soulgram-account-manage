using Microsoft.EntityFrameworkCore;
using Soulgram.AccountManage.Application.Models.Requests;
using Soulgram.AccountManage.Domain.Entities;
using Soulgram.AccountManage.Persistence;

namespace Soulgram.AccountManage.Application.Services;

public class MateService : IMateService
{
    private readonly SoulgramContext _dbContext;

    public MateService(SoulgramContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task EditRequestAsync(MateRequestModel model, MateRequestStatus status, CancellationToken cancellationToken)
    {
        var mateRequestToUpdate = await _dbContext
            .MateRequests
            .Where(mr => mr.RecipientId == model.RecipientId && mr.SenderId == model.SenderId)
            .SingleOrDefaultAsync(cancellationToken);

        if (mateRequestToUpdate == null)
        {
            throw new ArgumentNullException();
        }
        
        mateRequestToUpdate.Status = status;
        _dbContext.MateRequests.Update(mateRequestToUpdate);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}