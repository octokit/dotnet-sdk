using GitHub.Octokit.Client.Authentication;
using Microsoft.Kiota.Abstractions.Authentication;
using Moq;
using Xunit;

public class AppInstallationAuthProviderTests
{
    [Fact]
    public void Constructor_InitializesTokenProvider()
    {
        var tokenProviderMock = new Mock<IAccessTokenProvider>();
        var authProvider = new AppInstallationAuthProvider(tokenProviderMock.Object);

        Assert.NotNull(authProvider.AccessTokenProvider);
        Assert.Same(tokenProviderMock.Object, authProvider.AccessTokenProvider);
    }
}
