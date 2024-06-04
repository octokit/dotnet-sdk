// Copyright (c) GitHub 2023-2024 - Licensed as MIT.

using GitHub.Octokit.Client;
using GitHub.Octokit.Client.Authentication;
using Microsoft.Kiota.Abstractions.Authentication;
using Xunit;

public class RequestAdapterTests
{
    private TokenProvider _tokenProvider = new TokenProvider("JRRTOLKIEN");

    [Fact]
    public void Setup()
    {
        _tokenProvider = new TokenProvider("JRRTOLKIEN");
    }

    [Fact]
    public void Creates_RequestAdaptor_With_Defaults()
    {
        var requestAdapter = RequestAdapter.Create(new BaseBearerTokenAuthenticationProvider(_tokenProvider));
        Assert.NotNull(requestAdapter);
    }

    [Fact]
    public void Creates_RequestAdaptor_With_GenericHttpClient()
    {
        var httpClient = new HttpClient();
        var requestAdapter = RequestAdapter.Create(new BaseBearerTokenAuthenticationProvider(_tokenProvider), httpClient);
        Assert.NotNull(requestAdapter);
    }

    [Fact]
    public void Creates_RequestAdaptor_With_ClientFactory()
    {
        var clientFactory = ClientFactory.Create();
        var requestAdapter = RequestAdapter.Create(new BaseBearerTokenAuthenticationProvider(_tokenProvider), clientFactory);
        Assert.NotNull(requestAdapter);
    }
}
