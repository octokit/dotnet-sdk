// Copyright (c) GitHub 2023-2024 - Licensed as MIT.

using System.Net;
using GitHub.Octokit.Client.Middleware;
using GitHub.Octokit.Client.Middleware.Options;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

namespace GitHub.Octokit.Client;

/// <summary>
/// Represents a client factory for creating <see cref="HttpClient"/>.
/// </summary>
public sealed class ClientFactory(HttpMessageHandler? finalHandler = null)
{
    private TimeSpan? _requestTimeout;
    private string? _baseUrl;
    private IAuthenticationProvider? _authenticationProvider;

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
    /// Sets the user agent for the <see cref="HttpClient"/>.
    /// </summary>
    /// <param name="productName">The product name.</param>
    /// <param name="productVersion">The product version.</param>
    /// <returns>The current instance of <see cref="ClientFactory"/>.</returns>
    public ClientFactory WithUserAgent(string productName, string productVersion)
    {
        AddOrCreateHandler(new UserAgentHandler(new UserAgentOptions
        {
            ProductName = productName,
            ProductVersion = productVersion
        }));

        return this;
    }

    /// <summary>
    /// Sets the request timeout for the <see cref="HttpClient"/>.
    /// </summary>
    /// <param name="timeSpan">The request timeout.</param>
    /// <returns>The current instance of <see cref="ClientFactory"/>.</returns>
    public ClientFactory WithRequestTimeout(TimeSpan timeSpan)
    {
        _requestTimeout = timeSpan;

        return this;
    }

    /// <summary>
    /// Sets the base URL for the <see cref="HttpClient"/>.
    /// </summary>
    /// <param name="baseUrl">The base URL.</param>
    /// <returns>The current instance of <see cref="ClientFactory"/>.</returns>
    public ClientFactory WithBaseUrl(string baseUrl)
    {
        _baseUrl = baseUrl;

        return this;
    }

    /// <summary>
    /// Sets the authentication provider for the <see cref="HttpClient"/>.
    /// </summary>
    /// <param name="authenticationProvider">The authentication provider.</param>
    /// <returns>The current instance of <see cref="ClientFactory"/>.</returns>
    public ClientFactory WithAuthenticationProvider(IAuthenticationProvider authenticationProvider)
    {
        _authenticationProvider = authenticationProvider;

        return this;
    }

    /// <summary>
    /// Builds the <see cref="HttpClientRequestAdapter"/> with the configured settings.
    /// </summary>
    /// <returns>An instance of <see cref="HttpClientRequestAdapter"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the authentication provider is null.</exception>
    public HttpClientRequestAdapter Build()
    {
        ArgumentNullException.ThrowIfNull(_authenticationProvider);

        var httpClient = new HttpClient();
        var defaultHandlers = CreateDefaultHandlers();
        var handler = ChainHandlersCollectionAndGetFirstLink(finalHandler: finalHandler ?? GetDefaultHttpMessageHandler(), handlers: [.. defaultHandlers]);

        if (handler is not null)
        {
            httpClient = new HttpClient(handler);
        }

        if (_requestTimeout.HasValue)
        {
            httpClient.Timeout = _requestTimeout.Value;
        }

        if (!string.IsNullOrWhiteSpace(_baseUrl))
        {
            httpClient.BaseAddress = new Uri(_baseUrl);
        }

        return RequestAdapter.Create(_authenticationProvider, httpClient);
    }

    /// <summary>
    /// Creates a list of default delegating handlers for the Octokit client.
    /// </summary>
    /// <returns>A list of default delegating handlers.</returns>
    public static IList<DelegatingHandler> CreateDefaultHandlers()
    {
        var defaultHandlers = s_handlers.Value;
        var kiotaDefaultHandlers = KiotaClientFactory.CreateDefaultHandlers();

        return [.. kiotaDefaultHandlers, .. defaultHandlers];
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

        if (finalHandler is not null)
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
    /// Adds or updates a handler in the list of handlers.
    /// </summary>
    /// <typeparam name="THandler">The type of the handler.</typeparam>
    /// <param name="handler">The handler to add or update.</param>
    private static void AddOrCreateHandler<THandler>(THandler handler) where THandler : DelegatingHandler
    {
        // Find the index of the handler that matches the specified type
        int index = s_handlers.Value.FindIndex(h => h is THandler);

        // If the handler is found, replace it with the new handler otherwise add the new handler to the list
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
