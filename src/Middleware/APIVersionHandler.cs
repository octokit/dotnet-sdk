
using GitHub.Client.Middleware.Options;
using Microsoft.Kiota.Http.HttpClientLibrary.Extensions;

namespace GitHub.Client.Middleware;

/// <summary>
/// Represents a handler that adds the API version header to outgoing HTTP requests.
/// </summary>
class APIVersionHandler : DelegatingHandler
{
  private const string ApiVersionHeaderKey = "X-GitHub-Api-Version";

  private readonly APIVersionOptions _apiVersionOptions;

  public APIVersionHandler(APIVersionOptions? apiVersionOptions = null)
  {
      _apiVersionOptions = apiVersionOptions ?? new APIVersionOptions();
  }

  protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
  {
    if (request == null){
      throw new ArgumentNullException(nameof(request));
    }

    var apiVersionHandlerOption = request.GetRequestOption<APIVersionOptions>() ?? _apiVersionOptions;

    if (!request.Headers.Contains(ApiVersionHeaderKey) || !request.Headers.GetValues(ApiVersionHeaderKey).Any(x => apiVersionHandlerOption.APIVersion.Equals(x, StringComparison.OrdinalIgnoreCase)))
    {
      request.Headers.Add(ApiVersionHeaderKey, apiVersionHandlerOption.APIVersion);
    }
    return base.SendAsync(request, cancellationToken);
  }
}
