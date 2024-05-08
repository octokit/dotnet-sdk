using System.Text.Json;
using GitHub;
using GitHub.Octokit.Authentication;
using GitHub.Octokit.Client;

// Use GitHubJwt library to create the GitHubApp Jwt Token using our private certificate PEM file
var generator = new GitHubJwt.GitHubJwtFactory(
    new GitHubJwt.FilePrivateKeySource("/home/kfcampbell/github/dev/dotnet-sdk/kfcampbell-terraform-provider.2024-04-30.private-key.pem"),
    new GitHubJwt.GitHubJwtFactoryOptions
    {
        AppIntegrationId = 131977, // The GitHub App Id
        ExpirationSeconds = 600 // 10 minutes is the maximum time allowed
    }
);
var jwtToken = generator.CreateEncodedJwtToken();

var installationId = 20570954;

var client = new HttpClient();
client.DefaultRequestHeaders.Add("Accept", "application/vnd.github+json");
client.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
client.DefaultRequestHeaders.Add("User-Agent", "csharp-dummy-app-example");
client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwtToken}");

var resp = await client.PostAsync($"https://api.github.com/app/installations/{installationId}/access_tokens", null);
var body = await resp.Content.ReadAsStringAsync();

if (!resp.IsSuccessStatusCode) {
    Console.WriteLine($"Error: {resp.StatusCode}");
    Console.WriteLine($"Body: {body}");
    return;
}

var respBody = JsonSerializer.Deserialize<Dictionary<string, object>>(body);
var tokenElement = (JsonElement)respBody["token"];
var token = tokenElement.ValueKind == JsonValueKind.String ? tokenElement.GetString() : "";

// var token = Environment.GetEnvironmentVariable("GITHUB_TOKEN") ?? "";
var adapter = RequestAdapter.Create(new TokenAuthenticationProvider("Octokit.Gen", token));
// adapter.BaseUrl = "http://api.github.localhost:1024";
var gitHubClient = new GitHubClient(adapter);

try {
    var response = await gitHubClient.Installation.Repositories.GetAsync();
    response.Repositories.ForEach(repo => Console.WriteLine(repo.FullName));
} catch (Exception e) {
    Console.WriteLine(e.Message);
}
