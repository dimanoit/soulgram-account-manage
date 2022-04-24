namespace Soulgram.AccountManage.Application.Models.Requests;

public record MateRequestModel
{
    public string? SenderId { get; init; }
    public string? RecipientId { get; init; }
}