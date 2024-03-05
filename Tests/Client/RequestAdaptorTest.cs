using GitHub.Octokit.Authentication;
using GitHub.Octokit.Client;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;
using Xunit;
using Moq;

public class RequestAdapterTests
{

    [Fact]
    public void Creates_RequestAdaptor_With_Defaults()
    {
        var requestAdapter = RequestAdapter.Create(new TokenAuthenticationProvider("Octokit.Gen", "JRRTOLKIEN"));
        Assert.NotNull(requestAdapter);
    }

    [Fact]
    public void Creates_RequestAdaptor_With_GenericHttpClient()
    {
        var httpClient = new HttpClient();
        var requestAdapter = RequestAdapter.Create(new TokenAuthenticationProvider("Octokit.Gen", "JRRTOLKIEN"), httpClient);
        Assert.NotNull(requestAdapter);
    }

    [Fact]
    public void Creates_RequestAdaptor_With_ClientFactory()
    {
        var clientFactory = ClientFactory.Create();
        var requestAdapter = RequestAdapter.Create(new TokenAuthenticationProvider("Octokit.Gen", "JRRTOLKIEN"), clientFactory);
        Assert.NotNull(requestAdapter);
    }

}
