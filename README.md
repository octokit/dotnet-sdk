# dotnet-sdk

An "alpha" version of a generated .NET SDK in C# from [GitHub's OpenAPI spec](https://github.com/github/rest-api-description), built on [Kiota](https://github.com/microsoft/kiota).

## How do I use it?

```
using GitHub.Client;
using GitHub.Authentication;

var token = Environment.GetEnvironmentVariable("GITHUB_TOKEN") ?? "";
var request = RequestAdapter.Create(new TokenAuthenticationProvider("Octokit.Gen",token));
var gitHubClient = new Client(request);

var pullRequests = await gitHubClient.Repos["octokit"]["octokit.net"].Pulls.GetAsync();
```

⚠️ **Note**: This SDK is not yet stable. Breaking changes may occur at any time.

## Why a generated SDK?

We want to...
1.  provide 100% coverage of the API in our SDK
2.  use this as a building block for future SDK tooling.

## Why .NET?

We have a substantial userbase that uses .NET and we wanted them to get access to our generated SDK as early as possible.

## How can I report on my experience or issues with the SDK?

Please use this project's [issues](https://github.com/octokit/dotnet-sdk/issues)!
