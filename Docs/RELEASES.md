## Deploying a new release

### Requirements

Creating a new release and deploying the package to nuget are administrative tasks and require that you have/do the following:
1. Admin rights to the [dotnet-sdk](https://github.com/octokit/dotnet-sdk) repository

### Publish to nuget.org

- Create a [new release](https://github.com/octokit/dotnet-sdk/releases/new) 
  - Choose "create new tag" and use [SemVer](https://simver.org/) and the previous version to increment the version v#.#.#
  - Generate release notes and clean them up 
  - Check "Pre release" and submit

