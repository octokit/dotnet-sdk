// Copyright (c) GitHub 2023-2024 - Licensed as MIT.

using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text.Json;
using GitHub.App.Installations.Item.Access_tokens;
using GitHub.Octokit.Client.Middleware.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;

namespace GitHub.Octokit.Client.Authentication;

public class AppInstallationTokenAuthProvider : IAppInstallationTokenAuthProvider
{
  private const string AuthorizationHeaderKey = "Authorization";
  private string AppInstallationToken { get; set; } = string.Empty;

  public IAppInstallationTokenAuthProvider TokenProvider => this;

  public AppInstallationTokenAuthProvider(string privateKeyPath, string clientId, int installationId)
  {
    ArgumentNullException.ThrowIfNull(privateKeyPath);
    ArgumentNullException.ThrowIfNull(clientId);

    var jwtToken = CreateJsonWebToken(clientId, privateKeyPath);
    var accessToken = GetAppInstallationAccessTokenAsync(jwtToken, installationId).Result;

    AppInstallationToken = accessToken ?? throw new Exception("Failed to get token");

  }

  public Task AuthenticateRequestAsync(RequestInformation? request, Dictionary<string, object>? additionalAuthenticationContext = null, CancellationToken cancellationToken = default)
  {
    ArgumentNullException.ThrowIfNull(request);
    ArgumentException.ThrowIfNullOrEmpty(AppInstallationToken);

    request.Headers.TryGetValue(AuthorizationHeaderKey, out var authHeader);

    // We want to compare the token in the request with the token we have
    // Always use this.AppInstallationToken if it's different from what is in the header
    if (AppInstallationToken != authHeader.ToString())
    {
      request.Headers.Add(AuthorizationHeaderKey, $"Bearer {AppInstallationToken}");
    }

    return Task.CompletedTask;
  }

  // TODO: abstract this out 
  public async Task<string?> GetAppInstallationAccessTokenAsync(string jwtToken, int installationId)
  {

    ArgumentNullException.ThrowIfNull(jwtToken);

    // TODO: this will not work due to the singleton aspect of the client and 
    // the fact that when setting middleware and options the instance of the 
    // client has already stated another request
    var adapter = RequestAdapter.Create(new TokenAuthProvider(jwtToken));
    var ghClient = new GitHubClient(adapter);
    var response = await ghClient.App.Installations[installationId]
      .Access_tokens.PostAsync(new Access_tokensPostRequestBody(), null, default);
    var token = response?.Token;

    return token;
  }

  // TODO: abstract this out 
  public Task<string> RefreshAppInstallationAccessTokenAsync(int installationId) => throw new NotImplementedException();

  // TODO: abstract this out 
  private string CreateJsonWebToken(string clientId, string privateKey)
  {
    var privateKeyContent = File.ReadAllText(privateKey);
    var rsa = RSA.Create();
    rsa.ImportFromPem(privateKeyContent);

    var now = DateTimeOffset.Now;
    var tokenDescriptor = new SecurityTokenDescriptor
    {
      Issuer = clientId,
      IssuedAt = now.UtcDateTime,
      NotBefore = now.UtcDateTime,
      Expires = now.AddMinutes(10).UtcDateTime,
      SigningCredentials = new(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256)
    };

    return new JsonWebTokenHandler().CreateToken(tokenDescriptor);
  }
}
