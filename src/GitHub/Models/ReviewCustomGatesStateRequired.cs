// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace GitHub.Models
{
    #pragma warning disable CS1591
    public class ReviewCustomGatesStateRequired : IAdditionalDataHolder, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Optional comment to include with the review.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Comment { get; set; }
#nullable restore
#else
        public string Comment { get; set; }
#endif
        /// <summary>The name of the environment to approve or reject.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? EnvironmentName { get; set; }
#nullable restore
#else
        public string EnvironmentName { get; set; }
#endif
        /// <summary>Whether to approve or reject deployment to the specified environments.</summary>
        public ReviewCustomGatesStateRequired_state? State { get; set; }
        /// <summary>
        /// Instantiates a new <see cref="ReviewCustomGatesStateRequired"/> and sets the default values.
        /// </summary>
        public ReviewCustomGatesStateRequired()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="ReviewCustomGatesStateRequired"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static ReviewCustomGatesStateRequired CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ReviewCustomGatesStateRequired();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "comment", n => { Comment = n.GetStringValue(); } },
                { "environment_name", n => { EnvironmentName = n.GetStringValue(); } },
                { "state", n => { State = n.GetEnumValue<ReviewCustomGatesStateRequired_state>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("comment", Comment);
            writer.WriteStringValue("environment_name", EnvironmentName);
            writer.WriteEnumValue<ReviewCustomGatesStateRequired_state>("state", State);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
