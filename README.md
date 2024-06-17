# Octokit: .NET SDK

[![Build and test .NET SDK](https://github.com/octokit/dotnet-sdk/actions/workflows/build.yml/badge.svg)](https://github.com/octokit/dotnet-sdk/actions/workflows/build.yml) [![CodeQL](https://github.com/octokit/dotnet-sdk/actions/workflows/github-code-scanning/codeql/badge.svg)](https://github.com/octokit/dotnet-sdk/actions/workflows/github-code-scanning/codeql) [![Publish Release to NuGet](https://github.com/octokit/dotnet-sdk/actions/workflows/publish.yml/badge.svg)](https://github.com/octokit/dotnet-sdk/actions/workflows/publish.yml)

An "alpha" version of a generated .NET SDK in C# from [GitHub's OpenAPI spec](https://github.com/github/rest-api-description), built on [Kiota](https://github.com/microsoft/kiota). View on [NuGet](https://www.nuget.org/packages/GitHub.Octokit.SDK/).

## How do I use it?

### Installation

To install the package, you can use either of the following options:

- In Visual Studio, from the Package Explorer, search for `GitHub.Octokit.SDK`, or
- Type `Install-Package GitHub.Octokit.SDK` into the Package Manager Console, or
- Type `dotnet add ./path/to/myproject.csproj package GitHub.Octokit.SDK` in a terminal (replace `./path/to/myproject.csproj` by the path to the _*.csproj_ file you want to add the dependency)

### Make your first request

```csharp
using GitHub;
using GitHub.Octokit.Client;
using GitHub.Octokit.Client.Authentication;

var token = Environment.GetEnvironmentVariable("GITHUB_TOKEN") ?? "";
var request = RequestAdapter.Create(new TokenAuthProvider(new TokenProvider(token)));
var gitHubClient = new GitHubClient(request);

var pullRequests = await gitHubClient.Repos["octokit"]["octokit.net"].Pulls.GetAsync();

foreach (var pullRequest in pullRequests)
{
    Console.WriteLine($"#{pullRequest.Number} {pullRequest.Title}");
}
```

> [!IMPORTANT]
> This SDK is not yet stable. Breaking changes may occur at any time.

### Authentication

This SDK supports [Personal Access Tokens (classic)](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/managing-your-personal-access-tokens#personal-access-tokens-classic), [fine-grained Personal Access Tokens](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/managing-your-personal-access-tokens#fine-grained-personal-access-tokens), and [GitHub Apps](https://docs.github.com/en/apps/creating-github-apps/authenticating-with-a-github-app/about-authentication-with-a-github-app) authentication.

In order to use either type of Personal Access token, you can use the `TokenAuthProvider` constructor option when constructing a new token provider, like so:

```csharp
    var tokenProvider = new TokenProvider(Environment.GetEnvironmentVariable("GITHUB_TOKEN") ?? "");
    var adapter = RequestAdapter.Create(new TokenAuthProvider(tokenProvider));
    var gitHubClient = new GitHubClient(adapter);
```

In order to authenticate as a GitHub App, you can use the `AppInstallationAuthProvider` constructor option:

```csharp
    var githubAppTokenProvider = new GitHubAppTokenProvider();
    var rsa = RSA.Create();
    rsa.ImportFromPem(PRIVATE_KEY_PATH);

    var aiAccessTokenProvider = new AppInstallationTokenProvider(CLIENT_ID, rsa, INSTALLATION_ID, githubAppTokenProvider);
    var aiAdapter = RequestAdapter.Create(new AppInstallationAuthProvider(aiAccessTokenProvider));
    var aiGitHubClient = new GitHubClient(aiAdapter);
```

To see more detailed examples, view [the cli/ directory in this repo](cli/).

⚠️ **Note**: There are [three types](https://docs.github.com/en/apps/creating-github-apps/authenticating-with-a-github-app/about-authentication-with-a-github-app) of GitHub App authentication:
1. [As the App itself (meta endpoints)](https://docs.github.com/en/rest/apps/apps?apiVersion=2022-11-28)
1. [As an App installation](https://docs.github.com/en/rest/authentication/endpoints-available-for-github-app-installation-access-tokens?apiVersion=2022-11-28)
1. On behalf of a user

Authenticating on behalf of a user is not supported in an SDK, as it requires a UI authentication flow with redirects. This SDK supports authenticating as the App itself and as an App installation.

Note that the SDK **does not yet** support authenticating as the App itself and as an App installation using the same client transparently to the user. Authenticating as the App itself requires [creating a JSON Web Token (JWT)](https://docs.github.com/en/apps/creating-github-apps/authenticating-with-a-github-app/generating-a-json-web-token-jwt-for-a-github-app) and using that as token authentication. For helpers to create and sign a JWT in .NET, you may use the helpers in the `GitHubAppTokenProvider` [class](src/Client/Authentication/GitHubAppTokenProvider.cs).

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

## Testing

- Run tests: `dotnet test`
- Generate test coverage: `dotnet test -p:CollectCoverage=true -p:CoverletOutput=coverage/ -p:CoverletOutputFormat=opencover -p:ExcludeByFile="$(pwd)/src/GitHub/**/*.cs"`
- Generate test report: `dotnet reportgenerator -targetdir:$(pwd)/test/coverage/Report/ -reports:$(pwd)/test/coverage/coverage.opencover.xml`
    - Note that this requires installing [ReportGenerator](https://github.com/danielpalme/ReportGenerator), whose installation instructions can be found [here](https://github.com/danielpalme/ReportGenerator?tab=readme-ov-file#install-the-package-matching-your-platform-and-needs)
    - We're using the `dotnet-reportgenerator-globaltool`, so follow that set of installation instructions
- The test report can be viewed by opening the generated report file (logged to CLI output, something like `/path/to/your/repo/dotnet-sdk/test/coverage/Report/index.html`) in a browser

## More details on this SDK and repo

- [Code of conduct](Docs/CODE_OF_CONDUCT.md)
- [Contributing](Docs/CONTRIBUTING.md)
- [Releases](Docs/RELEASES.md)
- [Incidents and security](Docs/SECURITY.md)
