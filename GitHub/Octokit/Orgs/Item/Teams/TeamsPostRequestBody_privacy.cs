// <auto-generated/>
using System.Runtime.Serialization;
using System;
namespace GitHub.Octokit.Orgs.Item.Teams {
    /// <summary>The level of privacy this team should have. The options are:  **For a non-nested team:**   * `secret` - only visible to organization owners and members of this team.   * `closed` - visible to all members of this organization.  Default: `secret`  **For a parent or child team:**   * `closed` - visible to all members of this organization.  Default for child team: `closed`</summary>
    public enum TeamsPostRequestBody_privacy {
        [EnumMember(Value = "secret")]
        Secret,
        [EnumMember(Value = "closed")]
        Closed,
    }
}