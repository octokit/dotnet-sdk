// Copyright (c) GitHub 2023-2024 - Licensed as MIT.
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

namespace GitHub.Octokit.Client;

/// <summary>
/// Represents an adapter for making HTTP requests using HttpClient with additional configuration options.
/// </summary>
public class RequestAdapter
{
    /// <summary>
    /// Initializes and returns a new instance of the <see cref="HttpClientRequestAdapter"/> class.
    /// </summary>
    /// <param name="authenticationProvider">The authentication provider to use for making requests.</param>
    /// <param name="clientFactory">Optional: A custom HttpClient factory. If not provided, a default client will be created.</param>
    /// <returns>A new instance of the <see cref="HttpClientRequestAdapter"/> class.</returns>

    public static HttpClientRequestAdapter Create(IAuthenticationProvider authenticationProvider, HttpClient? clientFactory = null)
    {
        clientFactory ??= ClientFactory.Create();

        var gitHubRequestAdapter =
          new HttpClientRequestAdapter(
            authenticationProvider,
            null, // Node Parser
            null, // Serializer
            clientFactory,
            null);

        return gitHubRequestAdapter;
    }
}

