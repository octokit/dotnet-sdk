using GitHub;
using GitHub.Octokit.Client;
using GitHub.Octokit.Authentication;
using System.Threading;

var token = Environment.GetEnvironmentVariable("GITHUB_TOKEN") ?? "";
var request = RequestAdapter.Create(new TokenAuthenticationProvider("Octokit.Gen", token));
request.BaseUrl = "http://api.github.localhost:81";
var gitHubClient = new GitHubClient(request);

for (var i = 0; i < 1000; i++) {

  try
  {
      var zen = await gitHubClient.Zen.GetAsync();
      Console.WriteLine("Result:");
      Console.WriteLine(zen);
  }
  catch (Exception e)
  {
      Console.WriteLine(e.Message);
      Environment.Exit(1);
  }
}



