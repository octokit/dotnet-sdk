using System.Net;

namespace GitHub.Octokit.Client.Middleware;

public enum RateLimitType
{
    None,
    Primary,
    Secondary
}

public interface IRateLimitHandlerOptions
{
    Func<HttpRequestMessage, HttpResponseMessage, RateLimitType> IsRateLimited { get; }
}

/// <summary>
/// Represents the options for the rate limit handler.
/// </summary>
public class RateLimitHandlerOptions : IRateLimitHandlerOptions
{
    /// <summary>
    /// Gets the function that determines if the request is rate limited.
    /// The function should return the type of rate limit that is applied to the request.
    /// If the request is not rate limited, the function should return <see cref="RateLimitType.None"/>.
    /// </summary>
    public Func<HttpRequestMessage, HttpResponseMessage, RateLimitType> IsRateLimited => (request, response) =>
    {
        if (response.StatusCode != HttpStatusCode.TooManyRequests
        && response.StatusCode != HttpStatusCode.Forbidden)
        {
            return RateLimitType.None;
        }

        var retryAfter = response.Headers.RetryAfter;
        var rateLimitRemaining = response.Headers.Contains("X-RateLimit-Remaining")
        ? response.Headers.GetValues("X-RateLimit-Remaining").FirstOrDefault()
        : null;

        if (retryAfter != null && rateLimitRemaining != "0")
        {
            return RateLimitType.Secondary;
        }

        if (rateLimitRemaining == "0")
        {
            return RateLimitType.Primary;
        }
        else
        {
            return RateLimitType.None;
        }
    };
}

/// <summary>
/// Represents a handler that handles rate limiting.
/// This handler will check if the request is rate limited and will handle the rate limiting accordingly.
/// If the request is rate limited, the handler will wait for the specified duration and retry the request.
/// </summary>
public class RateLimitHandler : DelegatingHandler
{
    public const string XRateLimitRemainingKey = "X-RateLimit-Remaining";
    public const string XRateLimitResetKey = "X-RateLimit-Reset";
    public const string XRateLimitLimitKey = "X-RateLimit-Limit";
    public const string XRateLimitUsedKey = "X-RateLimit-Used";
    public const string XRateLimitResourceKey = "X-RateLimit-Resource";
    public const string RetryAfterKey = "Retry-After";

    private readonly IRateLimitHandlerOptions _options;

    /// <summary>
    ///  Initializes a new instance of the <see cref="RateLimitHandler"/> class.
    /// </summary>
    /// <param name="options"></param>
    public RateLimitHandler(IRateLimitHandlerOptions? options = null)
    {
        _options = options ?? new RateLimitHandlerOptions();
    }

    /// <summary>
    /// Sends an HTTP request to the inner handler to send to the server as an asynchronous operation.
    /// This method will check if the request is rate limited and will handle the rate limiting accordingly.
    /// If the request is rate limited, the handler will wait for the specified duration and retry the request.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = await base.SendAsync(request, cancellationToken);
        var rateLimit = _options.IsRateLimited(request, response);

        if (rateLimit != RateLimitType.None)
        {
            var retryAfterDuration = ParseRateLimit(response, DateTime.UtcNow);
            if (rateLimit == RateLimitType.Primary)
            {
                // TODO(kfcampbell): investigate ways to do logging/notifications in a .NET library
                Console.WriteLine($"Primary rate limit (reset: {response.Headers.GetValues(XRateLimitResetKey).FirstOrDefault()}) exceeded. " +
                    $"Sleeping for {retryAfterDuration?.TotalSeconds ?? 0} seconds before retrying.");

                Console.WriteLine($"Rate limit information: {XRateLimitLimitKey}: {response.Headers.GetValues(XRateLimitLimitKey).FirstOrDefault()}, " +
                    $"{XRateLimitUsedKey}: {response.Headers.GetValues(XRateLimitUsedKey).FirstOrDefault()}, " +
                    $"{XRateLimitResourceKey}: {response.Headers.GetValues(XRateLimitResourceKey).FirstOrDefault()}");
            }
            else if (rateLimit == RateLimitType.Secondary)
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
    /// "x-ratelimit-reset" headers to primary rate limits.
    /// Docs for rate limit headers:
    /// https://docs.github.com/en/rest/using-the-rest-api/best-practices-for-using-the-rest-api?apiVersion=2022-11-28#handle-rate-limit-errors-appropriately
    /// </summary>
    /// <param name="response"></param>
    /// <returns></returns>
    protected TimeSpan? ParseRateLimit(HttpResponseMessage response, DateTime utcNow)
    {
        // "If the retry-after response header is present, you should not retry
        // your request until after that many seconds has elapsed."
        // (see docs link above)
        if (response.Headers.RetryAfter != null)
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
    /// <param name="response"></param>
    /// <returns></returns>
    protected TimeSpan? ParseRetryAfterHeader(HttpResponseMessage response, DateTime utcNow)
    {
        if (response.Headers.RetryAfter != null)
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
    /// ParseXRateLimitReset returns a TimeSpan that corresponds to the time until the given
    /// X-RateLimit-Reset header value. If the header is not present or the
    /// value cannot be parsed into a valid TimeSpan, the method will return null.
    /// </summary>
    /// <param name="response"></param>
    /// <returns></returns> <summary>
    protected TimeSpan? ParseXRateLimitReset(HttpResponseMessage response, DateTime utcNow)
    {
        var rateLimitReset = response.Headers.GetValues(XRateLimitResetKey).FirstOrDefault();
        if (rateLimitReset != null && long.TryParse(rateLimitReset, out var rateLimitResetValue))
        {
            var rateLimitResetDateTime = DateTimeOffset.FromUnixTimeSeconds(rateLimitResetValue);
            var rateLimitResetTimeSpan = rateLimitResetDateTime.UtcDateTime - utcNow;
            return rateLimitResetTimeSpan.Ticks > 0 ? rateLimitResetTimeSpan : null;
        }
        return null;
    }
}
