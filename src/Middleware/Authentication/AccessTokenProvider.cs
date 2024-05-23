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
public class AccessTokenProvider
{
    private const int _timeoutMinuites = 10;

    public static string CreateJsonWebToken(SecurityTokenDescriptor tokenDescriptor)
    {
        var tokenHandler = new JsonWebTokenHandler();
        return tokenHandler.CreateToken(tokenDescriptor);
    }

    public static async Task<string> GetGitHubAccessTokenAsync(string baseUrl, string jwt, string installationId)
    {
        using var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, $"{baseUrl}/app/installations/{installationId}/access_tokens");

        // This need to be refactored
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

    /// <summary>
    /// Create a token descriptor
    /// We want to store the descriptor so that we can automatically refresh the token before it expires
    /// </summary>
    /// <param name="credentials"></param>
    /// <param name="now"></param>
    public static SecurityTokenDescriptor CreateTokenDescriptor(RSA privateKey, string sourceId)
    {
        var now = DateTime.UtcNow;
        var signingCredentials = new SigningCredentials(new RsaSecurityKey(privateKey), SecurityAlgorithms.RsaSha256);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = sourceId,
            IssuedAt = now,
            NotBefore = now,
            Expires = now.AddMinutes(_timeoutMinuites),
            SigningCredentials = signingCredentials,
            Claims = new Dictionary<string, object>
          {
              { JwtRegisteredClaimNames.Iat, new DateTimeOffset(now).ToUnixTimeSeconds() },
              { JwtRegisteredClaimNames.Exp, new DateTimeOffset(now.AddMinutes(_timeoutMinuites)).ToUnixTimeSeconds() },
              { JwtRegisteredClaimNames.Iss, sourceId }
          }
        };
        return tokenDescriptor;
    }
}
