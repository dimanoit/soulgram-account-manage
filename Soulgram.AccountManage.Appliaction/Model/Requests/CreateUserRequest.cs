namespace Soulgram.AccountManage.Appliaction.Model.Requests;

public record CreateUserRequest
{
    public string Nickname { get; init; }
    public string Email { get; init; }
    public DateTime Birthday { get; init; }
    public string UserId { get; init; }
}