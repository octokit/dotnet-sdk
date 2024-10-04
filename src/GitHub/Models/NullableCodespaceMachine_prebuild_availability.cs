// <auto-generated/>
using System.Runtime.Serialization;
using System;
namespace GitHub.Models
{
    /// <summary>Whether a prebuild is currently available when creating a codespace for this machine and repository. If a branch was not specified as a ref, the default branch will be assumed. Value will be &quot;null&quot; if prebuilds are not supported or prebuild availability could not be determined. Value will be &quot;none&quot; if no prebuild is available. Latest values &quot;ready&quot; and &quot;in_progress&quot; indicate the prebuild availability status.</summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.19.0")]
    public enum NullableCodespaceMachine_prebuild_availability
    {
        [EnumMember(Value = "none")]
        #pragma warning disable CS1591
        None,
        #pragma warning restore CS1591
        [EnumMember(Value = "ready")]
        #pragma warning disable CS1591
        Ready,
        #pragma warning restore CS1591
        [EnumMember(Value = "in_progress")]
        #pragma warning disable CS1591
        In_progress,
        #pragma warning restore CS1591
    }
}
