using Soulgram.AccountManage.Application.Models.Requests;
using Soulgram.AccountManage.Domain.Entities;

namespace Soulgram.AccountManage.Application.Services;

public interface IMateService
{
    Task EditRequestAsync(MateRequestModel model, MateRequestStatus status, CancellationToken cancellationToken);
}