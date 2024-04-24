// Copyright (c) GitHub 2023-2024 - Licensed as MIT.

using GitHub.Octokit.Client;
using GitHub.Octokit.Client.Middleware;
using Xunit;

public class TestHandler1 : DelegatingHandler { }
public class TestHandler2 : DelegatingHandler { }

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

    [Fact]
    public void Create_Returns_NonNullHttpClient()
    {
        HttpMessageHandler handler = new HttpClientHandler();
        var client = ClientFactory.Create(handler);
        Assert.NotNull(client);
    }

    [Fact]
    public void CreateDefaultHandlers_Returns_Expected_Handlers()
    {
        var handlers = ClientFactory.CreateDefaultHandlers();
        Assert.Contains(handlers, h => h is APIVersionHandler);
        Assert.Contains(handlers, h => h is UserAgentHandler);
        Assert.Contains(handlers, h => h is RateLimitHandler);

        // Assert that the Kiota retry handler and redirect handler are present as well
        Assert.Contains(handlers, h => h is Microsoft.Kiota.Http.HttpClientLibrary.Middleware.RetryHandler);
        Assert.Contains(handlers, h => h is Microsoft.Kiota.Http.HttpClientLibrary.Middleware.RedirectHandler);
    }

    [Fact]
    public void ChainHandlersCollectionAndGetFirstLink_ChainsHandlersCorrectly()
    {
        var handlers = new DelegatingHandler[]
        {
            new TestHandler1(),
            new TestHandler2()
        };
        var firstHandler = ClientFactory.ChainHandlersCollectionAndGetFirstLink(null, handlers);
        Assert.IsType<TestHandler1>(firstHandler);
        Assert.IsType<TestHandler2>(firstHandler.InnerHandler);
    }

    [Fact]
    public void GetDefaultHttpMessageHandler_Returns_NonNullHttpMessageHandler()
    {
        var handler = ClientFactory.GetDefaultHttpMessageHandler();
        Assert.NotNull(handler);
    }
}
