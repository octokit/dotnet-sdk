using Xunit;
using Moq;
using System.Security.Cryptography;
using GitHub.Octokit.Client.Authentication;

public class AppInstallationTokenProviderTests
{
  private readonly Mock<RSA> _mockPrivateKey;
  private readonly AppInstallationTokenProvider _provider;

  public AppInstallationTokenProviderTests()
  {
    _mockPrivateKey = new Mock<RSA>();
    _provider = new AppInstallationTokenProvider("clientId", _mockPrivateKey.Object, "installationId");
  }

  // TODO: Implement tests
  // [Fact]
  // public async Task GetAuthorizationTokenAsync_WhenCalled_ReturnsToken()
  // {
  //   var requestUri = new Uri("https://api.github.com");
  //   var result = await _provider.GetAuthorizationTokenAsync(requestUri);

  //   Assert.NotNull(result);
  //   Assert.IsType<string>(result);
  // }
}