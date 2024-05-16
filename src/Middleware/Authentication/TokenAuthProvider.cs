// Copyright (c) GitHub 2023-2024 - Licensed as MIT.

using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;

namespace GitHub.Octokit.Client.Authentication;

public class TokenAuthProvider : IAuthenticationProvider
{
  private const string AuthorizationHeaderKey = "Authorization";

  /// <summary>
  /// Gets the <see cref="IAuthenticationProvider"/> instance for the token authentication scheme.
  /// </summary>
  public IAuthenticationProvider TokenProvider => this;

  /// <summary>
  /// Gets or sets the token.
  /// </summary>
  public string Token { get; set; }

  /// <summary>
  /// Instantiates a new instance of the <see cref="Authentication.TokenAuthProvider"/> class.
  /// </summary>
  /// <param name="clientId">The client identifier to use.</param>
  /// <param name="token">The token to use.</param>
  /// <exception cref="ArgumentNullException"></exception>
  public TokenAuthProvider(string token)
  {
    ArgumentException.ThrowIfNullOrEmpty(token);
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
  public Task AuthenticateRequestAsync(RequestInformation? request, Dictionary<string, object>? additionalAuthenticationContext = null, CancellationToken cancellationToken = default)
  {
    ArgumentNullException.ThrowIfNull(request);
    ArgumentException.ThrowIfNullOrEmpty(Token);

    if (!request.Headers.ContainsKey(AuthorizationHeaderKey))
    {
      request.Headers.Add(AuthorizationHeaderKey, $"Bearer {Token}");
    }

    return Task.CompletedTask;
  }
}