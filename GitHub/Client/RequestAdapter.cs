using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using GitHub.Client.Middleware;


namespace GitHub.Client;

public static class RequestAdapter
{
    /// <summary>
    /// Represents an adapter for making HTTP requests using HttpClient.
    /// </summary>
    /// TODO: Implement the missing props and methods
    public static HttpClientRequestAdapter Create(IAuthenticationProvider authenticationProvider)
    {
      var clientFactory = ClientFactory.Create(); 
      var githubRequestAdapter = new HttpClientRequestAdapter(authenticationProvider, null, null, clientFactory, null);
      return githubRequestAdapter;
    }
}
