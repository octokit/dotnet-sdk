using System.Security.Cryptography;
using GitHub.Octokit.Client.Authentication;
using Xunit;

public class AppInstallationTokenProviderTests
{
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
}
