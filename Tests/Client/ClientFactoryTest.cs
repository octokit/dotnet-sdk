using Xunit;
using GitHub.Octokit.Client;

public class ClientFactoryTests
{

  [Fact]
  public void Creates_Client_With_Default_Timeout()
  {
    var clientFactory = ClientFactory.Create();
    Assert.Equal(TimeSpan.FromSeconds(100), clientFactory.Timeout);
  }

  [Fact]
  public void Creates_Client_Persists_Set_Timeout()
  {
    var clientFactory = ClientFactory.Create();
    clientFactory.Timeout = TimeSpan.FromSeconds(5);
    Assert.Equal(TimeSpan.FromSeconds(5), clientFactory.Timeout);
  }

}