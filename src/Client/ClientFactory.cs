// Copyright (c) GitHub 2023-2024 - Licensed as MIT.

using System.Net;
using GitHub.Octokit.Client.Middleware;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

namespace GitHub.Octokit.Client;

/// <summary>
/// Represents a client factory for creating <see cref="HttpClient"/>.
/// </summary>
public class ClientFactory
{
    private TimeSpan? _requestTimeout;
    private string? _baseUrl;

    private IAuthenticationProvider? _authenticationProvider;
    private readonly HttpMessageHandler? _finalHandler;
    private static readonly Lazy<List<DelegatingHandler>> s_handlers =
        new(() =>
        [
            new APIVersionHandler(),
            new UserAgentHandler(),
            new RateLimitHandler(),
        ]);

    public ClientFactory(HttpMessageHandler? finalHandler = null)
    {
        _finalHandler = finalHandler;
    }

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

    public ClientFactory WithUserAgent(string productName, string productVersion)
    {
        AddOrCreateHandler(new UserAgentHandler(new Middleware.Options.UserAgentOptions { ProductName = productName, ProductVersion = productVersion }));
        return this;
    }

    public ClientFactory WithRequestTimeout(TimeSpan timeSpan)
    {
        _requestTimeout = timeSpan;
        return this;
    }

    public ClientFactory WithBaseUrl(string baseUrl)
    {
        _baseUrl = baseUrl;
        return this;
    }

    public ClientFactory WithAuthenticationProvider(IAuthenticationProvider authenticationProvider)
    {
        _authenticationProvider = authenticationProvider;
        return this;
    }

    public HttpClientRequestAdapter Build()
    {

        if (_authenticationProvider == null) throw new ArgumentNullException("authenticationProvider");

        var httpClient = new HttpClient();
        var defaultHandlers = CreateDefaultHandlers();
        var handler = ChainHandlersCollectionAndGetFirstLink(finalHandler: _finalHandler ?? GetDefaultHttpMessageHandler(), handlers: [.. defaultHandlers]);

        if (handler != null)
        {
            httpClient = new HttpClient(handler);
        }

        if (_requestTimeout.HasValue)
        {
            httpClient.Timeout = _requestTimeout.Value;
        }

        if (!string.IsNullOrEmpty(_baseUrl))
        {
            httpClient.BaseAddress = new Uri(_baseUrl);
        }

        return RequestAdapter.Create(_authenticationProvider, httpClient); ;
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

    /// <summary>
    /// In support of the constructor approach to building a client factory, this method allows for adding or updating
    /// a handler in the list of handlers.
    /// The final result of the list of handlers will be processed in the Build() method.
    /// </summary>
    /// <typeparam name="THandler"></typeparam>
    /// <param name="handler"></param>
    private void AddOrCreateHandler<THandler>(THandler handler) where THandler : DelegatingHandler
    {
        // Find the index of the handler that matches the specified type
        int index = s_handlers.Value.FindIndex(h => h is THandler);

        // If the handler is found, replace it with the new handler otehrwise add the new handler to the list
        if (index >= 0)
        {
            s_handlers.Value[index] = handler;
        }
        else
        {
            s_handlers.Value.Add(handler);
        }
    }
}
