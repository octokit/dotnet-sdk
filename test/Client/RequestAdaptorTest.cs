// Copyright (c) GitHub 2023-2024 - Licensed as MIT.

using GitHub.Octokit.Authentication;
using GitHub.Octokit.Client;
using Xunit;

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
