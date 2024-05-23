// Copyright (c) GitHub 2023-2024 - Licensed as MIT.

using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text.Json;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Kiota.Abstractions.Authentication;

namespace GitHub.Octokit.Client.Authentication;

public class AppInstallationTokenProvider : IAccessTokenProvider
{

    private int _timeoutMinuites = 10;

    private readonly string _sourceId;
    private readonly RSA _privateKeyPath;
    private readonly string _installationId;
    private string _accessToken = string.Empty;

    private SecurityTokenDescriptor? _tokenDescriptor;

    AllowedHostsValidator IAccessTokenProvider.AllowedHostsValidator => new AllowedHostsValidator();

    public AppInstallationTokenProvider(int appId, RSA privateKeyPath, string installationId)
    {
        _sourceId = appId.ToString();
        _privateKeyPath = privateKeyPath;
        _installationId = installationId;
    }

    public AppInstallationTokenProvider(string clientId, RSA privateKeyPath, string installationId)
    {
        _sourceId = clientId;
        _privateKeyPath = privateKeyPath;
        _installationId = installationId;
    }

    public async Task<string> GetAuthorizationTokenAsync(Uri requestUri, Dictionary<string, object>? additionalAuthenticationContext = default, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(_accessToken) || (_tokenDescriptor != null && _tokenDescriptor.Expires < DateTime.UtcNow.AddMinutes(-1)))
        {
            var jwt = CreateJsonWebToken(_privateKeyPath);
            var baseUrl = requestUri.GetLeftPart(UriPartial.Authority);

            _accessToken = await GetGitHubAccessTokenAsync(baseUrl, jwt, _installationId);
        }

        return _accessToken;
    }

    // TODO: abstract this out 
    private async Task<string> GetGitHubAccessTokenAsync(string baseUrl, string jwt, string installationId)
    {
        using var client = new HttpClient();

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

        var request = new HttpRequestMessage(HttpMethod.Post, $"{baseUrl}/app/installations/{installationId}/access_tokens");
        request.Headers.Add("Accept", "application/vnd.github.v3+json");
        request.Headers.Add("User-Agent", "YourAppName");

        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var doc = JsonDocument.Parse(json);
        var token = doc.RootElement.GetProperty("token").GetString();

        return token ?? throw new Exception("Failed to get token");
    }

    // TODO: abstract this out 
    private string CreateJsonWebToken(RSA privateKey)
    {
        var now = DateTime.UtcNow;
        var tokenHandler = new JsonWebTokenHandler();
        var signingCredentials = new SigningCredentials(new RsaSecurityKey(privateKey), SecurityAlgorithms.RsaSha256);

        CreateTokenDescriptor(signingCredentials, now);

        return tokenHandler.CreateToken(_tokenDescriptor);
    }

    private void CreateTokenDescriptor(SigningCredentials credentials, DateTime now)
    {
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _sourceId,
            IssuedAt = now,
            NotBefore = now,
            Expires = now.AddMilliseconds(_timeoutMinuites),
            SigningCredentials = credentials,
            Claims = new Dictionary<string, object>
          {
              { "iat", new DateTimeOffset(now).ToUnixTimeSeconds() },
              { "exp", new DateTimeOffset(now.AddMilliseconds(_timeoutMinuites)).ToUnixTimeSeconds() },
              { "iss", _sourceId }
          }
        };
        _tokenDescriptor = tokenDescriptor;
    }


}
