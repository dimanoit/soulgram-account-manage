namespace Soulgram.AccountManage.Infrastracture;

public record EventBusOption
{
    public string? Url { get; init; }
    public string? Exchange { get; init; }
    public string? Queue { get; init; }

    public string? Username { get; init; }
    public string? Password { get; init; }
}