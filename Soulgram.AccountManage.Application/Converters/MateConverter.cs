using Soulgram.AccountManage.Application.Model.Response;
using Soulgram.AccountManage.Application.Models.Requests;
using Soulgram.AccountManage.Domain.Entities;

namespace Soulgram.AccountManage.Application.Converters;

public static class MateConverter
{
    public static MateRequest ToMateRequest(MateRequestModel model)
    {
        var request = new MateRequest
        {
            SenderId = model.SenderId!,
            RecipientId = model.RecipientId!,

            Status = MateRequestStatus.InProgress
        };

        return request;
    }
    
    public static UserMate ToUserMate(this MateRequestModel model)
    {
        var request = new UserMate
        {
            UserId = model.SenderId!,
            MateId = model.RecipientId!,
        };

        return request;
    }

    public static IEnumerable<MateRequestResponse>? ToMateRequestResponses(this MateRequest[] mateRequests)
    {
        return mateRequests?.Select(mr => mr.ToMateRequestResponse());
    }

    public static MateRequestResponse ToMateRequestResponse(this MateRequest mateRequest)
    {
        var response = new MateRequestResponse
        {
            SenderId = mateRequest.SenderId,
            RecipientId = mateRequest.RecipientId,

            Status = mateRequest.Status
        };

        return response;
    }
}