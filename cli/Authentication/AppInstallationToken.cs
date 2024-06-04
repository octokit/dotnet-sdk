using System.Security.Cryptography;
using GitHub;
using GitHub.Octokit.Client;
using GitHub.Octokit.Client.Authentication;

namespace cli.Authentication;

/*
For App Installation Auth you'll need the following environment vars.  For more information see the [GitHub docs](https://docs.github.com/en/apps/creating-github-apps/authenticating-with-a-github-app/managing-private-keys-for-github-apps).

`GITHUB_APP_INSTALLATION_ID` 
- Description: The id of the installed instance of an application
- Location: Found under Org/User > Settings > Applications > installed app (URL)

`GITHUB_APP_CLIENT_ID`
- Description: This is either the client ID or App ID of the given application 
- Location: Found under Org/User > Settings > Developer Settings > GitHub Apps > App > About

`GITHUB_APP_PRIVATE_KEY_PATH`
- Description: The path for the private key that you will use to sign your JWTs for authentication 
- Location: Found under Org/User > Settings > Developer Settings > GitHub Apps > App > Private Keys
*/

public class AppInstallationToken
{
    public static async Task Run()
    {
        var installationId = Environment.GetEnvironmentVariable("GITHUB_APP_INSTALLATION_ID") ?? "";
        var clientId = Environment.GetEnvironmentVariable("GITHUB_APP_CLIENT_ID") ?? "";
        var privateKeyPem = File.ReadAllText(Environment.GetEnvironmentVariable("GITHUB_APP_PRIVATE_KEY_PATH") ?? "");
        var githubAppTokenProvider = new GitHubAppTokenProvider();

        var rsa = RSA.Create();
        rsa.ImportFromPem(privateKeyPem);

        var aiAccessTokenProvider = new AppInstallationTokenProvider(clientId, rsa, installationId, githubAppTokenProvider);
        var aiAdapter = RequestAdapter.Create(new AppInstallationAuthProvider(aiAccessTokenProvider));
        var aiGitHubClient = new GitHubClient(aiAdapter);

        try
        {
            var response = await aiGitHubClient.Installation.Repositories.GetAsync();
            response?.Repositories?.ForEach(repo => Console.WriteLine(repo.FullName));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
