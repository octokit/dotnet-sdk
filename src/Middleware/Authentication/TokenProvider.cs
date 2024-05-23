using Microsoft.Kiota.Abstractions.Authentication;

namespace GitHub.Octokit.Client.Authentication;
/// <summary>
/// Used for basic token authentication
/// </summary>
public class TokenProvider : IAccessTokenProvider
{
    private readonly string _accessToken;
    AllowedHostsValidator IAccessTokenProvider.AllowedHostsValidator => new AllowedHostsValidator();

    public TokenProvider(string accessToken)
    {
        if (string.IsNullOrEmpty(accessToken)) throw new ArgumentException(nameof(accessToken));
        _accessToken = accessToken;
    }

    public Task<string> GetAuthorizationTokenAsync(Uri requestUri, Dictionary<string, object>? additionalAuthenticationContext = default, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_accessToken);
    }
}
