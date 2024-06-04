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
public class GitHubAppTokenProvider : IGitHubAppTokenProvider
{
    private const int _timeoutMinutes = 10;

    /// <summary>
    /// Create a token descriptor
    /// We want to store the descriptor so that we can automatically refresh the token before it expires
    /// </summary>
    /// <param name="privateKey"></param>
    /// <param name="sourceId"></param>
    /// <param name="issuedAt"></param>
    public SecurityTokenDescriptor CreateTokenDescriptor(RSA privateKey, string sourceId, DateTime issuedAt)
    {
        var signingCredentials = new SigningCredentials(new RsaSecurityKey(privateKey), SecurityAlgorithms.RsaSha256);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = sourceId,
            IssuedAt = issuedAt,
            NotBefore = issuedAt,
            Expires = issuedAt.AddMinutes(_timeoutMinutes),
            SigningCredentials = signingCredentials,
            Claims = new Dictionary<string, object>
          {
              { JwtRegisteredClaimNames.Iat, new DateTimeOffset(issuedAt).ToUnixTimeSeconds() },
              { JwtRegisteredClaimNames.Exp, new DateTimeOffset(issuedAt.AddMinutes(_timeoutMinutes)).ToUnixTimeSeconds() },
              { JwtRegisteredClaimNames.Iss, sourceId }
          }
        };
        return tokenDescriptor;
    }

    public string CreateJsonWebToken(SecurityTokenDescriptor tokenDescriptor)
    {
        var tokenHandler = new JsonWebTokenHandler();
        return tokenHandler.CreateToken(tokenDescriptor);
    }

    /// <summary>
    /// Get the app installation access token from GitHub
    /// </summary>
    /// <param name="baseUrl"></param>
    /// <param name="jwt"></param>
    /// <param name="installationId"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<string> GetGitHubAccessTokenAsync(string baseUrl, string jwt, string installationId)
    {
        using var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, $"{baseUrl}/app/installations/{installationId}/access_tokens");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));

        var userAgentOptions = new UserAgentOptions();
        request.Headers.UserAgent.Add(new ProductInfoHeaderValue(userAgentOptions.ProductName, userAgentOptions.ProductVersion));

        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var doc = JsonDocument.Parse(json);
        var token = doc.RootElement.GetProperty("token").GetString();

        return token ?? throw new Exception("Failed to get access token");
    }
}
