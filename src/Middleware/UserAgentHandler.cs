// Copyright (c) GitHub 2023-2024 - Licensed as MIT.

using System.Net.Http.Headers;
using GitHub.Octokit.Client.Middleware.Options;
using Microsoft.Kiota.Http.HttpClientLibrary.Extensions;

namespace GitHub.Octokit.Client.Middleware;

/// <summary>
/// A handler to add or update the User-Agent header in HTTP requests.
/// </summary>
/// <param name="userAgentHandlerOption">The user agent options to use for the handler.</param>
public sealed class UserAgentHandler(UserAgentOptions? userAgentHandlerOption = null) : DelegatingHandler
{
    private readonly UserAgentOptions _userAgentOption = userAgentHandlerOption ?? new UserAgentOptions();

    /// <summary>
    /// Sends an HTTP request to the inner handler to send to the server as an asynchronous operation.
    /// </summary>
    /// <param name="request">The HTTP request message to send to the server.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the request is null.</exception>
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var userAgentHandlerOption = request.GetRequestOption<UserAgentOptions>() ?? _userAgentOption;

        if (!request.Headers.UserAgent.Any(x => userAgentHandlerOption.ProductName != null && userAgentHandlerOption.ProductName.Equals(x.Product?.Name, StringComparison.OrdinalIgnoreCase)))
        {
            request.Headers.UserAgent.Add(new ProductInfoHeaderValue(userAgentHandlerOption.ProductName ?? string.Empty, userAgentHandlerOption.ProductVersion));
        }

        return base.SendAsync(request, cancellationToken);
    }
}
