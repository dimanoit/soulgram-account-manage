namespace Soulgram.AccountManage.Infrastracture.HttpClients.OTTClient;

public record OTTClientSettings
{
    public string? Key { get; init; }
    public string? Host { get; init; }
}