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
    public static async Task Run(string approach)
    {
        switch (approach)
        {
            case "builder":
                await RunWithBuilder();
                break;
            case "default":
                await RunWithDefault();
                break;
            default:
                Console.WriteLine("Invalid approach. Please provide 'builder' or 'default'");
                break;
        }
    }

    private static async Task RunWithBuilder()
    { 
        var tokenProvider = new TokenProvider(Environment.GetEnvironmentVariable("GITHUB_TOKEN") ?? "");

        var adapter = new ClientFactory()
            .WithAuthenticationProvider(new TokenAuthProvider(tokenProvider))
            .WithUserAgent("my-app", "1.0.0")
            .WithRequestTimeout(TimeSpan.FromSeconds(100))
            .WithBaseUrl("https://api.github.com")
            .Build();

            await MakeRequest(new GitHubClient(adapter));
    } 

    private static async Task RunWithDefault()
    {
        var tokenProvider = new TokenProvider(Environment.GetEnvironmentVariable("GITHUB_TOKEN") ?? "");
        var adapter = RequestAdapter.Create(new TokenAuthProvider(tokenProvider));
        await MakeRequest(new GitHubClient(adapter));
    } 

    private static async Task MakeRequest(GitHubClient gitHubClient)
    {
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
