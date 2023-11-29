using Microsoft.Kiota.Abstractions;

namespace GitHub.Client.Middleware.Options;

public class APIVersionOptions : IRequestOption
{

    public string APIVersion { get; set; } = GetAPIVersion();

  private static string GetAPIVersion() =>
    //TODO : Get the version from the generator
    "2022-11-28";
}