
namespace GitHub.Octokit.Client.Authentication;
using Microsoft.Kiota.Abstractions.Authentication;

public interface IAppTokenAuthProvider : IAuthenticationProvider
{
  Task<string?> GetAppAccessTokenAsync(string jwtToken, string installationId);
  Task<string> RefreshTokenAsync(string installationId);
}