// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System;
namespace GitHub.Models
{
    /// <summary>
    /// Information about a Copilot Business seat assignment for a user, team, or organization.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.18.0")]
    public partial class CopilotSeatDetails : IParsable
    {
        /// <summary>The assignee that has been granted access to GitHub Copilot.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::GitHub.Models.CopilotSeatDetails_assignee? Assignee { get; set; }
#nullable restore
#else
        public global::GitHub.Models.CopilotSeatDetails_assignee Assignee { get; set; }
#endif
        /// <summary>The team through which the assignee is granted access to GitHub Copilot, if applicable.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::GitHub.Models.CopilotSeatDetails.CopilotSeatDetails_assigning_team? AssigningTeam { get; set; }
#nullable restore
#else
        public global::GitHub.Models.CopilotSeatDetails.CopilotSeatDetails_assigning_team AssigningTeam { get; set; }
#endif
        /// <summary>Timestamp of when the assignee was last granted access to GitHub Copilot, in ISO 8601 format.</summary>
        public DateTimeOffset? CreatedAt { get; set; }
        /// <summary>Timestamp of user&apos;s last GitHub Copilot activity, in ISO 8601 format.</summary>
        public DateTimeOffset? LastActivityAt { get; set; }
        /// <summary>Last editor that was used by the user for a GitHub Copilot completion.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? LastActivityEditor { get; set; }
#nullable restore
#else
        public string LastActivityEditor { get; set; }
#endif
        /// <summary>The organization to which this seat belongs.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::GitHub.Models.CopilotSeatDetails_organization? Organization { get; set; }
#nullable restore
#else
        public global::GitHub.Models.CopilotSeatDetails_organization Organization { get; set; }
#endif
        /// <summary>The pending cancellation date for the seat, in `YYYY-MM-DD` format. This will be null unless the assignee&apos;s Copilot access has been canceled during the current billing cycle. If the seat has been cancelled, this corresponds to the start of the organization&apos;s next billing cycle.</summary>
        public Date? PendingCancellationDate { get; set; }
        /// <summary>Timestamp of when the assignee&apos;s GitHub Copilot access was last updated, in ISO 8601 format.</summary>
        public DateTimeOffset? UpdatedAt { get; set; }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::GitHub.Models.CopilotSeatDetails"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::GitHub.Models.CopilotSeatDetails CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::GitHub.Models.CopilotSeatDetails();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "assignee", n => { Assignee = n.GetObjectValue<global::GitHub.Models.CopilotSeatDetails_assignee>(global::GitHub.Models.CopilotSeatDetails_assignee.CreateFromDiscriminatorValue); } },
                { "assigning_team", n => { AssigningTeam = n.GetObjectValue<global::GitHub.Models.CopilotSeatDetails.CopilotSeatDetails_assigning_team>(global::GitHub.Models.CopilotSeatDetails.CopilotSeatDetails_assigning_team.CreateFromDiscriminatorValue); } },
                { "created_at", n => { CreatedAt = n.GetDateTimeOffsetValue(); } },
                { "last_activity_at", n => { LastActivityAt = n.GetDateTimeOffsetValue(); } },
                { "last_activity_editor", n => { LastActivityEditor = n.GetStringValue(); } },
                { "organization", n => { Organization = n.GetObjectValue<global::GitHub.Models.CopilotSeatDetails_organization>(global::GitHub.Models.CopilotSeatDetails_organization.CreateFromDiscriminatorValue); } },
                { "pending_cancellation_date", n => { PendingCancellationDate = n.GetDateValue(); } },
                { "updated_at", n => { UpdatedAt = n.GetDateTimeOffsetValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<global::GitHub.Models.CopilotSeatDetails_assignee>("assignee", Assignee);
            writer.WriteObjectValue<global::GitHub.Models.CopilotSeatDetails.CopilotSeatDetails_assigning_team>("assigning_team", AssigningTeam);
            writer.WriteDateTimeOffsetValue("created_at", CreatedAt);
            writer.WriteDateTimeOffsetValue("last_activity_at", LastActivityAt);
            writer.WriteStringValue("last_activity_editor", LastActivityEditor);
            writer.WriteObjectValue<global::GitHub.Models.CopilotSeatDetails_organization>("organization", Organization);
            writer.WriteDateValue("pending_cancellation_date", PendingCancellationDate);
            writer.WriteDateTimeOffsetValue("updated_at", UpdatedAt);
        }
        /// <summary>
        /// Composed type wrapper for classes <see cref="global::GitHub.Models.EnterpriseTeam"/>, <see cref="global::GitHub.Models.Team"/>
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.18.0")]
        public partial class CopilotSeatDetails_assigning_team : IComposedTypeWrapper, IParsable
        {
            /// <summary>Composed type representation for type <see cref="global::GitHub.Models.EnterpriseTeam"/></summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public global::GitHub.Models.EnterpriseTeam? EnterpriseTeam { get; set; }
#nullable restore
#else
            public global::GitHub.Models.EnterpriseTeam EnterpriseTeam { get; set; }
#endif
            /// <summary>Composed type representation for type <see cref="global::GitHub.Models.Team"/></summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public global::GitHub.Models.Team? Team { get; set; }
#nullable restore
#else
            public global::GitHub.Models.Team Team { get; set; }
#endif
            /// <summary>
            /// Creates a new instance of the appropriate class based on discriminator value
            /// </summary>
            /// <returns>A <see cref="global::GitHub.Models.CopilotSeatDetails.CopilotSeatDetails_assigning_team"/></returns>
            /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
            public static global::GitHub.Models.CopilotSeatDetails.CopilotSeatDetails_assigning_team CreateFromDiscriminatorValue(IParseNode parseNode)
            {
                _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
                var mappingValue = parseNode.GetChildNode("")?.GetStringValue();
                var result = new global::GitHub.Models.CopilotSeatDetails.CopilotSeatDetails_assigning_team();
                if("enterprise-team".Equals(mappingValue, StringComparison.OrdinalIgnoreCase))
                {
                    result.EnterpriseTeam = new global::GitHub.Models.EnterpriseTeam();
                }
                else if("team".Equals(mappingValue, StringComparison.OrdinalIgnoreCase))
                {
                    result.Team = new global::GitHub.Models.Team();
                }
                return result;
            }
            /// <summary>
            /// The deserialization information for the current model
            /// </summary>
            /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
            public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
            {
                if(EnterpriseTeam != null)
                {
                    return EnterpriseTeam.GetFieldDeserializers();
                }
                else if(Team != null)
                {
                    return Team.GetFieldDeserializers();
                }
                return new Dictionary<string, Action<IParseNode>>();
            }
            /// <summary>
            /// Serializes information the current object
            /// </summary>
            /// <param name="writer">Serialization writer to use to serialize this model</param>
            public virtual void Serialize(ISerializationWriter writer)
            {
                _ = writer ?? throw new ArgumentNullException(nameof(writer));
                if(EnterpriseTeam != null)
                {
                    writer.WriteObjectValue<global::GitHub.Models.EnterpriseTeam>(null, EnterpriseTeam);
                }
                else if(Team != null)
                {
                    writer.WriteObjectValue<global::GitHub.Models.Team>(null, Team);
                }
            }
        }
    }
}
#pragma warning restore CS0618
