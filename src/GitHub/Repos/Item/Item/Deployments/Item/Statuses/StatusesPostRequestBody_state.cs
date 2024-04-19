// <auto-generated/>
using System.Runtime.Serialization;
using System;
namespace GitHub.Repos.Item.Item.Deployments.Item.Statuses {
    /// <summary>The state of the status. When you set a transient deployment to `inactive`, the deployment will be shown as `destroyed` in GitHub.</summary>
    public enum StatusesPostRequestBody_state
    {
        [EnumMember(Value = "error")]
        #pragma warning disable CS1591
        Error,
        #pragma warning restore CS1591
        [EnumMember(Value = "failure")]
        #pragma warning disable CS1591
        Failure,
        #pragma warning restore CS1591
        [EnumMember(Value = "inactive")]
        #pragma warning disable CS1591
        Inactive,
        #pragma warning restore CS1591
        [EnumMember(Value = "in_progress")]
        #pragma warning disable CS1591
        In_progress,
        #pragma warning restore CS1591
        [EnumMember(Value = "queued")]
        #pragma warning disable CS1591
        Queued,
        #pragma warning restore CS1591
        [EnumMember(Value = "pending")]
        #pragma warning disable CS1591
        Pending,
        #pragma warning restore CS1591
        [EnumMember(Value = "success")]
        #pragma warning disable CS1591
        Success,
        #pragma warning restore CS1591
    }
}
