# Octokit: .NET SDK

[![Build and test .NET SDK](https://github.com/octokit/dotnet-sdk/actions/workflows/build.yml/badge.svg)](https://github.com/octokit/dotnet-sdk/actions/workflows/build.yml) [![CodeQL](https://github.com/octokit/dotnet-sdk/actions/workflows/github-code-scanning/codeql/badge.svg)](https://github.com/octokit/dotnet-sdk/actions/workflows/github-code-scanning/codeql) [![Publish Release to NuGet](https://github.com/octokit/dotnet-sdk/actions/workflows/publish.yml/badge.svg)](https://github.com/octokit/dotnet-sdk/actions/workflows/publish.yml)

An "alpha" version of a generated .NET SDK in C# from [GitHub's OpenAPI spec](https://github.com/github/rest-api-description), built on [Kiota](https://github.com/microsoft/kiota).

## How do I use it?

```csharp
using GitHub;
using GitHub.Client;
using GitHub.Authentication;

var token = Environment.GetEnvironmentVariable("GITHUB_TOKEN") ?? "";
var request = RequestAdapter.Create(new TokenAuthenticationProvider("Octokit.Gen", token));
var gitHubClient = new GitHubClient(request);

var pullRequests = await gitHubClient.Repos["octokit"]["octokit.net"].Pulls.GetAsync();

foreach (var pullRequest in pullRequests)
{
    Console.WriteLine($"#{pullRequest.Number} {pullRequest.Title}");
}
```

> [!IMPORTANT]
> This SDK is not yet stable. Breaking changes may occur at any time.

## Why a generated SDK?

We want to...
1.  provide 100% coverage of the API in our SDK
1.  use this as a building block for future SDK tooling

## Why .NET?

We have a substantial userbase that uses .NET and we wanted them to get access to our generated SDK as early as possible.

## How can I report on my experience or issues with the SDK?

Please use this project's [issues](https://github.com/octokit/dotnet-sdk/issues)!

## Source organization

Currently this project is fairly simple (we hope it can stay that way).  All of the package based source is contained in the `GitHub` folder.

 - **Authentication** - everything related to authenticating requests
 - **Client** - the logic for constructing the plumbing to interact with the GitHub API
 - **Middleware** - this represents object and handlers that can mutate the request and are "injected" into the request/response flow.
 - **Octokit** - types which represent request/response objects

## More details on this SDK and repo

- [Code of conduct](Docs/CODE_OF_CONDUCT.md)
- [Contributing](Docs/CONTRIBUTING.md)
- [Releases](Docs/RELEASES.md)
- [Incidents and security](Docs/SECURITY.md)
