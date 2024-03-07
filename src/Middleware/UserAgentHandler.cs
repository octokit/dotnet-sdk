// Copyright (c) GitHub 2023-2024 - Licensed as MIT.

using System.Net.Http.Headers;
using GitHub.Octokit.Client.Middleware.Options;
using Microsoft.Kiota.Http.HttpClientLibrary.Extensions;

namespace GitHub.Octokit.Client.Middleware;

public class UserAgentHandler(UserAgentOptions? userAgentHandlerOption = null) : DelegatingHandler
{
    private readonly UserAgentOptions _userAgentOption = userAgentHandlerOption ?? new UserAgentOptions();

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var userAgentHandlerOption = request.GetRequestOption<UserAgentOptions>() ?? _userAgentOption;

        if (!request.Headers.UserAgent.Any(x => userAgentHandlerOption.ProductName.Equals(x.Product?.Name, StringComparison.OrdinalIgnoreCase)))
        {
            request.Headers.UserAgent.Add(new ProductInfoHeaderValue(userAgentHandlerOption.ProductName, userAgentHandlerOption.ProductVersion));
        }
        return base.SendAsync(request, cancellationToken);
    }
}
