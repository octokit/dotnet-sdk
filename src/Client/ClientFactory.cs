using System.Net;
using GitHub.Client.Middleware;

namespace GitHub.Client;


public static class ClientFactory
{

    /// <summary>
    /// Creates an instance of HttpClient with the specified HttpMessageHandler.
    /// If no HttpMessageHandler is provided, a default one will be used.
    /// </summary>
    /// <param name="finalHandler">The final HttpMessageHandler in the chain.</param>
    /// <returns>An instance of HttpClient.</returns>
    public static HttpClient Create(HttpMessageHandler? finalHandler = null)
    {
      var defaultHandlers = CreateDefaultHandlers();
      var handler = ChainHandlersCollectionAndGetFirstLink(finalHandler ?? GetDefaultHttpMessageHandler(), defaultHandlers.ToArray());
      return handler != null ? new HttpClient(handler) : new HttpClient();
    }


    /// <summary>
    /// Creates a list of default delegating handlers for the Octokit client.
    /// </summary>
    /// <returns>A list of default delegating handlers.</returns>
    public static IList<DelegatingHandler> CreateDefaultHandlers()
    {
        return new List<DelegatingHandler>
        {
            new APIVersionHandler(),
            new UserAgentHandler(),
        };
    }

    /// <summary>
    /// Chains a collection of <see cref="DelegatingHandler"/> instances and returns the first link in the chain.
    /// </summary>
    /// <param name="finalHandler">The final <see cref="HttpMessageHandler"/> in the chain.</param>
    /// <param name="handlers">The collection of <see cref="DelegatingHandler"/> instances to be chained.</param>
    /// <returns>The first link in the chain of <see cref="DelegatingHandler"/> instances.</returns>
    public static DelegatingHandler? ChainHandlersCollectionAndGetFirstLink(HttpMessageHandler? finalHandler, params DelegatingHandler[] handlers)
    {
      if(handlers == null || !handlers.Any()) return default;
      var handlersCount = handlers.Length;
      for(var i = 0; i < handlersCount; i++)
      {
          var handler = handlers[i];
          var previousItemIndex = i - 1;
          if(previousItemIndex >= 0)
          {
              var previousHandler = handlers[previousItemIndex];
              previousHandler.InnerHandler = handler;
          }
      }
      if(finalHandler != null) {
          handlers[handlers.Length-1].InnerHandler = finalHandler;
      }
      return handlers.First();
    }

    /// <summary>
    /// Chains a collection of <see cref="DelegatingHandler"/> instances and returns the first link in the chain.
    /// </summary>
    /// <param name="handlers">The collection of <see cref="DelegatingHandler"/> instances to chain.</param>
    /// <returns>The first link in the chain of <see cref="DelegatingHandler"/> instances.</returns>
    public static DelegatingHandler? ChainHandlersCollectionAndGetFirstLink(params DelegatingHandler[] handlers)
    {
      return ChainHandlersCollectionAndGetFirstLink(null, handlers);
    }

    /// <summary>
    /// Gets the default HTTP message handler for the Octokit client.
    /// </summary>
    /// <param name="proxy">The optional web proxy to use.</param>
    /// <returns>The default HTTP message handler.</returns>
    public static HttpMessageHandler GetDefaultHttpMessageHandler(IWebProxy? proxy = null)
    {
      return new HttpClientHandler { Proxy = proxy, AllowAutoRedirect = false };
    }
}
