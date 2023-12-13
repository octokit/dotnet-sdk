// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace GitHub.Models {
    /// <summary>
    /// Activity
    /// </summary>
    public class Activity : IAdditionalDataHolder, IParsable {
        /// <summary>The type of the activity that was performed.</summary>
        public Activity_activity_type? ActivityType { get; set; }
        /// <summary>A GitHub user.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public NullableSimpleUser? Actor { get; set; }
#nullable restore
#else
        public NullableSimpleUser Actor { get; set; }
#endif
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The SHA of the commit after the activity.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? After { get; set; }
#nullable restore
#else
        public string After { get; set; }
#endif
        /// <summary>The SHA of the commit before the activity.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Before { get; set; }
#nullable restore
#else
        public string Before { get; set; }
#endif
        /// <summary>The id property</summary>
        public int? Id { get; set; }
        /// <summary>The node_id property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? NodeId { get; set; }
#nullable restore
#else
        public string NodeId { get; set; }
#endif
        /// <summary>The full Git reference, formatted as `refs/heads/&lt;branch name&gt;`.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Ref { get; set; }
#nullable restore
#else
        public string Ref { get; set; }
#endif
        /// <summary>The time when the activity occurred.</summary>
        public DateTimeOffset? Timestamp { get; set; }
        /// <summary>
        /// Instantiates a new activity and sets the default values.
        /// </summary>
        public Activity() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static Activity CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Activity();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"activity_type", n => { ActivityType = n.GetEnumValue<Activity_activity_type>(); } },
                {"actor", n => { Actor = n.GetObjectValue<NullableSimpleUser>(NullableSimpleUser.CreateFromDiscriminatorValue); } },
                {"after", n => { After = n.GetStringValue(); } },
                {"before", n => { Before = n.GetStringValue(); } },
                {"id", n => { Id = n.GetIntValue(); } },
                {"node_id", n => { NodeId = n.GetStringValue(); } },
                {"ref", n => { Ref = n.GetStringValue(); } },
                {"timestamp", n => { Timestamp = n.GetDateTimeOffsetValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteEnumValue<Activity_activity_type>("activity_type", ActivityType);
            writer.WriteObjectValue<NullableSimpleUser>("actor", Actor);
            writer.WriteStringValue("after", After);
            writer.WriteStringValue("before", Before);
            writer.WriteIntValue("id", Id);
            writer.WriteStringValue("node_id", NodeId);
            writer.WriteStringValue("ref", Ref);
            writer.WriteDateTimeOffsetValue("timestamp", Timestamp);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}