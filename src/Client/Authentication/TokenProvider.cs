using Microsoft.Kiota.Abstractions.Authentication;

namespace GitHub.Octokit.Client.Authentication;
/// <summary>
/// Used for basic token authentication
/// </summary>
public class TokenProvider : IAccessTokenProvider
{
    private readonly string _accessToken;
    AllowedHostsValidator IAccessTokenProvider.AllowedHostsValidator => new AllowedHostsValidator();

    /// <summary>
    /// Constructor for TokenProvider using the access token
    /// </summary>
    /// <param name="accessToken"></param>
    /// <exception cref="ArgumentException"></exception>
    public TokenProvider(string accessToken)
    {
        if (string.IsNullOrEmpty(accessToken)) throw new ArgumentException(nameof(accessToken));
        _accessToken = accessToken;
    }

    /// <summary>
    /// Get the authorization token
    /// </summary>
    /// <param name="requestUri"></param>
    /// <param name="additionalAuthenticationContext"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<string> GetAuthorizationTokenAsync(Uri requestUri, Dictionary<string, object>? additionalAuthenticationContext = default, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_accessToken);
    }
}
