// <auto-generated/>
using System.Runtime.Serialization;
using System;
namespace GitHub.Models {
    /// <summary>The reason for a failure of the variant analysis. This is only available if the variant analysis has failed.</summary>
    public enum CodeScanningVariantAnalysis_failure_reason
    {
        [EnumMember(Value = "no_repos_queried")]
        #pragma warning disable CS1591
        No_repos_queried,
        #pragma warning restore CS1591
        [EnumMember(Value = "actions_workflow_run_failed")]
        #pragma warning disable CS1591
        Actions_workflow_run_failed,
        #pragma warning restore CS1591
        [EnumMember(Value = "internal_error")]
        #pragma warning disable CS1591
        Internal_error,
        #pragma warning restore CS1591
    }
}
