using GitHub;
using GitHub.Octokit.Client;
using GitHub.Octokit.Client.Authentication;
using Microsoft.Kiota.Abstractions;
using System.Net.Http;
using System.IO;


public class Example
{
    public static async Task Run()
    {
        Console.WriteLine("Hello, World!");
        var tokenProvider = new TokenProvider(Environment.GetEnvironmentVariable("GITHUB_TOKEN") ?? "");
        var adapter = RequestAdapter.Create(new TokenAuthProvider(tokenProvider));
        var gitHubClient = new GitHubClient(adapter);

        var response = await gitHubClient.Repos["octokit"]["octokit.net"].Contents["LICENSE.txt"].GetAsync();
        var content = await response.ReadContentAsStringAsync();
    }
}