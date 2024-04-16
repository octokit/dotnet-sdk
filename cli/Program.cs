using GitHub;
using GitHub.Octokit.Client;
using GitHub.Octokit.Authentication;

var token = Environment.GetEnvironmentVariable("GITHUB_TOKEN") ?? "";
var adapter = RequestAdapter.Create(new TokenAuthenticationProvider("Octokit.Gen", token));
adapter.BaseUrl = "http://api.github.localhost:1024";
var gitHubClient = new GitHubClient(adapter);

var requests = new List<Task<string?>>();

for (var i = 0; i < 1000; i++)
{
    var request = gitHubClient.Zen.GetAsync();
    requests.Add(request);
}

var responses = await Task.WhenAll(requests);
foreach (var response in responses)
{
    Console.WriteLine($"Response: {response}");
}
