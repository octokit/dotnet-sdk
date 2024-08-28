// <auto-generated/>
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace GitHub.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.17.0")]
    #pragma warning disable CS1591
    public partial class CodeScanningAlert : IAdditionalDataHolder, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The time that the alert was created in ISO 8601 format: `YYYY-MM-DDTHH:MM:SSZ`.</summary>
        public DateTimeOffset? CreatedAt { get; private set; }
        /// <summary>The time that the alert was dismissed in ISO 8601 format: `YYYY-MM-DDTHH:MM:SSZ`.</summary>
        public DateTimeOffset? DismissedAt { get; private set; }
        /// <summary>A GitHub user.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::GitHub.Models.NullableSimpleUser? DismissedBy { get; set; }
#nullable restore
#else
        public global::GitHub.Models.NullableSimpleUser DismissedBy { get; set; }
#endif
        /// <summary>The dismissal comment associated with the dismissal of the alert.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? DismissedComment { get; set; }
#nullable restore
#else
        public string DismissedComment { get; set; }
#endif
        /// <summary>**Required when the state is dismissed.** The reason for dismissing or closing the alert.</summary>
        public global::GitHub.Models.CodeScanningAlertDismissedReason? DismissedReason { get; set; }
        /// <summary>The time that the alert was no longer detected and was considered fixed in ISO 8601 format: `YYYY-MM-DDTHH:MM:SSZ`.</summary>
        public DateTimeOffset? FixedAt { get; private set; }
        /// <summary>The GitHub URL of the alert resource.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? HtmlUrl { get; private set; }
#nullable restore
#else
        public string HtmlUrl { get; private set; }
#endif
        /// <summary>The REST API URL for fetching the list of instances for an alert.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? InstancesUrl { get; private set; }
#nullable restore
#else
        public string InstancesUrl { get; private set; }
#endif
        /// <summary>The most_recent_instance property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::GitHub.Models.CodeScanningAlertInstance? MostRecentInstance { get; set; }
#nullable restore
#else
        public global::GitHub.Models.CodeScanningAlertInstance MostRecentInstance { get; set; }
#endif
        /// <summary>The security alert number.</summary>
        public int? Number { get; private set; }
        /// <summary>The rule property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::GitHub.Models.CodeScanningAlertRule? Rule { get; set; }
#nullable restore
#else
        public global::GitHub.Models.CodeScanningAlertRule Rule { get; set; }
#endif
        /// <summary>State of a code scanning alert.</summary>
        public global::GitHub.Models.CodeScanningAlertState? State { get; set; }
        /// <summary>The tool property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::GitHub.Models.CodeScanningAnalysisTool? Tool { get; set; }
#nullable restore
#else
        public global::GitHub.Models.CodeScanningAnalysisTool Tool { get; set; }
#endif
        /// <summary>The time that the alert was last updated in ISO 8601 format: `YYYY-MM-DDTHH:MM:SSZ`.</summary>
        public DateTimeOffset? UpdatedAt { get; private set; }
        /// <summary>The REST API URL of the alert resource.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Url { get; private set; }
#nullable restore
#else
        public string Url { get; private set; }
#endif
        /// <summary>
        /// Instantiates a new <see cref="global::GitHub.Models.CodeScanningAlert"/> and sets the default values.
        /// </summary>
        public CodeScanningAlert()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::GitHub.Models.CodeScanningAlert"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::GitHub.Models.CodeScanningAlert CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::GitHub.Models.CodeScanningAlert();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "created_at", n => { CreatedAt = n.GetDateTimeOffsetValue(); } },
                { "dismissed_at", n => { DismissedAt = n.GetDateTimeOffsetValue(); } },
                { "dismissed_by", n => { DismissedBy = n.GetObjectValue<global::GitHub.Models.NullableSimpleUser>(global::GitHub.Models.NullableSimpleUser.CreateFromDiscriminatorValue); } },
                { "dismissed_comment", n => { DismissedComment = n.GetStringValue(); } },
                { "dismissed_reason", n => { DismissedReason = n.GetEnumValue<global::GitHub.Models.CodeScanningAlertDismissedReason>(); } },
                { "fixed_at", n => { FixedAt = n.GetDateTimeOffsetValue(); } },
                { "html_url", n => { HtmlUrl = n.GetStringValue(); } },
                { "instances_url", n => { InstancesUrl = n.GetStringValue(); } },
                { "most_recent_instance", n => { MostRecentInstance = n.GetObjectValue<global::GitHub.Models.CodeScanningAlertInstance>(global::GitHub.Models.CodeScanningAlertInstance.CreateFromDiscriminatorValue); } },
                { "number", n => { Number = n.GetIntValue(); } },
                { "rule", n => { Rule = n.GetObjectValue<global::GitHub.Models.CodeScanningAlertRule>(global::GitHub.Models.CodeScanningAlertRule.CreateFromDiscriminatorValue); } },
                { "state", n => { State = n.GetEnumValue<global::GitHub.Models.CodeScanningAlertState>(); } },
                { "tool", n => { Tool = n.GetObjectValue<global::GitHub.Models.CodeScanningAnalysisTool>(global::GitHub.Models.CodeScanningAnalysisTool.CreateFromDiscriminatorValue); } },
                { "updated_at", n => { UpdatedAt = n.GetDateTimeOffsetValue(); } },
                { "url", n => { Url = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<global::GitHub.Models.NullableSimpleUser>("dismissed_by", DismissedBy);
            writer.WriteStringValue("dismissed_comment", DismissedComment);
            writer.WriteEnumValue<global::GitHub.Models.CodeScanningAlertDismissedReason>("dismissed_reason", DismissedReason);
            writer.WriteObjectValue<global::GitHub.Models.CodeScanningAlertInstance>("most_recent_instance", MostRecentInstance);
            writer.WriteObjectValue<global::GitHub.Models.CodeScanningAlertRule>("rule", Rule);
            writer.WriteEnumValue<global::GitHub.Models.CodeScanningAlertState>("state", State);
            writer.WriteObjectValue<global::GitHub.Models.CodeScanningAnalysisTool>("tool", Tool);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
