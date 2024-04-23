// <auto-generated/>
using System.Runtime.Serialization;
using System;
namespace GitHub.Models {
    /// <summary>The result of the rule evaluations for rules with the `active` and `evaluate` enforcement statuses, demonstrating whether rules would pass or fail if all rules in the rule suite were `active`.</summary>
    public enum RuleSuites_evaluation_result
    {
        [EnumMember(Value = "pass")]
        #pragma warning disable CS1591
        Pass,
        #pragma warning restore CS1591
        [EnumMember(Value = "fail")]
        #pragma warning disable CS1591
        Fail,
        #pragma warning restore CS1591
    }
}
