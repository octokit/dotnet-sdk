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
            if (rateLimit == RateLimitType.Primary)
            {
                // Handle primary rate limiting (abort logic)
                // We should think about making an error factory to handle this
                // * Returns proper error message and status code
                // * Does a header pass through

                throw await GetInnerExceptionAsync(response);
            }
            else if (rateLimit == RateLimitType.Secondary) {
            
            // Handle rate limiting (retry logic)
                var retryAfterDuration = ParseRateLimit(response);
                if (retryAfterDuration.HasValue && retryAfterDuration.Value.TotalSeconds > 0)
                {
                    await Task.Delay(retryAfterDuration.Value, cancellationToken);
                    // Retry the request
                    response = await base.SendAsync(request, cancellationToken);
                }
            }
        }

        return response;
    }

    /// <summary>
    /// Parses the rate limit from the response.
    /// This method will parse the rate limit from the response and return the duration to wait before retrying the request.
    /// If the response does not contain a rate limit, this method will return null.
    /// </summary>
    /// <param name="response"></param>
    /// <returns></returns>
    private TimeSpan? ParseRateLimit(HttpResponseMessage response)
    {
        // There might need to be additional rate limit concerns that need to be evaluated here
        return ParseRetryAfterHeader(response);
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
        // First, check if the RetryAfter header exists and is not null.
        if (response.Headers.RetryAfter != null)
        {
            var retryAfter = response.Headers.RetryAfter;

            // If there's a Delta value, use it directly.
            if (retryAfter.Delta.HasValue)
            {
                return retryAfter.Delta;
            }
            // If there's a Date value, calculate the difference from now.
            else if (retryAfter.Date.HasValue)
            {
                var retryAfterTimeSpan = retryAfter.Date.Value.UtcDateTime - DateTime.UtcNow;
                // Ensure the TimeSpan is positive; otherwise, return null.
                return retryAfterTimeSpan.Ticks > 0 ? retryAfterTimeSpan : null;
            }
        }

        // If RetryAfter is null or none of the conditions are met, return null.
        return null;
    }

    // Sourced from: https://github.com/microsoft/kiota-http-dotnet/blob/main/src/Middleware/RetryHandler.cs#L236
    // This should be hoisted out unto aerror factory
    // This method is used to get the inner exception from the response
    private static async Task<Exception> GetInnerExceptionAsync(HttpResponseMessage response)
    {
        string? errorMessage = null;

        // Drain response content to free connections. Need to perform this
        // before retry attempt and before the TooManyRetries ServiceException.
        if(response.Content != null)
        {
            errorMessage = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }

        return new ApiException($"HTTP request failed with status code: {response.StatusCode}.{errorMessage}")
        {
            ResponseStatusCode = (int)response.StatusCode,
            ResponseHeaders = response.Headers.ToDictionary(header => header.Key, header => header.Value),
        };
    }
}
