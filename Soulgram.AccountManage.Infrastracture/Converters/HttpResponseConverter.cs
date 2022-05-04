using System.Text.Json;

namespace Soulgram.AccountManage.Infrastracture.Converters;

public static class HttpResponseParser
{
    public static async Task<T?> DeserializeStringAsync<T>(
        this HttpResponseMessage response,
        CancellationToken cancellationToken)
    {
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException();
        }

        var responseJson = await response.Content.ReadAsStringAsync(cancellationToken);

        return JsonSerializer.Deserialize<T>(responseJson);
    }
}