// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace GitHub.Octokit.Models {
    /// <summary>
    /// Represents a &apos;discussion_body&apos; secret scanning location type. This location type shows that a secret was detected in the body of a discussion.
    /// </summary>
    public class SecretScanningLocationDiscussionBody : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The URL to the discussion where the secret was detected.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? DiscussionBodyUrl { get; set; }
#nullable restore
#else
        public string DiscussionBodyUrl { get; set; }
#endif
        /// <summary>
        /// Instantiates a new secretScanningLocationDiscussionBody and sets the default values.
        /// </summary>
        public SecretScanningLocationDiscussionBody() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static SecretScanningLocationDiscussionBody CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new SecretScanningLocationDiscussionBody();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"discussion_body_url", n => { DiscussionBodyUrl = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("discussion_body_url", DiscussionBodyUrl);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
