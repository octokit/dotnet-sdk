using System.Security.Cryptography;
using GitHub.Octokit.Client.Authentication;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Xunit;

public class AccessTokenProviderTests
{

    [Fact]
    public void CreateJsonWebToken_ReturnsValidToken()
    {
        var privateKey = RSA.Create();
        var sourceId = "example-source-id";
        var tokenDescriptor = AccessTokenProvider.CreateTokenDescriptor(privateKey, sourceId, DateTime.UtcNow);
        var token = AccessTokenProvider.CreateJsonWebToken(tokenDescriptor);

        Assert.NotNull(token);
    }

    [Fact]
    public void CreateTokenDescriptor_ReturnsValidDescriptor()
    {

        var privateKey = RSA.Create();
        var sourceId = "example-source-id";
        var now = DateTime.UtcNow;
        var tokenDescriptor = AccessTokenProvider.CreateTokenDescriptor(privateKey, sourceId, now);

        Assert.Equal(sourceId, tokenDescriptor.Issuer);
        Assert.Equal(now, tokenDescriptor.IssuedAt);
        Assert.Equal(now, tokenDescriptor.NotBefore);
        Assert.Equal(now.AddMinutes(10), tokenDescriptor.Expires);
        Assert.IsType<SigningCredentials>(tokenDescriptor.SigningCredentials);
        Assert.Equal(sourceId, tokenDescriptor.Claims[JwtRegisteredClaimNames.Iss]);
    }
}
