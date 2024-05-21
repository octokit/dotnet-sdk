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
    private readonly string _appId;
    private readonly RSA _privateKeyPath;
    private readonly string _installationId;
    private string _accessToken = string.Empty;
    AllowedHostsValidator IAccessTokenProvider.AllowedHostsValidator => new AllowedHostsValidator();

    public AppInstallationTokenProvider(string appId, RSA privateKeyPath, string installationId)
    {
        _appId = appId;
        _privateKeyPath = privateKeyPath;
        _installationId = installationId;
    }
    public async Task<string> GetAuthorizationTokenAsync(Uri requestUri, Dictionary<string, object>? additionalAuthenticationContext = default, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(_accessToken))
        {
            var jwt = CreateJsonWebToken(_appId, _privateKeyPath);
            _accessToken = await GetGitHubAccessTokenAsync(jwt, _installationId);
        }

        return _accessToken;
    }

    // TODO: abstract this out 
    public Task<string> RefreshAppInstallationAccessTokenAsync(int installationId) => throw new NotImplementedException();

    // TODO: abstract this out 
    // Come up with a way to pass base URL
    private async Task<string> GetGitHubAccessTokenAsync(string jwt, string installationId)
    {
        using var client = new HttpClient();

        var baseUrl = "https://api.github.com";

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
    private string CreateJsonWebToken(string clientId, RSA privateKey)
    {
        var now = DateTime.UtcNow;
        var tokenHandler = new JsonWebTokenHandler();
        var signingCredentials = new SigningCredentials(new RsaSecurityKey(privateKey), SecurityAlgorithms.RsaSha256);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = clientId,
            IssuedAt = now,
            NotBefore = now,
            Expires = now.AddMinutes(10),
            SigningCredentials = signingCredentials,
            Claims = new Dictionary<string, object>
          {
              { "iat", new DateTimeOffset(now).ToUnixTimeSeconds() },
              { "exp", new DateTimeOffset(now.AddMinutes(10)).ToUnixTimeSeconds() },
              { "iss", clientId }
          }
        };

        return tokenHandler.CreateToken(tokenDescriptor);
    }

}
