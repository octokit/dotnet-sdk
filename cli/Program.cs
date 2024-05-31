using System.Security.Cryptography;
using GitHub;
using GitHub.Octokit.Client;
using GitHub.Octokit.Client.Authentication;


// App InstallationToken authentication
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

// Personal Access Token authentication
// var tokenProvider = new TokenProvider(Environment.GetEnvironmentVariable("GITHUB_TOKEN") ?? "");
// var adapter = RequestAdapter.Create(new AppInstallationAuthProvider(tokenProvider));
// var gitHubClient = new GitHubClient(adapter);

// try
// {
//   var response = await gitHubClient.Installation.Repositories.GetAsync();
//   response?.Repositories?.ForEach(repo => Console.WriteLine(repo.FullName));
// }
// catch (Exception e)
// {
//   Console.WriteLine(e.Message);
// }
