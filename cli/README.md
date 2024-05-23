# CLI / Test Harness for the Generated Octokit .NET SDK

This is a sandbox for experimentation and validation while you work on the .NET SDK (It is not part of the published nuget package).

## Environment

For App Installation Auth you'll need the following environment vars.  For more information see the [GitHub docs](https://docs.github.com/en/apps/creating-github-apps/authenticating-with-a-github-app/managing-private-keys-for-github-apps).

`GITHUB_APP_INSTALLATION_ID` 
- Description: The id of the installed instance of an application
- Location: Found under Org/User > Settings > Applications > installed app (URL)

`GITHUB_APP_CLIENT_ID`
- Description: This is either the client ID or App ID of the given application 
- Location: Found under Org/User > Settings > Developer Settings > GitHub Apps > App > About

`GITHUB_APP_PRIVATE_KEY_PATH`
- Description: The path for the private key that you will use to sign your JWTs for authentication 
- Location: Found under Org/User > Settings > Developer Settings > GitHub Apps > App > Private Keys



