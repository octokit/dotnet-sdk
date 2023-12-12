using System.Net.Http.Headers;
using GitHub.Client.Middleware.Options;
using Microsoft.Kiota.Http.HttpClientLibrary.Extensions;


namespace GitHub.Client.Middleware;

public class UserAgentHandler : DelegatingHandler
{
    private readonly UserAgentOptions _userAgentOption;

    public UserAgentHandler(UserAgentOptions? userAgentHandlerOption = null)
    {
        _userAgentOption = userAgentHandlerOption ?? new UserAgentOptions();
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if(request == null)
            throw new ArgumentNullException(nameof(request));

        var userAgentHandlerOption = request.GetRequestOption<UserAgentOptions>() ?? _userAgentOption;

        if(!request.Headers.UserAgent.Any(x => userAgentHandlerOption.ProductName.Equals(x.Product?.Name, StringComparison.OrdinalIgnoreCase)))
        {
            request.Headers.UserAgent.Add(new ProductInfoHeaderValue(userAgentHandlerOption.ProductName, userAgentHandlerOption.ProductVersion));
        }
        return base.SendAsync(request, cancellationToken);
    }
}
