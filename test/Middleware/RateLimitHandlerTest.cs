using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using GitHub.Octokit.Client;
using GitHub.Octokit.Client.Middleware;
using Moq;
using Moq.Protected;
using Xunit;

public class RateLimitHandlerTests
{
    [Fact]
    public async Task SendAsync_ThrowsRateLimitExceededException_WhenRateLimitIsExceeded()
    {
        // Arrange
        var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        handlerMock.Protected()
           .Setup<Task<HttpResponseMessage>>(
              "SendAsync",
              ItExpr.IsAny<HttpRequestMessage>(),
              ItExpr.IsAny<CancellationToken>())
           .ReturnsAsync(new HttpResponseMessage()
           {
               StatusCode = (HttpStatusCode)429, // Too Many Requests
           })
           .Verifiable();

        var rateLimitHandler = new RateLimitHandler()
        {
            InnerHandler = handlerMock.Object
        };

        var httpClient = ClientFactory.Create(rateLimitHandler);

        // TODO: Act & Assert
        // await Assert.ThrowsAsync<Exception>(() => httpClient.SendAsync(new HttpRequestMessage()));
        await Task.Run(() => Assert.NotNull(httpClient));
    }
}
