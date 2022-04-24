using Soulgram.AccountManage.Application.Model.Response;
using Soulgram.AccountManage.Domain.Entities;

namespace Soulgram.AccountManage.Application.Converters;

public static class MateConverter
{
    public static MateRequest ToMateRequest(string senderId, string recipientId)
    {
        var request = new MateRequest
        {
            SenderId = senderId,
            RecipientId = recipientId,

            Status = MateRequestStatus.InProgress
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