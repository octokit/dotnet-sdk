// Copyright (c) GitHub 2023-2024 - Licensed as MIT.

using System.Net;
using GitHub.Octokit.Client.Middleware;
using Microsoft.Kiota.Http.HttpClientLibrary;

namespace GitHub.Octokit.Client;

/// <summary>
/// Represents a client factory for creating <see cref="HttpClient"/>.
/// </summary>
public static class ClientFactory
{
    private static readonly Lazy<List<DelegatingHandler>> s_handlers =
        new(() =>
        [
            new APIVersionHandler(),
            new UserAgentHandler(),
            new RateLimitHandler(),
        ]);

    /// <summary>
    /// Creates an <see cref="HttpClient"/> instance with the specified <see cref="HttpMessageHandler"/>.
    /// If no <see cref="HttpMessageHandler"/> is provided, a default one will be used.
    /// </summary>
    /// <param name="finalHandler">The final <see cref="HttpMessageHandler"/> in the chain.</param>
    /// <returns>An instance of <see cref="HttpClient"/>.</returns>
    public static HttpClient Create(HttpMessageHandler? finalHandler = null)
    {
        var defaultHandlers = CreateDefaultHandlers();

        var handler = ChainHandlersCollectionAndGetFirstLink(
            finalHandler: finalHandler ?? GetDefaultHttpMessageHandler(),
            handlers: [.. defaultHandlers]);

        return handler is not null ? new HttpClient(handler) : new HttpClient();
    }

    /// <summary>
    /// Creates a list of default delegating handlers for the Octokit client.
    /// </summary>
    /// <returns>A list of default delegating handlers.</returns>
    public static IList<DelegatingHandler> CreateDefaultHandlers()
    {
        var defaultHandlers = s_handlers.Value;
        var kiotaDefaultHandlers = KiotaClientFactory.CreateDefaultHandlers();

        return kiotaDefaultHandlers.Concat(defaultHandlers).ToList();
    }

    /// <summary>
    /// Chains a collection of <see cref="DelegatingHandler"/> instances and returns the first link in the chain.
    /// </summary>
    /// <param name="finalHandler">The final <see cref="HttpMessageHandler"/> in the chain.</param>
    /// <param name="handlers">The collection of <see cref="DelegatingHandler"/> instances to be chained.</param>
    /// <returns>The first link in the chain of <see cref="DelegatingHandler"/> instances.</returns>
    public static DelegatingHandler? ChainHandlersCollectionAndGetFirstLink(HttpMessageHandler? finalHandler, params DelegatingHandler[] handlers)
    {
        if (handlers is null or { Length: 0 })
        {
            return default;
        }

        for (var i = 0; i < handlers.Length; i++)
        {
            var handler = handlers[i];
            var previousItemIndex = i - 1;

            if (previousItemIndex >= 0)
            {
                var previousHandler = handlers[previousItemIndex];
                previousHandler.InnerHandler = handler;
            }
        }

        if (finalHandler != null)
        {
            handlers[^1].InnerHandler = finalHandler;
        }

        return handlers.First();
    }

    /// <summary>
    /// Chains a collection of <see cref="DelegatingHandler"/> instances and returns the first link in the chain.
    /// </summary>
    /// <param name="handlers">The collection of <see cref="DelegatingHandler"/> instances to chain.</param>
    /// <returns>The first link in the chain of <see cref="DelegatingHandler"/> instances.</returns>
    public static DelegatingHandler? ChainHandlersCollectionAndGetFirstLink(
        params DelegatingHandler[] handlers) =>
        ChainHandlersCollectionAndGetFirstLink(null, handlers);

    /// <summary>
    /// Gets the default <see cref="HttpMessageHandler"/> for the Octokit client.
    /// </summary>
    /// <param name="proxy">The optional web proxy to use.</param>
    /// <returns>The default HTTP message handler.</returns>
    public static HttpMessageHandler GetDefaultHttpMessageHandler(IWebProxy? proxy = null) =>
        new HttpClientHandler { Proxy = proxy, AllowAutoRedirect = false };
}
