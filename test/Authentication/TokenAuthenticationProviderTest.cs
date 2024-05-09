// Copyright (c) GitHub 2023-2024 - Licensed as MIT.

using GitHub.Octokit.Authentication;
using Microsoft.Kiota.Abstractions;
using Xunit;

public class TokenAuthenticationProviderTests
{
    private const string ValidToken = "validToken";
    private TokenAuthenticationProvider _provider;

    public TokenAuthenticationProviderTests()
    {
        _provider = new TokenAuthenticationProvider(ValidToken);
    }

    [Fact]
    public void Constructor_ThrowsException_WhenTokenIsEmpty()
    {
        Assert.Throws<ArgumentException>(() => new TokenAuthenticationProvider(""));
    }

    [Fact]
    public async Task AuthenticateRequestAsync_ThrowsException_WhenRequestIsNull()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => _provider.AuthenticateRequestAsync(null, null));
    }

    [Fact]
    public async Task AuthenticateRequestAsync_AddsAuthorizationHeader_WhenRequestIsValid()
    {
        var request = new RequestInformation();
        await _provider.AuthenticateRequestAsync(request);
        var headerToken = request.Headers["Authorization"].FirstOrDefault<string>();

        Assert.True(request.Headers.ContainsKey("Authorization"));
        Assert.Equal($"Bearer {ValidToken}", headerToken);
    }
}
