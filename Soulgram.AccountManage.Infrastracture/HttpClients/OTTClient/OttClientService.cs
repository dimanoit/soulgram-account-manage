using Microsoft.Extensions.Options;
using Soulgram.AccountManage.Application.Services;
using Soulgram.AccountManage.Infrastracture.Converters;

namespace Soulgram.AccountManage.Infrastracture.HttpClients.OTTClient;

public class OttClientService : IMovieSearchService
{
    private readonly HttpClient _httpClient;

    public OttClientService(HttpClient httpClient, IOptions<OTTClientSettings> settings)
    {
        if (settings == null)
        {
            throw new ArgumentNullException(nameof(settings));
        }

        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

        var baseAddress = $"https://{settings.Value.Host}";
        _httpClient.BaseAddress = new Uri(baseAddress);

        if (settings.Value.Headers == null)
        {
            return;
        }

        foreach (var (key, value) in settings.Value.Headers)
        {
            _httpClient.DefaultRequestHeaders.Add(key, value);
        }
    }

    public async Task<ICollection<string>?> GetGenresAsync(CancellationToken cancellationToken)
    {
        var url = "getParams?param=genre";
        var response = await _httpClient.GetAsync(url, cancellationToken);

        return await response.DeserializeStringAsync<string[]?>(cancellationToken);
    }
}