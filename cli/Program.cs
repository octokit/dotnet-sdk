using GitHub;
using GitHub.Octokit.Authentication;
using GitHub.Octokit.Client;

var token = Environment.GetEnvironmentVariable("GITHUB_TOKEN") ?? "";
var adapter = RequestAdapter.Create(new TokenAuthenticationProvider("Octokit.Gen", token));
adapter.BaseUrl = "http://api.github.localhost:1024";
var gitHubClient = new GitHubClient(adapter);

// serial requests may trigger primary rate limiting but are unlikely
// to trigger secondary rate limiting
// for (var i = 0; i < 1000; i++)
// {
//     var response = await gitHubClient.Zen.GetAsync();
//     Console.WriteLine($"Response {i}: {response}");
// }

var requests = new List<Task<string?>>();
for (var i = 0; i < 1500; i++)
{
    var request = gitHubClient.Zen.GetAsync();
    requests.Add(request);
}

var responses = await Task.WhenAll(requests);
var responseNumber = 0;
foreach (var response in responses)
{
    Console.WriteLine($"Response {responseNumber}: {response}");
    responseNumber++;
}
