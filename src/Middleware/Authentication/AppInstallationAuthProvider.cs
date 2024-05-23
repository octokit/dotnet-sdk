using Microsoft.Kiota.Abstractions.Authentication;

namespace GitHub.Octokit.Client.Authentication;


/// <summary>
/// Represents an authentication provider for app installations.
/// This class is a concrete implementation of <see cref="BaseBearerTokenAuthenticationProvider"/>.
/// This is beneficial for dev ergonomics - where BaseBearerTokenAuthenticationProvider
/// is a base class for all authentication providers that use a bearer token 
/// </summary>
public class AppInstallationAuthProvider : BaseBearerTokenAuthenticationProvider
{
    public AppInstallationAuthProvider(IAccessTokenProvider tokenProvider) : base(tokenProvider)
    {

    }
}
