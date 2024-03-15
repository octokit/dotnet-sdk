// <auto-generated/>
using System.Runtime.Serialization;
using System;
namespace GitHub.Models {
    /// <summary>The phase of the lifecycle that the check is currently in. Statuses of waiting, requested, and pending are reserved for GitHub Actions check runs.</summary>
    public enum CheckRun_status {
        [EnumMember(Value = "queued")]
        Queued,
        [EnumMember(Value = "in_progress")]
        In_progress,
        [EnumMember(Value = "completed")]
        Completed,
        [EnumMember(Value = "waiting")]
        Waiting,
        [EnumMember(Value = "requested")]
        Requested,
        [EnumMember(Value = "pending")]
        Pending,
    }
}
