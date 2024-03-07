// Copyright (c) GitHub 2023-2024 - Licensed as MIT.

using Microsoft.Kiota.Abstractions;

namespace GitHub.Octokit.Client.Middleware.Options;

/// <summary>
/// Represents the API version options for the middleware.
/// </summary>
public class APIVersionOptions : IRequestOption
{
    /// <summary>
    /// Gets or sets the API version for the request header.
    /// </summary>
    public string APIVersion { get; set; } = GetAPIVersion();

    private static string GetAPIVersion() =>
      //TODO : Get the version from the generator
      "2022-11-28";
}
