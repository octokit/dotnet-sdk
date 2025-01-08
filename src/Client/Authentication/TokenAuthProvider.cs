using Microsoft.Kiota.Abstractions.Authentication;

namespace GitHub.Octokit.Client.Authentication;

/// <summary>
/// Represents an authentication provider for app installations.
/// This class is a concrete implementation of <see cref="BaseBearerTokenAuthenticationProvider"/>.
/// This is beneficial for dev ergonomics - where <c>BaseBearerTokenAuthenticationProvider</c>
/// is a base class for all authentication providers that use a bearer token.
/// </summary>
/// <param name="tokenProvider">
/// The access token provider to forward to
/// the base <see cref="BaseBearerTokenAuthenticationProvider"/>.
/// </param>
public sealed class TokenAuthProvider(
    IAccessTokenProvider tokenProvider) : BaseBearerTokenAuthenticationProvider(tokenProvider)
{
}
