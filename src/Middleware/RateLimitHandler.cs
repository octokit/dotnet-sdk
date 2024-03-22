using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GitHub.Octokit.Client.Middleware
{
  /// <summary>
  /// Middleware for handling rate limits in HTTP requests.
  /// </summary>
  public class RateLimitHandler : DelegatingHandler
  {
    /// <summary>
    /// Sends an HTTP request and handles rate limits in the response.
    /// </summary>
    /// <param name="request">The HTTP request message.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The HTTP response message.</returns>
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
      HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

      RateLimitType rateLimit = IsRateLimited(response);

      if (rateLimit != RateLimitType.None)
      {
        await HandleRateLimitAsync(response, rateLimit);
        // Retry the request after handling rate limit. Ensure you do not create a retry loop without exit conditions.
        response = await base.SendAsync(request, cancellationToken);
      }

      return response;
    }

    /// <summary>
    /// Handles the rate limit in the response by waiting for the specified duration before retrying the request.
    /// </summary>
    /// <param name="response">The HTTP response message.</param>
    /// <param name="rateLimitType">The type of rate limit.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    private async Task HandleRateLimitAsync(HttpResponseMessage response, RateLimitType rateLimitType)
    {
        TimeSpan? retryAfterDuration = null;

        switch (rateLimitType)
        {
            case RateLimitType.Primary:
                Console.WriteLine("Primary rate limit reached. Checking Retry-After header...");
                retryAfterDuration = ParseRetryAfterHeader(response);
                break;

            case RateLimitType.Secondary:
                Console.WriteLine("Secondary rate limit (abuse detection) triggered. Checking Retry-After header...");
                retryAfterDuration = ParseRetryAfterHeader(response);
                break;
        }

        if (retryAfterDuration.HasValue)
        {
            Console.WriteLine($"Sleeping for {retryAfterDuration.Value.TotalSeconds} seconds before retrying...");
            await Task.Delay(retryAfterDuration.Value);
        }
        else
        {
            Console.WriteLine("No valid Retry-After duration found. Adjust your retry logic as necessary.");
        }
    }

    /// <summary>
    /// Determines the type of rate limit based on the response.
    /// </summary>
    /// <param name="response">The HTTP response message.</param>
    /// <returns>The type of rate limit.</returns>
    private RateLimitType IsRateLimited(HttpResponseMessage response)
    {
      if (response.StatusCode != System.Net.HttpStatusCode.TooManyRequests &&
        response.StatusCode != System.Net.HttpStatusCode.Forbidden)
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

      return RateLimitType.None;
    }

    /// <summary>
    /// Parses the Retry-After header in the response to determine the duration to wait before retrying.
    /// </summary>
    /// <param name="response">The HTTP response message.</param>
    /// <returns>The duration to wait before retrying, or null if the Retry-After header is not present.</returns>
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

    /// <summary>
    /// Represents the type of rate limit.
    /// </summary>
    public enum RateLimitType
    {
      None,
      Primary,
      Secondary
    }
  }
}