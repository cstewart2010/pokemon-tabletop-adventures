using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using PokemonTabletopAdventures.Web.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PokemonTabletopAdventures.Web.Domain;

[ExcludeFromCodeCoverage]
public abstract class BaseResponse
{
    protected static readonly StringEnumConverter Options = new StringEnumConverter();

    protected BaseResponse(HttpResponseMessage response, string content)
    {
        Content = content;
        IsSuccessful = response.IsSuccessStatusCode;
        if (!response.IsSuccessStatusCode)
        {
            ProblemDetails = JsonConvert.DeserializeObject<ProblemDetails>(content, Options);
        }
        if (response.Headers.TryGetValues(PtaHeaderNames.AccessToken, out var tokens))
        {
            ActivityToken = tokens.FirstOrDefault();
        }
        if (response.Headers.TryGetValues(PtaHeaderNames.SessionAuth, out var auths))
        {
            SessionAuth = auths.FirstOrDefault();
        }
    }

    public string? Content { get; }
    public string? ActivityToken { get; }
    public string? SessionAuth { get; }
    public bool IsSuccessful { get; }
    public ProblemDetails? ProblemDetails { get; }
}

public class Response(HttpResponseMessage response, string content) : BaseResponse(response, content)
{
}

public class Response<T> : BaseResponse
{
    public Response(HttpResponseMessage response, string content)
        : base(response, content)
    {
        if (response.IsSuccessStatusCode)
        {
            Data = JsonConvert.DeserializeObject<T>(content, Options);
        }
    }

    public T? Data { get; }
}