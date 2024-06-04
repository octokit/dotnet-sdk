using System.Security.Cryptography;
using GitHub.Octokit.Client.Authentication;
using Microsoft.IdentityModel.Tokens;
using Moq;
using Xunit;

public class AppInstallationTokenProviderTests
{
    private readonly Mock<IGitHubAppTokenProvider> _mockGitHubAppTokenProvider;
    private readonly RSA _privateKey;
    private readonly AppInstallationTokenProvider _tokenProvider;

    public AppInstallationTokenProviderTests()
    {
        _mockGitHubAppTokenProvider = new Mock<IGitHubAppTokenProvider>();
        _privateKey = RSA.Create();
        _tokenProvider = new AppInstallationTokenProvider("clientId", _privateKey, "installationId", _mockGitHubAppTokenProvider.Object);
    }

    [Fact]
    public void Constructor_InitializesTokenProviderWithClientId()
    {
        var privateKey = RSA.Create();
        var tokenProvider = new AppInstallationTokenProvider("clientId", privateKey, "installationId", new GitHubAppTokenProvider());

        Assert.NotNull(tokenProvider);
    }

    [Fact]
    public void Constructor_InitializesTokenProviderWithAppId()
    {
        var privateKey = RSA.Create();
        var tokenProvider = new AppInstallationTokenProvider(1, privateKey, "installationId", new GitHubAppTokenProvider());

        Assert.NotNull(tokenProvider);
    }

    [Fact]
    public async Task GetAuthorizationTokenAsync_TokenIsEmpty_FetchesNewToken()
    {
        var requestUri = new Uri("https://api.github.com");
        _mockGitHubAppTokenProvider.Setup(x => x.CreateTokenDescriptor(_privateKey, "clientId", It.IsAny<DateTime>())).Returns(new SecurityTokenDescriptor());
        _mockGitHubAppTokenProvider.Setup(x => x.CreateJsonWebToken(It.IsAny<SecurityTokenDescriptor>())).Returns("mockJwt");
        _mockGitHubAppTokenProvider.Setup(x => x.GetGitHubAccessTokenAsync(It.IsAny<string>(), "mockJwt", "installationId")).ReturnsAsync("newAccessToken");

        var token = await _tokenProvider.GetAuthorizationTokenAsync(requestUri);

        Assert.Equal("newAccessToken", token);
        _mockGitHubAppTokenProvider.Verify(x => x.CreateTokenDescriptor(_privateKey, "clientId", It.IsAny<DateTime>()), Times.Once);
        _mockGitHubAppTokenProvider.Verify(x => x.CreateJsonWebToken(It.IsAny<SecurityTokenDescriptor>()), Times.Once);
        _mockGitHubAppTokenProvider.Verify(x => x.GetGitHubAccessTokenAsync(It.IsAny<string>(), "mockJwt", "installationId"), Times.Once);
    }

    [Fact]
    public async Task GetAuthorizationTokenAsync_TokenIsExpired_FetchesNewToken()
    {
        var requestUri = new Uri("https://api.github.com");
        var expiredTokenDescriptor = new SecurityTokenDescriptor { Expires = DateTime.UtcNow.AddMinutes(-2) };
        var tokenDescriptorField = _tokenProvider.GetType()
            .GetField("_tokenDescriptor", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        if (tokenDescriptorField != null)
        {
            tokenDescriptorField.SetValue(_tokenProvider, expiredTokenDescriptor);
        }
        else
        {
            throw new Exception("Could not find _tokenDescriptor field");
        }

        _mockGitHubAppTokenProvider.Setup(x => x.CreateTokenDescriptor(_privateKey, "clientId", It.IsAny<DateTime>())).Returns(new SecurityTokenDescriptor());
        _mockGitHubAppTokenProvider.Setup(x => x.CreateJsonWebToken(It.IsAny<SecurityTokenDescriptor>())).Returns("mockJwt");
        _mockGitHubAppTokenProvider.Setup(x => x.GetGitHubAccessTokenAsync(It.IsAny<string>(), "mockJwt", "installationId")).ReturnsAsync("newAccessToken");

        var token = await _tokenProvider.GetAuthorizationTokenAsync(requestUri);

        Assert.Equal("newAccessToken", token);
        _mockGitHubAppTokenProvider.Verify(x => x.CreateTokenDescriptor(_privateKey, "clientId", It.IsAny<DateTime>()), Times.Once);
        _mockGitHubAppTokenProvider.Verify(x => x.CreateJsonWebToken(It.IsAny<SecurityTokenDescriptor>()), Times.Once);
        _mockGitHubAppTokenProvider.Verify(x => x.GetGitHubAccessTokenAsync(It.IsAny<string>(), "mockJwt", "installationId"), Times.Once);
    }


    // for more info: https://github.com/octokit/dotnet-sdk/issues/77
    [Fact]
    public async Task GetAuthorizationTokenAsync_TokenIsValid_DoesNotFetchNewToken()
    {
        var requestUri = new Uri("https://api.github.com");
        var validTokenDescriptor = new SecurityTokenDescriptor { Expires = DateTime.UtcNow.AddMinutes(10) };
        var tokenDescriptorField = _tokenProvider.GetType()
            .GetField("_tokenDescriptor", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        if (tokenDescriptorField != null)
        {
            tokenDescriptorField.SetValue(_tokenProvider, validTokenDescriptor);
        }
        else
        {
            throw new Exception("Could not find _tokenDescriptor field");
        }

        var accessTokenField = _tokenProvider.GetType()
            .GetField("_accessToken", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        if (accessTokenField != null)
        {
            accessTokenField.SetValue(_tokenProvider, "existingAccessToken");
        }

        var token = await _tokenProvider.GetAuthorizationTokenAsync(requestUri);

        Assert.Equal("existingAccessToken", token);
        _mockGitHubAppTokenProvider.Verify(x => x.CreateTokenDescriptor(It.IsAny<RSA>(), It.IsAny<string>(), It.IsAny<DateTime>()), Times.Never);
        _mockGitHubAppTokenProvider.Verify(x => x.CreateJsonWebToken(It.IsAny<SecurityTokenDescriptor>()), Times.Never);
        _mockGitHubAppTokenProvider.Verify(x => x.GetGitHubAccessTokenAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
    }
}
