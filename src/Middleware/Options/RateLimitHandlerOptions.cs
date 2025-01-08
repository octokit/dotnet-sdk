using System.Net;
using GitHub.Octokit.Client.Middleware;

namespace GitHub.Octokit.SDK.Middleware.Options;

/// <summary>
/// Represents the options for the rate limit handler.
/// </summary>
public sealed class RateLimitHandlerOptions : IRateLimitHandlerOptions
{
    /// <summary>
    /// Gets the function that determines if the request is rate limited.
    /// The function should return the type of rate limit that is applied to the request.
    /// If the request is not rate limited, the function should return <see cref="RateLimitType.None"/>.
    /// </summary>
    public Func<HttpRequestMessage, HttpResponseMessage, RateLimitType> IsRateLimited => (request, response) =>
    {
        if (response.StatusCode is not HttpStatusCode.TooManyRequests and not HttpStatusCode.Forbidden)
        {
            return RateLimitType.None;
        }

        var retryAfter = response.Headers.RetryAfter;

        var rateLimitRemaining = response.Headers.TryGetValues("X-RateLimit-Remaining", out var rateLimitRemainingValues)
            ? rateLimitRemainingValues.FirstOrDefault()
            : null;

        if (retryAfter is not null && rateLimitRemaining is not "0")
        {
            return RateLimitType.Secondary;
        }

        return rateLimitRemaining switch
        {
            "0" => RateLimitType.Primary,
            _ => RateLimitType.None
        };
    };
}
