using Soulgram.AccountManage.Domain.Entities;

namespace Soulgram.AccountManage.Application.Model.Response;

public record MateRequestResponse
{
    public string SenderId { get; init; }
    public string? RecipientId { get; init; }
    public MateRequestStatus Status { get; init; } 
}