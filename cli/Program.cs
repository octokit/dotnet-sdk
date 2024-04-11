using GitHub;
using GitHub.Octokit.Client;
using GitHub.Octokit.Authentication;
using System.Threading;

var token = Environment.GetEnvironmentVariable("GITHUB_TOKEN") ?? "";
var request = RequestAdapter.Create(new TokenAuthenticationProvider("Octokit.Gen", token));
var gitHubClient = new GitHubClient(request);

var requests = new List<Task<List<GitHub.Models.PullRequestSimple>?>>();
for (var i = 0; i < 1000; i++)
{
    requests.Add(gitHubClient.Repos["octokit"]["octokit.net"].Pulls.GetAsync());
}

var continuation = Task.WhenAll(requests);
try {
    continuation.Wait();
} catch (Exception e) {
    Console.WriteLine(e.Message);
    Environment.Exit(1);
}

if (continuation.Status == TaskStatus.RanToCompletion)
{
    Console.WriteLine("Task completed successfully.");
    foreach (var result in continuation.Result)
    {
        var pullRequests = result;
        foreach (var pullRequest in pullRequests)
        {
            Console.WriteLine($"#{pullRequest?.Number} {pullRequest?.Title}");
        }
    }
}
else if (continuation.Status == TaskStatus.Faulted)
{
    Console.WriteLine("Task failed.");
}
else if (continuation.Status == TaskStatus.Canceled)
{
    Console.WriteLine("Task was canceled.");
}

