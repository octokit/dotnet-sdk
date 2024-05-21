// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace GitHub.Models
{
    /// <summary>
    /// Porter Large File
    /// </summary>
    public class PorterLargeFile : IAdditionalDataHolder, IParsable
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The oid property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Oid { get; set; }
#nullable restore
#else
        public string Oid { get; set; }
#endif
        /// <summary>The path property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Path { get; set; }
#nullable restore
#else
        public string Path { get; set; }
#endif
        /// <summary>The ref_name property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? RefName { get; set; }
#nullable restore
#else
        public string RefName { get; set; }
#endif
        /// <summary>The size property</summary>
        public int? Size { get; set; }
        /// <summary>
        /// Instantiates a new <see cref="PorterLargeFile"/> and sets the default values.
        /// </summary>
        public PorterLargeFile()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="PorterLargeFile"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static PorterLargeFile CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new PorterLargeFile();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "oid", n => { Oid = n.GetStringValue(); } },
                { "path", n => { Path = n.GetStringValue(); } },
                { "ref_name", n => { RefName = n.GetStringValue(); } },
                { "size", n => { Size = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("oid", Oid);
            writer.WriteStringValue("path", Path);
            writer.WriteStringValue("ref_name", RefName);
            writer.WriteIntValue("size", Size);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
