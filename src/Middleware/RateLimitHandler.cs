using System.Net;
using Microsoft.Kiota.Abstractions;

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

        if (response.StatusCode != System.Net.HttpStatusCode.TooManyRequests
        && response.StatusCode != System.Net.HttpStatusCode.Forbidden)
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
        // return rateLimitRemaining == "0" ? RateLimitType.Primary : RateLimitType.None;
    };
}

/// <summary>
/// Represents a handler that handles rate limiting.
/// This handler will check if the request is rate limited and will handle the rate limiting accordingly.
/// If the request is rate limited, the handler will wait for the specified duration and retry the request.
/// </summary>
public class RateLimitHandler : DelegatingHandler
{
    public const string XRateLimitResetHeaderKey = "X-RateLimit-Reset";

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
            var retryAfterDuration = ParseRateLimit(response);
            if (rateLimit == RateLimitType.Primary)
            {
                Console.WriteLine($"Primary rate limit (reset: {response.Headers.GetValues(XRateLimitResetHeaderKey).FirstOrDefault()}) exceeded. " +
                    $"Sleeping for {retryAfterDuration?.TotalSeconds} seconds before retrying.");

                // TODO(kfcampbell): log additional information about rate limits, like we do in go-sdk
                // log.Printf("Rate limit information: %s: %s, %s: %s, %s: %s\n",
                // headers.XRateLimitLimitKey, resp.Header.Get(headers.XRateLimitLimitKey), headers.XRateLimitUsedKey,
                // resp.Header.Get(headers.XRateLimitUsedKey), headers.XRateLimitResourceKey, resp.Header.Get(headers.XRateLimitResourceKey))
            }
            else if (rateLimit == RateLimitType.Secondary)
            {
                Console.WriteLine($"Abuse detection mechanism (secondary rate limit) triggered. " +
                    $"Sleeping for {retryAfterDuration?.TotalSeconds} seconds before retrying.");
            }
            if (retryAfterDuration.HasValue && retryAfterDuration.Value.TotalSeconds > 0)
            {
                await Task.Delay(retryAfterDuration.Value, cancellationToken);
                response = await base.SendAsync(request, cancellationToken);
            }
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
    private TimeSpan? ParseRateLimit(HttpResponseMessage response)
    {
        // "If the retry-after response header is present, you should not retry
        // your request until after that many seconds has elapsed."
        // (see docs link above)
        if (response.Headers.RetryAfter != null)
        {
            return ParseRetryAfterHeader(response);
        }
        // "If the retry-after response header is present, you should not retry
        // your request until after that many seconds has elapsed."
        // (see docs link above)
        else if (response.Headers.Contains(XRateLimitResetHeaderKey))
        {
            return ParseXRateLimitReset(response);
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
    private TimeSpan? ParseRetryAfterHeader(HttpResponseMessage response)
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
                var retryAfterTimeSpan = retryAfter.Date.Value.UtcDateTime - DateTime.UtcNow;
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
    private TimeSpan? ParseXRateLimitReset(HttpResponseMessage response)
    {
        var rateLimitReset = response.Headers.GetValues(XRateLimitResetHeaderKey).FirstOrDefault();
        if (rateLimitReset != null && long.TryParse(rateLimitReset, out var rateLimitResetValue))
        {
            var rateLimitResetDateTime = DateTimeOffset.FromUnixTimeSeconds(rateLimitResetValue);
            var rateLimitResetTimeSpan = rateLimitResetDateTime.UtcDateTime - DateTime.UtcNow;
            return rateLimitResetTimeSpan.Ticks > 0 ? rateLimitResetTimeSpan : null;
        }
        return null;
    }
}
