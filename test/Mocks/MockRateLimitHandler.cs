// Much of this RateLimitHandlerTest code has been adapted from the
// MockRedirectHandler code written by our colleagues at Kiota. Please see:
// https://github.com/microsoft/kiota-http-dotnet/blob/6397579b16ba841048a3263a710f6c282c8a1c53/Microsoft.Kiota.Http.HttpClientLibrary.Tests/Mocks/MockRedirectHandler.cs
public class MockRateLimitHandler : HttpMessageHandler
{
    private HttpResponseMessage? Response1
    {
        get; set;
    }

    private HttpResponseMessage? Response2
    {
        get; set;
    }

    private bool _response1Sent = false;

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (!_response1Sent)
        {
            _response1Sent = true;
            if (Response1 != null)
            {
                Response1.RequestMessage = request;
                return await Task.FromResult(Response1);
            }
            else
            {
                return await Task.FromResult(new HttpResponseMessage());
            }
        }
        else
        {
            _response1Sent = false;
            if (Response2 != null)
            {
                Response2.RequestMessage = request;
                return await Task.FromResult(Response2);
            }
            else
            {
                return await Task.FromResult(new HttpResponseMessage());
            }
        }
    }

    public void SetHttpResponse(HttpResponseMessage response1, HttpResponseMessage? response2 = null)
    {
        this._response1Sent = false;
        this.Response1 = response1;
        this.Response2 = response2;
    }
}
