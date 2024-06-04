// Copyright (c) GitHub 2023-2024 - Licensed as MIT.

using GitHub.Octokit.Client.Middleware.Options;
using Microsoft.Kiota.Http.HttpClientLibrary.Extensions;

namespace GitHub.Octokit.Client.Middleware;

/// <summary>
/// Represents a handler that adds the API version header to outgoing HTTP requests.
/// </summary>
public class APIVersionHandler(APIVersionOptions? apiVersionOptions = null) : DelegatingHandler
{
    private const string ApiVersionHeaderKey = "X-GitHub-Api-Version";

    private readonly APIVersionOptions _apiVersionOptions = apiVersionOptions ?? new APIVersionOptions();

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var apiVersionHandlerOption = request.GetRequestOption<APIVersionOptions>() ?? _apiVersionOptions;

        if (!request.Headers.Contains(ApiVersionHeaderKey) || !request.Headers.GetValues(ApiVersionHeaderKey).Any(x => APIVersionOptions.APIVersion.Equals(x, StringComparison.OrdinalIgnoreCase)))
        {
            request.Headers.Add(ApiVersionHeaderKey, APIVersionOptions.APIVersion);
        }

        return base.SendAsync(request, cancellationToken);
    }
}
