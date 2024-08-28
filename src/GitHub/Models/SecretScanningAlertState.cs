// <auto-generated/>
using System.Runtime.Serialization;
using System;
namespace GitHub.Models
{
    /// <summary>Sets the state of the secret scanning alert. You must provide `resolution` when you set the state to `resolved`.</summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.17.0")]
    public enum SecretScanningAlertState
    {
        [EnumMember(Value = "open")]
        #pragma warning disable CS1591
        Open,
        #pragma warning restore CS1591
        [EnumMember(Value = "resolved")]
        #pragma warning disable CS1591
        Resolved,
        #pragma warning restore CS1591
    }
}
