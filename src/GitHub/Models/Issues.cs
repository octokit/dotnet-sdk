// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace GitHub.Models {
    public class Issues : IAdditionalDataHolder, IParsable 
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The fragment property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Fragment { get; set; }
#nullable restore
#else
        public string Fragment { get; set; }
#endif
        /// <summary>The matches property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Issues_matches>? Matches { get; set; }
#nullable restore
#else
        public List<Issues_matches> Matches { get; set; }
#endif
        /// <summary>The object_type property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? ObjectType { get; set; }
#nullable restore
#else
        public string ObjectType { get; set; }
#endif
        /// <summary>The object_url property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? ObjectUrl { get; set; }
#nullable restore
#else
        public string ObjectUrl { get; set; }
#endif
        /// <summary>The property property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Property { get; set; }
#nullable restore
#else
        public string Property { get; set; }
#endif
        /// <summary>
        /// Instantiates a new <see cref="Issues"/> and sets the default values.
        /// </summary>
        public Issues()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="Issues"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static Issues CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Issues();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                {"fragment", n => { Fragment = n.GetStringValue(); } },
                {"matches", n => { Matches = n.GetCollectionOfObjectValues<Issues_matches>(Issues_matches.CreateFromDiscriminatorValue)?.ToList(); } },
                {"object_type", n => { ObjectType = n.GetStringValue(); } },
                {"object_url", n => { ObjectUrl = n.GetStringValue(); } },
                {"property", n => { Property = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("fragment", Fragment);
            writer.WriteCollectionOfObjectValues<Issues_matches>("matches", Matches);
            writer.WriteStringValue("object_type", ObjectType);
            writer.WriteStringValue("object_url", ObjectUrl);
            writer.WriteStringValue("property", Property);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
