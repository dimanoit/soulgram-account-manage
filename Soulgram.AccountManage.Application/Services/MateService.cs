using Soulgram.AccountManage.Application.Models.Requests;
using Soulgram.AccountManage.Domain.Entities;

namespace Soulgram.AccountManage.Application.Services;

public class MateService : IMateService
{
    public Task EditRequestAsync(MateRequestModel model, MateRequestStatus status, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}