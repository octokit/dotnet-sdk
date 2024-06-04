// Copyright (c) GitHub 2023-2024 - Licensed as MIT.

using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Kiota.Abstractions.Authentication;

namespace GitHub.Octokit.Client.Authentication;

/// <summary>
/// Used for Github App InstallationToken authentication
/// </summary>
public class AppInstallationTokenProvider : IAccessTokenProvider
{
    private readonly string _sourceId;
    private readonly RSA _privateKey;
    private readonly string _installationId;
    private string _accessToken = string.Empty;

    private SecurityTokenDescriptor? _tokenDescriptor;

    private IGitHubAppTokenProvider _gitHubAppTokenProvider;

    AllowedHostsValidator IAccessTokenProvider.AllowedHostsValidator => new AllowedHostsValidator();

    /// <summary>
    /// Constructor for AppInstallationTokenProvider using the clientId
    /// </summary>
    /// <param name="clientId"></param>
    /// <param name="privateKey"></param>
    /// <param name="installationId"></param>
    public AppInstallationTokenProvider(string clientId, RSA privateKey, string installationId, IGitHubAppTokenProvider githubAppTokenProvider)
    {
        _sourceId = clientId;
        _privateKey = privateKey;
        _installationId = installationId;
        _gitHubAppTokenProvider = githubAppTokenProvider;
    }

    /// <summary>
    /// Constructor for AppInstallationTokenProvider using the appId
    /// </summary>
    /// <param name="appId"></param>
    /// <param name="privateKey"></param>
    /// <param name="installationId"></param>
    public AppInstallationTokenProvider(int appId, RSA privateKey, string installationId, IGitHubAppTokenProvider githubAppTokenProvider)
    {
        _sourceId = appId.ToString();
        _privateKey = privateKey;
        _installationId = installationId;
        _gitHubAppTokenProvider = githubAppTokenProvider;
    }

    /// <summary>
    /// Get the authorization token
    /// </summary>
    /// <param name="requestUri"></param>
    /// <param name="additionalAuthenticationContext"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<string> GetAuthorizationTokenAsync(Uri requestUri, Dictionary<string, object>? additionalAuthenticationContext = default, CancellationToken cancellationToken = default)
    {
        /// If the token is empty, about to be expired, or has expired - get a new one
        if (string.IsNullOrEmpty(_accessToken) || (_tokenDescriptor != null && _tokenDescriptor.Expires < DateTime.UtcNow.AddMinutes(-1)))
        {
            var baseUrl = requestUri.GetLeftPart(UriPartial.Authority);

            _tokenDescriptor = _gitHubAppTokenProvider.CreateTokenDescriptor(_privateKey, _sourceId, DateTime.UtcNow);
            var jwt = _gitHubAppTokenProvider.CreateJsonWebToken(_tokenDescriptor);
            _accessToken = await _gitHubAppTokenProvider.GetGitHubAccessTokenAsync(baseUrl, jwt, _installationId);
        }

        return _accessToken;
    }
}
