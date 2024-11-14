// Copyright (c) GitHub 2023-2024 - Licensed as MIT.

namespace GitHub.Octokit.Client.Middleware;

/// <summary>
/// Specifies the type of rate limit.
/// </summary>
public enum RateLimitType
{
    /// <summary>
    /// No rate limit.
    /// </summary>
    None,

    /// <summary>
    /// Primary rate limit.
    /// </summary>
    Primary,

    /// <summary>
    /// Secondary rate limit.
    /// </summary>
    Secondary
}
