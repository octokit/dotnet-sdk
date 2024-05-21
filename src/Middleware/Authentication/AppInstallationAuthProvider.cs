using Microsoft.Kiota.Abstractions.Authentication;

namespace GitHub.Octokit.Client.Authentication;

// Not sure if this is needed other than for dev ergonomics - where BaseBearerTokenAuthenticationProvider
// is a base class for all authentication providers that use a bearer token and could be confusing to use

// This may be useful for testing purposes and to provide a common interface for all authentication providers
// Or to abstract logic that is specific to bearer token authentication providers
// 
public class AppInstallationAuthProvider : BaseBearerTokenAuthenticationProvider
{
    public AppInstallationAuthProvider(IAccessTokenProvider tokenProvider) : base(tokenProvider)
    {

    }
}
