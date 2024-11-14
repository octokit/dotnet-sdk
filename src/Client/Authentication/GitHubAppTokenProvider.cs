using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text.Json;
using GitHub.Octokit.Client.Middleware.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace GitHub.Octokit.Client.Authentication;

/// <summary>
/// This class is responsible for creating, signing and refreshing access tokens
/// </summary>
public sealed class GitHubAppTokenProvider : IGitHubAppTokenProvider
{
    private const int TimeoutMinutes = 10;

    /// <summary>
    /// Create a token descriptor
    /// We want to store the descriptor so that we can automatically refresh the token before it expires
    /// </summary>
    /// <param name="privateKey">The private key belonging to the GitHub App.</param>
    /// <param name="sourceId">The issuer for the token descriptor claims.</param>
    /// <param name="issuedAt">The DateTime for the token descriptor to be issued at.</param>
    /// <returns>A token descriptor that can be used to create a JWT.</returns>
    public SecurityTokenDescriptor CreateTokenDescriptor(RSA privateKey, string sourceId, DateTime issuedAt)
    {
        var signingCredentials = new SigningCredentials(new RsaSecurityKey(privateKey), SecurityAlgorithms.RsaSha256);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = sourceId,
            IssuedAt = issuedAt,
            NotBefore = issuedAt,
            Expires = issuedAt.AddMinutes(TimeoutMinutes),
            SigningCredentials = signingCredentials,
            Claims = new Dictionary<string, object>
          {
              { JwtRegisteredClaimNames.Iat, new DateTimeOffset(issuedAt).ToUnixTimeSeconds() },
              { JwtRegisteredClaimNames.Exp, new DateTimeOffset(issuedAt.AddMinutes(TimeoutMinutes)).ToUnixTimeSeconds() },
              { JwtRegisteredClaimNames.Iss, sourceId }
          }
        };

        return tokenDescriptor;
    }

    /// <summary>
    /// Creates a JWT using the given token descriptor. This JWT can be used to authenticate to the endpoints
    /// requiring the App to authenticate as itself.
    /// </summary>
    /// <param name="tokenDescriptor">The token descriptor to use when creating the JWT.</param>
    /// <returns>A JWT string that can be used for authentication.</returns>
    public string CreateJsonWebToken(SecurityTokenDescriptor tokenDescriptor)
    {
        var tokenHandler = new JsonWebTokenHandler();
        return tokenHandler.CreateToken(tokenDescriptor);
    }

    /// <summary>
    /// Get the app installation access token from GitHub
    /// </summary>
    /// <param name="baseUrl">The base URL of the GitHub API.</param>
    /// <param name="jwt">The JSON Web Token for authentication.</param>
    /// <param name="installationId">The installation ID of the GitHub App.</param>
    /// <returns>An access token that can be used to authenticate to the GitHub API as an App installation.</returns>
    /// <exception cref="Exception">Thrown when the access token cannot be retrieved.</exception>
    public async Task<string> GetGitHubAccessTokenAsync(string baseUrl, string jwt, string installationId)
    {
        using var client = new HttpClient();
        using var request = new HttpRequestMessage(HttpMethod.Post, $"{baseUrl}/app/installations/{installationId}/access_tokens");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));

        var userAgentOptions = new UserAgentOptions();
        request.Headers.UserAgent.Add(new ProductInfoHeaderValue(userAgentOptions.ProductName ?? string.Empty, userAgentOptions.ProductVersion));

        using var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(json);
        var token = doc.RootElement.GetProperty("token").GetString();

        return token ?? throw new Exception("Failed to get access token");
    }
}
