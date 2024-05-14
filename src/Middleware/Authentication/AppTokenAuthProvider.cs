// Copyright (c) GitHub 2023-2024 - Licensed as MIT.

using Microsoft.Kiota.Abstractions;
using Polly.Retry;
using System.Text.Json;
using GitHub.Octokit.Client.Middleware.Options;
using System.Net.Http.Headers;
using System.Net;
using Polly;


namespace GitHub.Octokit.Client.Authentication;

public class AppTokenAuthProvider : DelegatingHandler, IAppTokenAuthProvider
{
  private const string AuthorizationHeaderKey = "Authorization";
  private IAppTokenAuthProvider AppTokenProvider;
  private readonly AsyncRetryPolicy<HttpResponseMessage> _policy;

  public string installationId { get; set; }

  public AppTokenAuthProvider(IAppTokenAuthProvider appTokenProvider, string installationId)
  {

    AppTokenProvider = appTokenProvider;
    this.installationId = installationId;

    _policy = Policy
        .HandleResult<HttpResponseMessage>(r => r.StatusCode is HttpStatusCode.Unauthorized or HttpStatusCode.Forbidden)
        .RetryAsync((_, _, context) => AppTokenProvider.RefreshTokenAsync(context["installationId"].ToString() ?? ""));
  }

  protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        => await _policy.ExecuteAsync(async () =>
        {
          request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await AppTokenProvider.GetAppAccessTokenAsync("jwtToken", "installationId"));
          return await base.SendAsync(request, cancellationToken);
        });

  // Implement
  public Task AuthenticateRequestAsync(RequestInformation? request, Dictionary<string, object>? additionalAuthenticationContext = null, CancellationToken cancellationToken = default)
  {
    ArgumentNullException.ThrowIfNull(request);

    if (!request.Headers.ContainsKey(AuthorizationHeaderKey))
    {
      request.Headers.Add(AuthorizationHeaderKey, $"Bearer {"Token"}");
    }

    return Task.CompletedTask;
  }



  public async Task<string?> GetAppAccessTokenAsync(string jwtToken, string installationId)
  {

    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Accept", "application/vnd.github+json");
    client.DefaultRequestHeaders.Add("X-GitHub-Api-Version", APIVersionOptions.GetAPIVersion());
    client.DefaultRequestHeaders.Add("User-Agent", UserAgentOptions.GetFullSDKVersion());
    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwtToken}");

    // Rework 
    var resp = await client.PostAsync($"https://api.github.com/app/installations/{installationId}/access_tokens", null);
    var body = await resp.Content.ReadAsStringAsync();

    if (!resp.IsSuccessStatusCode)
    {
      throw new Exception($"Error: {resp.StatusCode}, Body: {body}");
    }

    // var respBody = JsonSerializer.Deserialize<Dictionary<string, object>>(body);
    // var tokenElement = (JsonElement?)respBody?["token"];
    // return tokenElement?.ValueKind == JsonValueKind.String ? tokenElement?.GetString() : "";
    return "token";
  }

  // Implement
  public Task<string> RefreshTokenAsync(string installationId) => throw new NotImplementedException();
}
