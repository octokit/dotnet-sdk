
using GitHub.Octokit.Client;
using Xunit;

public class ClientBuilderTests
{
    [Fact]
    public void GetAuthType_WithNoAuthDefined_ReturnsUnauthenticated()
    {
        var options = new ClientOptions();
        var clientBuilder = new ClientBuilder(options);
        Assert.Equal(ClientBuilder.AuthType.Unauthenticated, clientBuilder.GetAuthType());
    }

    [Fact]
    public void GetAuthType_WithTokenDefined_ReturnsTokenType()
    {
        var options = new ClientOptions
        {
            PersonalAccessToken = "some_token",
        };

        var clientBuilder = new ClientBuilder(options);
        Assert.Equal(ClientBuilder.AuthType.PersonalAccessToken, clientBuilder.GetAuthType());
    }

    [Fact]
    public void GetAuthType_WithAppDefined_ReturnsAppType()
    {
        var options = new ClientOptions
        {
            GitHubAppID = 1,
            GitHubAppInstallationID = 1,
            GitHubAppPemFilePath = "some/path",
        };

        var clientBuilder = new ClientBuilder(options);
        Assert.Equal(ClientBuilder.AuthType.GitHubApp, clientBuilder.GetAuthType());
    }

    [Fact]
    public void GetAuthType_WithTokenAndAppIdDefined_ReturnsError()
    {
        var options = new ClientOptions
        {
            PersonalAccessToken = "some_token",
            GitHubAppID = 1,
        };
        var clientBuilder = new ClientBuilder(options);
        Assert.Throws<ArgumentException>(() => clientBuilder.GetAuthType());
    }

    [Fact]
    public void GetAuthType_WithTokenAndInstallationIdDefined_ReturnsError()
    {
        var options = new ClientOptions
        {
            PersonalAccessToken = "some_token",
            GitHubAppInstallationID = 1,
        };
        var clientBuilder = new ClientBuilder(options);
        Assert.Throws<ArgumentException>(() => clientBuilder.GetAuthType());
    }

    [Fact]
    public void GetAuthType_WithTokenAndPemFilePathDefined_ReturnsError()
    {
        var options = new ClientOptions
        {
            PersonalAccessToken = "some_token",
            GitHubAppPemFilePath = "some/path",
        };
        var clientBuilder = new ClientBuilder(options);
        Assert.Throws<ArgumentException>(() => clientBuilder.GetAuthType());
    }

    [Fact]
    public void GetAuthType_WithTokenAndAppIdAndPemFilePathDefined_ReturnsError()
    {
        var options = new ClientOptions
        {
            PersonalAccessToken = "some_token",
            GitHubAppID = 1,
            GitHubAppPemFilePath = "some/path",
        };
        var clientBuilder = new ClientBuilder(options);
        Assert.Throws<ArgumentException>(() => clientBuilder.GetAuthType());
    }

    [Fact]
    public void GetAuthType_WithTokenAndAppIdAndInstallationIdDefined_ReturnsError()
    {
        var options = new ClientOptions
        {
            PersonalAccessToken = "some_token",
            GitHubAppID = 1,
            GitHubAppInstallationID = 1,
        };
        var clientBuilder = new ClientBuilder(options);
        Assert.Throws<ArgumentException>(() => clientBuilder.GetAuthType());
    }

    [Fact]
    public void GetAuthType_WithTokenAndAppIdAndInstallationIdAndPemFilePathDefined_ReturnsError()
    {
        var options = new ClientOptions
        {
            PersonalAccessToken = "some_token",
            GitHubAppID = 1,
            GitHubAppInstallationID = 1,
            GitHubAppPemFilePath = "some/path",
        };
        var clientBuilder = new ClientBuilder(options);
        Assert.Throws<ArgumentException>(() => clientBuilder.GetAuthType());
    }

    [Fact]
    public void GetAuthType_WithOnlyAppIdAndInstallationIdDefined_ReturnsError()
    {
        var options = new ClientOptions
        {
            GitHubAppID = 1,
            GitHubAppInstallationID = 1,
        };
        var clientBuilder = new ClientBuilder(options);
        Assert.Throws<ArgumentException>(() => clientBuilder.GetAuthType());
    }

    [Fact]
    public void GetAuthType_WithOnlyAppIdAndPemFilePathDefined_ReturnsError()
    {
        var options = new ClientOptions
        {
            GitHubAppID = 1,
            GitHubAppPemFilePath = "some/path",
        };
        var clientBuilder = new ClientBuilder(options);
        Assert.Throws<ArgumentException>(() => clientBuilder.GetAuthType());
    }

    [Fact]
    public void GetAuthType_WithOnlyInstallationIdAndPemFilePathDefined_ReturnsError()
    {
        var options = new ClientOptions
        {
            GitHubAppInstallationID = 1,
            GitHubAppPemFilePath = "some/path",
        };
        var clientBuilder = new ClientBuilder(options);
        Assert.Throws<ArgumentException>(() => clientBuilder.GetAuthType());
    }
}
