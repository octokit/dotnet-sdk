

using System.Linq;
using System.Runtime.InteropServices;
using GitHub.Octokit.Authentication;

namespace GitHub.Octokit.Client;

public struct ClientOptions
{
    public string UserAgent { get; set; }
    public string APIVersion { get; set; }
    public string BaseURL { get; set; }

    public IList<HttpMessageHandler> Middlewares { get; set; }

    // PersonalAccessToken should be left blank if GitHub App auth or an unauthenticated client is desired
    public string PersonalAccessToken { get; set; }

    // GitHubAppPemFilePath should be left blank if token auth or an unauthenticated client is desired.
	public string GitHubAppPemFilePath { get; set; }

	// GitHubAppID should be left blank if token auth or an unauthenticated client is desired.
	public long GitHubAppID { get; set; }

	// GitHubAppInstallationID should be left blank if token auth or an unauthenticated client is desired.
	public long GitHubAppInstallationID { get; set; }

}

public class ClientBuilder
{
    private ClientOptions _options;

    public ClientBuilder(ClientOptions? options = null)
    {
        if (options != null) {
            _options = (ClientOptions)options;
        } else {
            // it's a little annoying that the defaults aren't applied if the user brings their own
            // options struct. we can recommend users call GetDefaultClientOptions() before applying
            // their own, but that's still not ideal.
            _options = GetDefaultClientOptions();
        }
    }

    public ClientOptions GetDefaultClientOptions()
    {
        return new ClientOptions
        {
            // TODO(kfcampbell): get version from assembly or tagged release
            UserAgent = "octokit/dotnet-sdk@prerelease",
            APIVersion = "2022-11-28",
        };
    }

    public ClientBuilder WithUserAgent(string userAgent)
    {
        _options.UserAgent = userAgent;
        return this;
    }

    public ClientBuilder WithAPIVersion(string apiVersion)
    {
        _options.APIVersion = apiVersion;
        return this;
    }

    public ClientBuilder WithBaseURL(string baseURL)
    {
        _options.BaseURL = baseURL;
        return this;
    }

    public ClientBuilder WithTokenAuth(string personalAccessToken)
    {
        _options.PersonalAccessToken = personalAccessToken;
        return this;
    }

    public ClientBuilder WithGitHubAppAuth(string gitHubAppPemFilePath, long gitHubAppID, long gitHubAppInstallationID)
    {
        _options.GitHubAppPemFilePath = gitHubAppPemFilePath;
        _options.GitHubAppID = gitHubAppID;
        _options.GitHubAppInstallationID = gitHubAppInstallationID;
        return this;
    }

    public ClientBuilder WithMiddleware(HttpMessageHandler handler)
    {
        if (_options.Middlewares == null)
        {
            _options.Middlewares = new List<HttpMessageHandler>();
        }
        if (handler != null && !_options.Middlewares.Contains(handler))
        {
            _options.Middlewares.Add(handler);
        }
        return this;
    }

    public GitHubClient Build()
    {
        // TODO(kfcampbell): figure out how to chain together options here to implement the build method
        // this is the crux of the thing, really
        // can assume we have some default options set based on the constructor

        // TODO(kfcampbell): refactor auth options out into a helper method
        // if token auth is configured and app ID isn't, build a token auth client
        if (_options.PersonalAccessToken != null
            && _options.GitHubAppPemFilePath == ""
            && _options.GitHubAppID == 0
            && _options.GitHubAppInstallationID == 0)
        {
            var tokenProvider = new TokenAuthenticationProvider(_options.PersonalAccessToken);
        }
        // if app auth is configured and token isn't, build an app auth client
        else if (_options.GitHubAppPemFilePath != null
                && _options.GitHubAppID != 0
                && _options.GitHubAppInstallationID != 0
                && _options.PersonalAccessToken == "")
        {

        }
        // if some other combination of options is set, throw an error
        else if (_options.PersonalAccessToken != null
            && _options.GitHubAppPemFilePath != null
            && _options.GitHubAppID != 0
            && _options.GitHubAppInstallationID != 0)
        {
            throw new ArgumentException("Cannot configure both token and app auth at the same time");
        }
        else
        {
            throw new NotImplementedException("Keegan needs to get his act together and implement this");
        }

        // very basic non-working implementation to keep compiler happy
        var requestAdapter = RequestAdapter.Create(new TokenAuthenticationProvider(""), null);
        return new GitHubClient(requestAdapter);
    }
}
