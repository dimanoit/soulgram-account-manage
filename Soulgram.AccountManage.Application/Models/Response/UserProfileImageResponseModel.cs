namespace Soulgram.AccountManage.Application.Models.Response;

public record UserProfileImageResponseModel
{
    public string Id { get; init; } = null!;
    public string ImgUrl { get; init; } = null!;
    public DateTime CreationDate { get; init; }
    public string UserId { get; init; } = null!;
}