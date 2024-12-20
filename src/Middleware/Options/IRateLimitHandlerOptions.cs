using GitHub.Octokit.Client.Middleware;

namespace GitHub.Octokit.SDK.Middleware.Options;

/// <summary>
/// Defines the options for the rate limit handler.
/// </summary>
public interface IRateLimitHandlerOptions
{
    /// <summary>
    /// Gets the function that determines if the request is rate limited.
    /// </summary>
    Func<HttpRequestMessage, HttpResponseMessage, RateLimitType> IsRateLimited { get; }
}
