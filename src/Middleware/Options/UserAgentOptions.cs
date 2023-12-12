using Microsoft.Kiota.Abstractions;

namespace GitHub.Client.Middleware.Options;

public class UserAgentOptions : IRequestOption
{
  private static string GetProductVersion() => "0.0.0";
  public string ProductName { get; set; } = "dotnet-sdk";
  public string ProductVersion { get; set; } = GetProductVersion();
}