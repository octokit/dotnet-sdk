using System.Text.Json;
using System.Security.Cryptography;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using GitHub;
using GitHub.Octokit.Authentication;
using GitHub.Octokit.Client;

var installationId = Environment.GetEnvironmentVariable("GITHUB_APP_INSTALLATION_ID") ?? "";
var clientId = Environment.GetEnvironmentVariable("GITHUB_APP_CLIENT_ID") ?? "";
var privateKey = File.ReadAllText(Environment.GetEnvironmentVariable("GITHUB_APP_PRIVATE_KEY_PATH") ?? "");
var jwtToken = CreateJWT(clientId, privateKey);

var client = BuildHttpClient(jwtToken);
var token = GetAppToken(client).Result;

if (string.IsNullOrEmpty(token)) throw new Exception("Failed to get token");

// var token = Environment.GetEnvironmentVariable("GITHUB_TOKEN") ?? "";
var adapter = RequestAdapter.Create(new TokenAuthenticationProvider(token));
// adapter.BaseUrl = "http://api.github.localhost:1024";
var gitHubClient = new GitHubClient(adapter);

try
{
    var response = await gitHubClient.Installation.Repositories.GetAsync();
    response?.Repositories?.ForEach(repo => Console.WriteLine(repo.FullName));
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

string CreateJWT(string clientId, string privateKey)
{
    var rsa = RSA.Create();
    rsa.ImportFromPem(privateKey);

    var now = DateTimeOffset.Now;
    var tokenDescriptor = new SecurityTokenDescriptor
    {
        Issuer = clientId,
        IssuedAt = now.UtcDateTime,
        NotBefore = now.UtcDateTime,
        Expires = now.AddMinutes(10).UtcDateTime,
        SigningCredentials = new(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256)
    };

    return new JsonWebTokenHandler().CreateToken(tokenDescriptor);
}

HttpClient BuildHttpClient(string token)
{
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Accept", "application/vnd.github+json");
    client.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
    client.DefaultRequestHeaders.Add("User-Agent", "csharp-dummy-app-example");
    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwtToken}");

    return client;

}

async Task<string?> GetAppToken(HttpClient client)
{
    var resp = await client.PostAsync($"https://api.github.com/app/installations/{installationId}/access_tokens", null);
    var body = await resp.Content.ReadAsStringAsync();

    if (!resp.IsSuccessStatusCode)
    {
        throw new Exception($"Error: {resp.StatusCode}, Body: {body}");
    }

    var respBody = JsonSerializer.Deserialize<Dictionary<string, object>>(body);
    var tokenElement = (JsonElement?)respBody?["token"];
    return tokenElement?.ValueKind == JsonValueKind.String ? tokenElement?.GetString() : "";
}
