// Copyright (c) GitHub 2023-2024 - Licensed as MIT.

using GitHub.Octokit.SDK.Middleware.Options;

namespace GitHub.Octokit.Client.Middleware;

/// <summary>
/// Represents a handler that handles rate limiting.
/// This handler will check if the request is rate limited and will handle the rate limiting accordingly.
/// If the request is rate limited, the handler will wait for the specified duration and retry the request.
/// </summary>
/// <remarks>
///  Initializes a new instance of the <see cref="RateLimitHandler"/> class.
/// </remarks>
/// <param name="options">The options for the rate limit handler.</param>
public class RateLimitHandler(IRateLimitHandlerOptions? options = null) : DelegatingHandler
{
    /// <summary>
    /// The key for the <c>X-RateLimit-Remaining</c> header.
    /// </summary>
    public const string XRateLimitRemainingKey = "X-RateLimit-Remaining";

    /// <summary>
    /// The key for the <c>X-RateLimit-Reset</c> header.
    /// </summary>
    public const string XRateLimitResetKey = "X-RateLimit-Reset";

    /// <summary>
    /// The key for the <c>X-RateLimit-Limit</c> header.
    /// </summary>
    public const string XRateLimitLimitKey = "X-RateLimit-Limit";

    /// <summary>
    /// The key for the <c>X-RateLimit-Used</c> header.
    /// </summary>
    public const string XRateLimitUsedKey = "X-RateLimit-Used";

    /// <summary>
    /// The key for the <c>X-RateLimit-Resource</c> header.
    /// </summary>
    public const string XRateLimitResourceKey = "X-RateLimit-Resource";

    /// <summary>
    /// The key for the <c>Retry-After</c> header.
    /// </summary>
    public const string RetryAfterKey = "Retry-After";

    private readonly IRateLimitHandlerOptions _options = options ?? new RateLimitHandlerOptions();

    /// <summary>
    /// Sends an HTTP request to the inner handler to send to the server as an asynchronous operation.
    /// This method will check if the request is rate limited and will handle the rate limiting accordingly.
    /// If the request is rate limited, the handler will wait for the specified duration and retry the request.
    /// </summary>
    /// <param name="request">The HTTP request message to send.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>The HTTP response message.</returns>
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = await base.SendAsync(request, cancellationToken);
        var rateLimit = _options.IsRateLimited(request, response);

        if (rateLimit is not RateLimitType.None)
        {
            var retryAfterDuration = ParseRateLimit(response, DateTime.UtcNow);
            if (rateLimit is RateLimitType.Primary)
            {
                // TODO(kfcampbell): investigate ways to do logging/notifications in a .NET library
                Console.WriteLine($"Primary rate limit (reset: {response.Headers.GetValues(XRateLimitResetKey).FirstOrDefault()}) exceeded. " +
                    $"Sleeping for {retryAfterDuration?.TotalSeconds ?? 0} seconds before retrying.");

                Console.WriteLine($"Rate limit information: {XRateLimitLimitKey}: {response.Headers.GetValues(XRateLimitLimitKey).FirstOrDefault()}, " +
                    $"{XRateLimitUsedKey}: {response.Headers.GetValues(XRateLimitUsedKey).FirstOrDefault()}, " +
                    $"{XRateLimitResourceKey}: {response.Headers.GetValues(XRateLimitResourceKey).FirstOrDefault()}");
            }
            else if (rateLimit is RateLimitType.Secondary)
            {
                Console.WriteLine($"Abuse detection mechanism (secondary rate limit) triggered. " +
                    $"Sleeping for {retryAfterDuration?.TotalSeconds ?? 0} seconds before retrying.");
            }

            if (retryAfterDuration.HasValue && retryAfterDuration.Value.TotalSeconds > 0)
            {
                await Task.Delay(retryAfterDuration.Value, cancellationToken);
            }
            else
            {
                Console.WriteLine($"Could not parse a valid time to wait for rate limit reset (parsed {retryAfterDuration?.TotalSeconds ?? 0} seconds). Retrying request immediately.");
            }

            response = await SendAsync(request, cancellationToken);
        }

