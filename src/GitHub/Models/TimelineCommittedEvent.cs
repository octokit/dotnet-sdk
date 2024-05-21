// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace GitHub.Models
{
    /// <summary>
    /// Timeline Committed Event
    /// </summary>
    public class TimelineCommittedEvent : IAdditionalDataHolder, IParsable
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Identifying information for the git-user</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public TimelineCommittedEvent_author? Author { get; set; }
#nullable restore
#else
        public TimelineCommittedEvent_author Author { get; set; }
#endif
        /// <summary>Identifying information for the git-user</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public TimelineCommittedEvent_committer? Committer { get; set; }
#nullable restore
#else
        public TimelineCommittedEvent_committer Committer { get; set; }
#endif
        /// <summary>The event property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Event { get; set; }
#nullable restore
#else
        public string Event { get; set; }
#endif
        /// <summary>The html_url property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? HtmlUrl { get; set; }
#nullable restore
#else
        public string HtmlUrl { get; set; }
#endif
        /// <summary>Message describing the purpose of the commit</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Message { get; set; }
#nullable restore
#else
        public string Message { get; set; }
#endif
        /// <summary>The node_id property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? NodeId { get; set; }
#nullable restore
#else
        public string NodeId { get; set; }
#endif
        /// <summary>The parents property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<TimelineCommittedEvent_parents>? Parents { get; set; }
#nullable restore
#else
        public List<TimelineCommittedEvent_parents> Parents { get; set; }
#endif
        /// <summary>SHA for the commit</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Sha { get; set; }
#nullable restore
#else
        public string Sha { get; set; }
#endif
        /// <summary>The tree property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public TimelineCommittedEvent_tree? Tree { get; set; }
#nullable restore
#else
        public TimelineCommittedEvent_tree Tree { get; set; }
#endif
        /// <summary>The url property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Url { get; set; }
#nullable restore
#else
        public string Url { get; set; }
#endif
        /// <summary>The verification property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public TimelineCommittedEvent_verification? Verification { get; set; }
#nullable restore
#else
        public TimelineCommittedEvent_verification Verification { get; set; }
#endif
        /// <summary>
        /// Instantiates a new <see cref="TimelineCommittedEvent"/> and sets the default values.
        /// </summary>
        public TimelineCommittedEvent()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="TimelineCommittedEvent"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static TimelineCommittedEvent CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new TimelineCommittedEvent();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "author", n => { Author = n.GetObjectValue<TimelineCommittedEvent_author>(TimelineCommittedEvent_author.CreateFromDiscriminatorValue); } },
                { "committer", n => { Committer = n.GetObjectValue<TimelineCommittedEvent_committer>(TimelineCommittedEvent_committer.CreateFromDiscriminatorValue); } },
                { "event", n => { Event = n.GetStringValue(); } },
                { "html_url", n => { HtmlUrl = n.GetStringValue(); } },
                { "message", n => { Message = n.GetStringValue(); } },
                { "node_id", n => { NodeId = n.GetStringValue(); } },
                { "parents", n => { Parents = n.GetCollectionOfObjectValues<TimelineCommittedEvent_parents>(TimelineCommittedEvent_parents.CreateFromDiscriminatorValue)?.ToList(); } },
                { "sha", n => { Sha = n.GetStringValue(); } },
                { "tree", n => { Tree = n.GetObjectValue<TimelineCommittedEvent_tree>(TimelineCommittedEvent_tree.CreateFromDiscriminatorValue); } },
                { "url", n => { Url = n.GetStringValue(); } },
                { "verification", n => { Verification = n.GetObjectValue<TimelineCommittedEvent_verification>(TimelineCommittedEvent_verification.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<TimelineCommittedEvent_author>("author", Author);
            writer.WriteObjectValue<TimelineCommittedEvent_committer>("committer", Committer);
            writer.WriteStringValue("event", Event);
            writer.WriteStringValue("html_url", HtmlUrl);
            writer.WriteStringValue("message", Message);
            writer.WriteStringValue("node_id", NodeId);
            writer.WriteCollectionOfObjectValues<TimelineCommittedEvent_parents>("parents", Parents);
            writer.WriteStringValue("sha", Sha);
            writer.WriteObjectValue<TimelineCommittedEvent_tree>("tree", Tree);
            writer.WriteStringValue("url", Url);
            writer.WriteObjectValue<TimelineCommittedEvent_verification>("verification", Verification);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
