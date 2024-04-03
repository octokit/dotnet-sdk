// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace GitHub.Models {
    /// <summary>
    /// Key
    /// </summary>
    public class Key : IAdditionalDataHolder, IParsable 
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The created_at property</summary>
        public DateTimeOffset? CreatedAt { get; set; }
        /// <summary>The id property</summary>
        public int? Id { get; set; }
        /// <summary>The key property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? KeyProp { get; set; }
#nullable restore
#else
        public string KeyProp { get; set; }
#endif
        /// <summary>The read_only property</summary>
        public bool? ReadOnly { get; set; }
        /// <summary>The title property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Title { get; set; }
#nullable restore
#else
        public string Title { get; set; }
#endif
        /// <summary>The url property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Url { get; set; }
#nullable restore
#else
        public string Url { get; set; }
#endif
        /// <summary>The verified property</summary>
        public bool? Verified { get; set; }
        /// <summary>
        /// Instantiates a new <see cref="Key"/> and sets the default values.
        /// </summary>
        public Key()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="Key"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static Key CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Key();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                {"created_at", n => { CreatedAt = n.GetDateTimeOffsetValue(); } },
                {"id", n => { Id = n.GetIntValue(); } },
                {"key", n => { KeyProp = n.GetStringValue(); } },
                {"read_only", n => { ReadOnly = n.GetBoolValue(); } },
                {"title", n => { Title = n.GetStringValue(); } },
                {"url", n => { Url = n.GetStringValue(); } },
                {"verified", n => { Verified = n.GetBoolValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteDateTimeOffsetValue("created_at", CreatedAt);
            writer.WriteIntValue("id", Id);
            writer.WriteStringValue("key", KeyProp);
            writer.WriteBoolValue("read_only", ReadOnly);
            writer.WriteStringValue("title", Title);
            writer.WriteStringValue("url", Url);
            writer.WriteBoolValue("verified", Verified);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
