using GitHub;
using GitHub.Octokit.Client;
using GitHub.Octokit.Client.Authentication;

namespace cli.Authentication;

/*
For Personal Access Token Auth you'll need the following environment variable.  For more information see the [GitHub docs](https://docs.github.com/en/rest/orgs/personal-access-tokens).

`GITHUB_TOKEN`
- Description: The personal access token for the user
- Location: Found under User > Settings > Developer Settings > [Token Type]
*/

public class PersonalAccessToken
{
    public static async Task Run()
    {
        // Personal Access Token authentication
        var tokenProvider = new TokenProvider(Environment.GetEnvironmentVariable("GITHUB_TOKEN") ?? "");
        var adapter = RequestAdapter.Create(new TokenAuthProvider(tokenProvider));
        var gitHubClient = new GitHubClient(adapter);

        try
        {
            var response = await gitHubClient.Repositories.GetAsync();
            response?.ForEach(repo => Console.WriteLine(repo.FullName));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
