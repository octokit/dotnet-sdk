
namespace GitHub.Octokit.Client.Authentication;
using Microsoft.Kiota.Abstractions.Authentication;

public interface IAppInstallationTokenAuthProvider : IAuthenticationProvider
{
  Task<string?> GetAppInstallationAccessTokenAsync(string jwtToken, int installationId);
  Task<string> RefreshAppInstallationAccessTokenAsync(int installationId);
}