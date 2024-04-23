using System.Net;
using System.Net.Http.Headers;
using GitHub.Octokit.Client.Middleware;
using Newtonsoft.Json;
using Xunit;

public class RateLimitHandlerTests : IDisposable
{

    // paired with 200 status code
    const string happyPathTestHeaders = @"{
        ""Access-Control-Allow-Origin"": [
            ""*""
        ],
	""Access-Control-Expose-Headers"": [
		""ETag, Link, Location, Retry-After, X-GitHub-OTP, X-RateLimit-Limit, X-RateLimit-Remaining, X-RateLimit-Used, X-RateLimit-Resource, X-RateLimit-Reset, X-OAuth-Scopes, X-Accepted-OAuth-Scopes, X-Poll-Interval, X-GitHub-Media-Type, X-GitHub-SSO, X-GitHub-Request-Id, Deprecation, Sunset""
	],
	""Cache-Control"": [
		""private, max-age=60, s-maxage=60""
	],
	""Connection"": [
		""keep-alive""
	],
	""Content-Security-Policy"": [
		""default-src 'none'""
	],
	""Content-Type"": [
		""application/json; charset=utf-8""
	],
	""Date"": [
		""Thu, 28 Mar 2024 20:20:55 GMT""
	],
	""Etag"": [
		""W/\""513ca5822992932a02050bbecb8c58a75cc211fb7ef0d597b6a3119c9fb45e94\""""
	],
	""Github-Authentication-Token-Expiration"": [
		""2024-04-27 20:14:21 UTC""
	],
	""Referrer-Policy"": [
		""origin-when-cross-origin, strict-origin-when-cross-origin""
	],
	""Server"": [
		""nginx/1.18.0 (Ubuntu)""
	],
	""Vary"": [
		""Accept, Authorization, Cookie, X-GitHub-OTP"",
		""Accept, X-Requested-With""
	],
	""X-Accepted-Oauth-Scopes"": [
		""""
	],
	""X-Content-Type-Options"": [
		""nosniff""
	],
	""X-Frame-Options"": [
		""deny""
	],
	""X-Github-Api-Version-Selected"": [
		""2022-11-28""
	],
	""X-Github-Media-Type"": [
		""github.v3""
	],
	""X-Github-Request-Id"": [
		""488c61a3-2ad6-4182-a16e-299d4cbd5c3c""
	],
	""X-Github-Sso"": [
		""partial-results; organizations=136,137,138""
	],
	""X-Glb-Log-Append"": [
		""rails_request_category=api rails_method=get rails_controller=api_repositories rails_action=/user/repos rails_catalog_service=github/repos rails_request_queued_time=691 rails_request_time=5747""
	],
	""X-Oauth-Scopes"": [
		""repo""
	],
	""X-Xss-Protection"": [
		""0""
	]
}";

    // example primary rate-limited headers (paired with 403 status code)
    const string primaryRateLimitHeaders = @"{
	""Access-Control-Allow-Origin"": [
		""*""
	],
	""Access-Control-Expose-Headers"": [
		""ETag, Link, Location, Retry-After, X-GitHub-OTP, X-RateLimit-Limit, X-RateLimit-Remaining, X-RateLimit-Used, X-RateLimit-Resource, X-RateLimit-Reset, X-OAuth-Scopes, X-Accepted-OAuth-Scopes, X-Poll-Interval, X-GitHub-Media-Type, X-GitHub-SSO, X-GitHub-Request-Id, Deprecation, Sunset""
	],
	""Connection"": [
		""keep-alive""
	],
	""Content-Security-Policy"": [
		""default-src 'none'""
	],
	""Content-Type"": [
		""application/json; charset=utf-8""
	],
	""Date"": [
		""Thu, 28 Mar 2024 20:16:11 GMT""
	],
	""Github-Authentication-Token-Expiration"": [
		""2024-04-27 20:14:21 UTC""
	],
	""Referrer-Policy"": [
		""origin-when-cross-origin, strict-origin-when-cross-origin""
	],
	""Server"": [
		""nginx/1.18.0 (Ubuntu)""
	],
	""Vary"": [
		""Accept, X-Requested-With""
	],
	""X-Accepted-Oauth-Scopes"": [
		""repo""
	],
	""X-Content-Type-Options"": [
		""nosniff""
	],
	""X-Frame-Options"": [
		""deny""
	],
	""X-Github-Media-Type"": [
		""github.v3""
	],
	""X-Github-Request-Id"": [
		""d283bbfe-d024-4334-9bd1-284ff860fe3e""
	],
	""X-Glb-Log-Append"": [
		""rails_request_category=api rails_method=get rails_controller=api_repositories rails_action=/user/repos rails_catalog_service=github/repos rails_request_queued_time=513 rails_request_time=13""
	],
	""X-Oauth-Scopes"": [
		""repo""
	],
	""X-Ratelimit-Limit"": [
		""100""
	],
	""X-Ratelimit-Remaining"": [
		""0""
	],
	""X-Ratelimit-Reset"": [
		""1711656978""
	],
	""X-Ratelimit-Resource"": [
		""core""
	],
	""X-Ratelimit-Used"": [
		""103""
	],
	""X-Xss-Protection"": [
		""0""
	]
}";

    // example secondary rate-limited headers (paired with 403 status code)
    const string secondaryRateLimitHeaders = @"{
	""Access-Control-Allow-Origin"": [
		""*""
	],
	""Access-Control-Expose-Headers"": [
		""ETag, Link, Location, Retry-After, X-GitHub-OTP, X-RateLimit-Limit, X-RateLimit-Remaining, X-RateLimit-Used, X-RateLimit-Resource, X-RateLimit-Reset, X-OAuth-Scopes, X-Accepted-OAuth-Scopes, X-Poll-Interval, X-GitHub-Media-Type, X-GitHub-SSO, X-GitHub-Request-Id, Deprecation, Sunset""
	],
	""Connection"": [
		""keep-alive""
	],
	""Content-Security-Policy"": [
		""default-src 'none'; base-uri 'self'; child-src github.localhost/assets-cdn/worker/; connect-src 'self' http://alambic.github.localhost https://www.githubstatus.com http://collector.github.localhost ws://127.0.0.1:35729/livereload ws://github.localhost raw.github.localhost api.github.localhost https://github-cloud.s3.amazonaws.com https://github-development-repository-file-5c1aeb.s3.amazonaws.com https://github-development-upload-manifest-file-7fdce7.s3.amazonaws.com https://github-development-user-asset-6210df.s3.amazonaws.com http://localhost:2206 http://objects-staging-origin.githubusercontent.com; font-src 'self'; form-action 'self' github.localhost copilot-workspace.githubnext.com http://objects-staging-origin.githubusercontent.com; frame-ancestors 'none'; frame-src http://viewscreen.githubusercontent.localhost:9494 http://notebooks.githubusercontent.localhost:8888; img-src 'self' data: http://alambic.github.localhost http://github.localhost:8081 https://identicons.github.com http://alambic.github.localhost/avatars https://github-dev.s3.amazonaws.com https://objects-staging.githubusercontent.com http://localhost:7071 https://github-development-user-asset-6210df.s3.amazonaws.com https://customer-stories-feed.github.com https://spotlights-feed.github.com http://objects-staging-origin.githubusercontent.com; manifest-src 'self'; media-src http://github.localhost http://alambic.github.localhost https://github-development-user-asset-6210df.s3.amazonaws.com; script-src 'self'; style-src 'unsafe-inline' 'self'; worker-src github.localhost/assets-cdn/worker/""
	],
	""Content-Type"": [
		""application/json; charset=utf-8""
	],
	""Date"": [
		""Thu, 28 Mar 2024 20:22:54 GMT""
	],
	""Gh-Limited-By"": [
		""time-based""
	],
	""Gh-Limited-Group"": [
		""api""
	],
	""Referrer-Policy"": [
		""origin-when-cross-origin, strict-origin-when-cross-origin""
	],
	""Retry-After"": [
		""5""
	],
	""Server"": [
		""nginx/1.18.0 (Ubuntu)""
	],
	""Vary"": [
		""Accept, X-Requested-With""
	],
	""X-Content-Type-Options"": [
		""nosniff""
	],
	""X-Frame-Options"": [
		""deny""
	],
	""X-Github-Media-Type"": [
		""github.v3; format=json""
	],
	""X-Github-Request-Id"": [
		""47dae098-2903-4a0a-835d-d7de10368f0f""
	],
	""X-Glb-Log-Append"": [
		""rails_request_category=api rails_method=get rails_controller=api_repositories rails_action=/user/repos rails_catalog_service=github/rest_api rails_request_queued_time=4 rails_request_time=12""
	],
	""X-Xss-Protection"": [
		""0""
	]
}";

    private readonly MockRateLimitHandler _testHttpMessageHandler;
    private readonly RateLimitHandler _rateLimitHandler;
    private readonly HttpMessageInvoker _invoker;

    // Much of this RateLimitHandlerTest code has been adapted from the
    // RetryHandlerTests code written by our colleagues at Kiota. Please see:
    // https://github.com/microsoft/kiota-http-dotnet/blob/6397579b16ba841048a3263a710f6c282c8a1c53/Microsoft.Kiota.Http.HttpClientLibrary.Tests/Middleware/RetryHandlerTests.cs
    public RateLimitHandlerTests()
    {
        _testHttpMessageHandler = new MockRateLimitHandler();
        _rateLimitHandler = new RateLimitHandler
        {
            InnerHandler = _testHttpMessageHandler
        };
        _invoker = new HttpMessageInvoker(_rateLimitHandler);
    }

    public void Dispose()
    {
        _invoker.Dispose();
        GC.SuppressFinalize(this);
    }

    [Fact]
    public async Task OkStatusShouldPassThrough()
    {
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://example.org/foo");
        var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK);

        var headersDictionary = JsonConvert.DeserializeObject<Dictionary<string, IEnumerable<string>>>(happyPathTestHeaders);

        if (headersDictionary != null)
        {
            foreach (var header in headersDictionary)
            {
                expectedResponse.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        }

        _testHttpMessageHandler.SetHttpResponse(expectedResponse);

        var response = await _invoker.SendAsync(httpRequestMessage, new CancellationToken());

        Assert.Same(response, expectedResponse);
        Assert.NotNull(response.RequestMessage);
        Assert.Same(response.RequestMessage, httpRequestMessage);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData(HttpStatusCode.TooManyRequests)]  // 429
    [InlineData(HttpStatusCode.Forbidden)] // 403
    public async Task ShouldRetryWithPrimaryRateLimitedHeaders(HttpStatusCode statusCode)
    {
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://example.org/foo");
        var firstResponse = new HttpResponseMessage(statusCode);

        var headersDictionary = JsonConvert.DeserializeObject<Dictionary<string, IEnumerable<string>>>(primaryRateLimitHeaders);

        if (headersDictionary != null)
        {
            foreach (var header in headersDictionary)
            {
                firstResponse.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        }

        var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK);
        this._testHttpMessageHandler.SetHttpResponse(firstResponse, expectedResponse);

        var response = await _invoker.SendAsync(httpRequestMessage, new CancellationToken());

        Assert.Same(response, expectedResponse);
        Assert.NotNull(response.RequestMessage);
        Assert.NotNull(response.RequestMessage.Headers);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData(HttpStatusCode.TooManyRequests)]  // 429
    [InlineData(HttpStatusCode.Forbidden)] // 403
    public async Task ShouldRetryWithSecondaryRateLimitedHeaders(HttpStatusCode statusCode)
    {
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://example.org/foo");
        var firstResponse = new HttpResponseMessage(statusCode);

        var headersDictionary = JsonConvert.DeserializeObject<Dictionary<string, IEnumerable<string>>>(secondaryRateLimitHeaders);

        if (headersDictionary != null)
        {
            foreach (var header in headersDictionary)
            {
                firstResponse.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        }

        var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK);
        this._testHttpMessageHandler.SetHttpResponse(firstResponse, expectedResponse);

        var response = await _invoker.SendAsync(httpRequestMessage, new CancellationToken());

        Assert.Same(response, expectedResponse);
        Assert.NotNull(response.RequestMessage);
        Assert.NotNull(response.RequestMessage.Headers);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public void IsRateLimited_200Response_NoRateLimitReturned()
    {
        var request = new HttpRequestMessage();
        var response = new HttpResponseMessage(HttpStatusCode.OK);
        var rateLimitHandlerOptions = new RateLimitHandlerOptions();

        var headersDictionary = JsonConvert.DeserializeObject<Dictionary<string, IEnumerable<string>>>(happyPathTestHeaders);

        if (headersDictionary != null)
        {
            foreach (var header in headersDictionary)
            {
                response.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        }

        var result = rateLimitHandlerOptions.IsRateLimited(request, response);

        Assert.Equal(RateLimitType.None, result);
    }

    [Fact]
    public void IsRateLimited_PrimaryRateLimit403_PrimaryRateLimitReturned()
    {
        var request = new HttpRequestMessage();
        var response = new HttpResponseMessage(HttpStatusCode.Forbidden);
        var rateLimitHandlerOptions = new RateLimitHandlerOptions();

        var headersDictionary = JsonConvert.DeserializeObject<Dictionary<string, IEnumerable<string>>>(primaryRateLimitHeaders);


        if (headersDictionary != null)
        {
            foreach (var header in headersDictionary)
            {
                response.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        }

        var result = rateLimitHandlerOptions.IsRateLimited(request, response);

        Assert.Equal(RateLimitType.Primary, result);
    }

    [Fact]
    public void IsRateLimited_PrimaryRateLimit429_PrimaryRateLimitReturned()
    {
        var request = new HttpRequestMessage();
        var response = new HttpResponseMessage(HttpStatusCode.TooManyRequests);
        var rateLimitHandlerOptions = new RateLimitHandlerOptions();

        var headersDictionary = JsonConvert.DeserializeObject<Dictionary<string, IEnumerable<string>>>(primaryRateLimitHeaders);

        if (headersDictionary != null)
        {
            foreach (var header in headersDictionary)
            {
                response.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        }

        var result = rateLimitHandlerOptions.IsRateLimited(request, response);

        Assert.Equal(RateLimitType.Primary, result);
    }

    [Fact]
    public void IsRateLimited_SecondaryRateLimit403_SecondaryRateLimitReturned()
    {
        var request = new HttpRequestMessage();
        var response = new HttpResponseMessage(HttpStatusCode.Forbidden);
        var rateLimitHandlerOptions = new RateLimitHandlerOptions();

        var headersDictionary = JsonConvert.DeserializeObject<Dictionary<string, IEnumerable<string>>>(secondaryRateLimitHeaders);

        if (headersDictionary != null)
        {
            foreach (var header in headersDictionary)
            {
                response.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        }

        var result = rateLimitHandlerOptions.IsRateLimited(request, response);

        Assert.Equal(RateLimitType.Secondary, result);
    }

    [Fact]
    public void IsRateLimited_SecondaryRateLimit429_SecondaryRateLimitReturned()
    {
        var request = new HttpRequestMessage();
        var response = new HttpResponseMessage(HttpStatusCode.TooManyRequests);
        var rateLimitHandlerOptions = new RateLimitHandlerOptions();

        var headersDictionary = JsonConvert.DeserializeObject<Dictionary<string, IEnumerable<string>>>(secondaryRateLimitHeaders);

        if (headersDictionary != null)
        {
            foreach (var header in headersDictionary)
            {
                response.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        }

        var result = rateLimitHandlerOptions.IsRateLimited(request, response);

        Assert.Equal(RateLimitType.Secondary, result);
    }
}

// Test Specific Subclass used for testing the private internals of RateLimitHandler
public class RateLimitHandlerSubclass : RateLimitHandler
{
    [Fact]
    public void ParseRateLimit_EmptyHeaders_ReturnsNull()
    {
        var response = new HttpResponseMessage();

        var limit = ParseRateLimit(response, DateTime.Now);

        Assert.Null(limit);
    }

    [Fact]
    public void ParseRateLimit_WithRetryAfter_ReturnsCorrectTime()
    {
        var response = new HttpResponseMessage();
        var artificialFuture = new DateTime(2000, 1, 1, 1, 0, 0, DateTimeKind.Utc);
        response.Headers.RetryAfter = new RetryConditionHeaderValue(artificialFuture);
        var artificialNow = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        var timeToWait = ParseRateLimit(response, artificialNow);

        Assert.Equal(1, timeToWait?.TotalHours);
    }

    [Fact]
    public void ParseRateLimit_WithXRateLimitResetKey_ReturnsCorrectTime()
    {
        var response = new HttpResponseMessage();
        response.Headers.Add(XRateLimitResetKey, "946688400"); // one hour past the millenium
        var artificialNow = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc); // 946684800 in unix epoch time

        var timeToWait = ParseRateLimit(response, artificialNow);

        Assert.Equal(1, timeToWait?.TotalHours);
    }

    [Fact]
    public void ParseRetryAfterHeader_NullRetryAfter_ReturnsNull()
    {
        var response = new HttpResponseMessage();
        var artificialNow = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        var timeToWait = ParseRetryAfterHeader(response, artificialNow);

        Assert.Null(timeToWait);
    }

    [Fact]
    public void ParseRetryAfterHeader_WithDateTime_ReturnsCorrectTime()
    {
        var response = new HttpResponseMessage();
        var artificialFuture = new DateTime(2000, 1, 1, 1, 0, 0, DateTimeKind.Utc);
        response.Headers.RetryAfter = new RetryConditionHeaderValue(artificialFuture);
        var artificialNow = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        var timeToWait = ParseRetryAfterHeader(response, artificialNow);

        Assert.Equal(1, timeToWait?.TotalHours);
    }

    [Fact]
    public void ParseXRateLimitReset_NullXRateLimitResetKey_ReturnsNull()
    {
        var response = new HttpResponseMessage();
        response.Headers.Add(XRateLimitResetKey, "");
        var artificialNow = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        var timeToWait = ParseXRateLimitReset(response, artificialNow);

        Assert.Null(timeToWait);
    }

    [Fact]
    public void ParseXRateLimitReset_WithXRateLimitResetKey_ReturnsCorrectTime()
    {
        var response = new HttpResponseMessage();
        response.Headers.Add(XRateLimitResetKey, "946688400"); // one hour past the millenium
        var artificialNow = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc); // 946684800 in unix epoch time

        var timeToWait = ParseXRateLimitReset(response, artificialNow);

        Assert.Equal(1, timeToWait?.TotalHours);
    }
}
