// Copyright (c) GitHub 2023 � Licensed as MIT.

using Microsoft.Kiota.Abstractions;

namespace GitHub.Octokit.Client.Middleware.Options;

/// <summary>
/// Represents the user agent options for the middleware.
/// </summary>
public class UserAgentOptions : IRequestOption
{
    /// <summary>
    /// Gets or sets the product name used in the user agent request header.
    /// Defaults to <c>"dotnet-sdk"</c>.
    /// </summary>
    public string ProductName { get; set; } = "dotnet-sdk";

    /// <summary>
    /// Gets or sets the product version used in the user agent request header.
    /// </summary>
    public string ProductVersion { get; set; } = GetProductVersion();

    private static string GetProductVersion() => "0.0.0";
}