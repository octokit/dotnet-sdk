using GitHub;
using GitHub.Octokit.Client;
using GitHub.Octokit.Authentication;
using System.Threading;
using GitHub.Zen;

var token = Environment.GetEnvironmentVariable("GITHUB_TOKEN") ?? "";
var request = RequestAdapter.Create(new TokenAuthenticationProvider("Octokit.Gen", token));
request.BaseUrl = "http://api.github.localhost:1024";
var gitHubClient = new GitHubClient(request);

var requests = new List<Tuple<int, Task<string?>>>();

for (var i = 0; i < 1000; i++)
{
    Tuple<int, Task<string?>> numberedRequest = new Tuple<int, Task<string?>>(i, gitHubClient.Zen.GetAsync());
    requests.Add(numberedRequest);
    // try
    // {
    //     var zen = await gitHubClient.Zen.GetAsync();
    //     Console.WriteLine($"Result {i}: {zen}");
    // }
    // catch (Exception e)
    // {
    //     Console.WriteLine(e.Message);
    //     Environment.Exit(1);
    // }
}

var responses = await Task.WhenAll(requests.Select(async request =>
{
    var (i, task) = request;
    try
    {
        var zen = await task;
        return $"Result {i}: {zen}";
    }
    catch (Exception e)
    {
        return $"Result {i}: {e.Message}";
    }
}));

foreach (var response in responses)
{
    Console.WriteLine(response);
}
