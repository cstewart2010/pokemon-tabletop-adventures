using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json;

namespace PokemonTabletopAdventures.Web.Domain;

[ExcludeFromCodeCoverage]
internal class HttpRequestMessageBuilder(HttpMethod httpMethod, Uri baseAddress, string endpoint)
{
    private readonly HttpRequestMessage _httpRequestMessage = new()
    {
        Method = httpMethod,
        RequestUri = new Uri(baseAddress, endpoint),
    };

    public HttpRequestMessageBuilder WithPayload<T>(string contentType, T payload)
    {
        var json = JsonSerializer.Serialize(payload);
        _httpRequestMessage.Content = new StringContent(json, Encoding.UTF8, contentType);
        return this;
    }

    public HttpRequestMessageBuilder WithHeader(string name, string value)
    {
        _httpRequestMessage.Headers.Add(name, value);
        return this;
    }

    public HttpRequestMessage Build()
    {
        return _httpRequestMessage;
    }
}
