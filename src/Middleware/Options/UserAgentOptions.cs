// Copyright (c) GitHub 2023-2024 - Licensed as MIT.

using Microsoft.Kiota.Abstractions;

namespace GitHub.Octokit.Client.Middleware.Options;

/// <summary>
/// Represents the user agent options for the middleware.
/// </summary>
public class UserAgentOptions : IRequestOption
{

    private const string DefaultProductName = "GitHub.Octokit.dotnet-sdk";
    private const string DefaultProductVersion = "0.0.0";

    /// <summary>
    /// Gets or sets the product name used in the user agent request header.
    /// Defaults to <c>"GitHub.Octokit.dotnet-sdk"</c>.
    /// </summary>
    public string? ProductName { get; set; } = DefaultProductName;

    /// <summary>
    /// Gets or sets the product version used in the user agent request header.
    /// </summary>
    public string? ProductVersion { get; set; } = DefaultProductVersion;

    public static string GetFullSDKVersion() => DefaultProductName + ":" + DefaultProductVersion;

}