        return response;
    }

    /// <summary>
    /// Parses the rate limit from the response.
    /// This method will parse the rate limit from the response and return the duration to wait before retrying the request.
    /// If the response does not contain a rate limit, this method will return null.
    /// Note that "Retry-After" headers correspond to secondary rate limits and
    /// <c>x-ratelimit-reset</c> headers to primary rate limits.
    /// Docs for rate limit headers:
    /// https://docs.github.com/en/rest/using-the-rest-api/best-practices-for-using-the-rest-api?apiVersion=2022-11-28#handle-rate-limit-errors-appropriately
    /// </summary>
    /// <param name="response">The HTTP response message.</param>
    /// <param name="utcNow">The current UTC time.</param>
    /// <returns>The duration to wait before retrying the request.</returns>
    protected static TimeSpan? ParseRateLimit(HttpResponseMessage response, DateTime utcNow)
    {
        // "If the retry-after response header is present, you should not retry
        // your request until after that many seconds has elapsed."
        // (see docs link above)
        if (response.Headers.RetryAfter is not null)
        {
            return ParseRetryAfterHeader(response, utcNow);
        }
        // If the x-ratelimit-remaining header is 0, you should not make another
        // request until after the time specified by the x-ratelimit-reset header.
        // The x-ratelimit-reset header is in UTC epoch seconds.
        else if (response.Headers.Contains(XRateLimitResetKey))
        {
            return ParseXRateLimitReset(response, utcNow);
        }

        return null;
    }

    /// <summary>
    /// Parses the Retry-After header from the response.
    /// This method will parse the Retry-After header from the response and return the duration to wait before retrying the request.
    /// If the response does not contain a Retry-After header, this method will return null.
    /// </summary>
    /// <param name="response">The HTTP response message.</param>
    /// <param name="utcNow">The current UTC time.</param>
    /// <returns>The duration to wait before retrying the request.</returns>
    protected static TimeSpan? ParseRetryAfterHeader(HttpResponseMessage response, DateTime utcNow)
    {
        if (response.Headers.RetryAfter is not null)
        {
            var retryAfter = response.Headers.RetryAfter;
            if (retryAfter.Delta.HasValue)
            {
                return retryAfter.Delta;
            }
            else if (retryAfter.Date.HasValue)
            {
                var retryAfterTimeSpan = retryAfter.Date.Value.UtcDateTime - utcNow;
                return retryAfterTimeSpan.Ticks > 0 ? retryAfterTimeSpan : null;
            }
        }

        return null;
    }

    /// <summary>
    /// Returns a <see cref="TimeSpan"/> that corresponds to the time until the given
    /// <c>X-RateLimit-Reset</c> header value. If the header isn't present or the
    /// value cannot be parsed into a valid <see cref="TimeSpan"/>, then <see langword="null"/> is returned.
    /// </summary>
    /// <param name="response">The HTTP response message.</param>
    /// <param name="utcNow">The current UTC time.</param>
    /// <returns>The duration to wait before retrying the request.</returns>
    protected static TimeSpan? ParseXRateLimitReset(HttpResponseMessage response, DateTime utcNow)
    {
        var rateLimitReset = response.Headers.GetValues(XRateLimitResetKey).FirstOrDefault();

        if (rateLimitReset is not null && long.TryParse(rateLimitReset, out var rateLimitResetValue))
        {
            var rateLimitResetDateTime = DateTimeOffset.FromUnixTimeSeconds(rateLimitResetValue);
            var rateLimitResetTimeSpan = rateLimitResetDateTime.UtcDateTime - utcNow;

            return rateLimitResetTimeSpan.Ticks > 0 ? rateLimitResetTimeSpan : null;
        }

        return null;
    }
}
