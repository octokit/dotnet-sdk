// Copyright (c) GitHub 2023 � Licensed as MIT.

using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;

namespace GitHub.Octokit.Authentication;

// TODO: Consider implementing `Basic` authentication scheme as a separate class
// TODO: Consider implementing `Anonymous` authentication scheme as a separate class
// TODO: Consider implementing `AccessToken/Device` authentication scheme as a separate class
// TODO: Consider implementing `GitHub Apps` authentication scheme as a separate class
public class TokenAuthenticationProvider : IAuthenticationProvider
{
    private const string AuthorizationHeaderKey = "Authorization";

    /// <summary>
    /// Gets the <see cref="IAuthenticationProvider"/> instance for the token authentication scheme.
    /// </summary>
    public IAuthenticationProvider TokenAuthProvider => this;

    /// <summary>
    /// Gets or sets the client identifier.
    /// </summary>
    public string ClientId { get; set; }
    
    /// <summary>
    /// Gets or sets the token.
    /// </summary>
    public string Token { get; set; }

    /// <summary>
    /// Instantiates a new instance of the <see cref="TokenAuthenticationProvider"/> class.
    /// </summary>
    /// <param name="clientId">The client identifier to use.</param>
    /// <param name="token">The token to use.</param>
    /// <exception cref="ArgumentNullException"></exception>
    public TokenAuthenticationProvider(string clientId, string token)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(clientId);
        ArgumentNullException.ThrowIfNullOrEmpty(token);

        ClientId = clientId;
        Token = token;
    }

    /// <summary>
    /// Authenticates the application request.
    /// This currently acts as a synchronous (no await) method - but will change as we do more work on the authentication library.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="additionalAuthenticationContext"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public Task AuthenticateRequestAsync(RequestInformation request, Dictionary<string, object>? additionalAuthenticationContext = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        ArgumentNullException.ThrowIfNullOrEmpty(Token);

        if (!request.Headers.ContainsKey(AuthorizationHeaderKey))
        {
            request.Headers.Add(AuthorizationHeaderKey, $"Bearer {Token}");
        }

        return Task.CompletedTask;
    }
}
