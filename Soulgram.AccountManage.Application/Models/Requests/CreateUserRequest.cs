namespace Soulgram.AccountManage.Application.Model.Requests;

public record CreateUserRequestModel
{
    public string Nickname { get; init; }
    public string Email { get; init; }
    public DateTime Birthday { get; init; }
    public string UserId { get; init; }
    public string Fullname { get; init; }
}