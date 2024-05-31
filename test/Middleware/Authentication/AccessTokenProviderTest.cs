using System.Security.Cryptography;
using GitHub.Octokit.Client.Authentication;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Xunit;

public class GitHubAppTokenProviderTests
{
    [Fact]
    public void CreateJsonWebToken_ReturnsValidToken()
    {
        var githubAppTokenProvider = new GitHubAppTokenProvider();
        var privateKey = RSA.Create();
        var sourceId = "example-source-id";
        var tokenDescriptor = githubAppTokenProvider.CreateTokenDescriptor(privateKey, sourceId, DateTime.UtcNow);
        var token = githubAppTokenProvider.CreateJsonWebToken(tokenDescriptor);

        Assert.NotNull(token);
    }

    [Fact]
    public void CreateTokenDescriptor_ReturnsValidDescriptor()
    {
        var githubAppTokenProvider = new GitHubAppTokenProvider();
        var privateKey = RSA.Create();
        var sourceId = "example-source-id";
        var now = DateTime.UtcNow;
        var tokenDescriptor = githubAppTokenProvider.CreateTokenDescriptor(privateKey, sourceId, now);

        Assert.Equal(sourceId, tokenDescriptor.Issuer);
        Assert.Equal(now, tokenDescriptor.IssuedAt);
        Assert.Equal(now, tokenDescriptor.NotBefore);
        Assert.Equal(now.AddMinutes(10), tokenDescriptor.Expires);
        Assert.IsType<SigningCredentials>(tokenDescriptor.SigningCredentials);
        Assert.Equal(sourceId, tokenDescriptor.Claims[JwtRegisteredClaimNames.Iss]);
    }
}
