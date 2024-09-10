// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace GitHub.Orgs.Item.Attestations.Item
{
    /// <summary>
    /// The attestation&apos;s Sigstore Bundle.Refer to the [Sigstore Bundle Specification](https://github.com/sigstore/protobuf-specs/blob/main/protos/sigstore_bundle.proto) for more information.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.18.0")]
    public partial class WithSubject_digestGetResponse_attestations_bundle : IAdditionalDataHolder, IParsable
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The dsseEnvelope property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::GitHub.Orgs.Item.Attestations.Item.WithSubject_digestGetResponse_attestations_bundle_dsseEnvelope? DsseEnvelope { get; set; }
#nullable restore
#else
        public global::GitHub.Orgs.Item.Attestations.Item.WithSubject_digestGetResponse_attestations_bundle_dsseEnvelope DsseEnvelope { get; set; }
#endif
        /// <summary>The mediaType property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? MediaType { get; set; }
#nullable restore
#else
        public string MediaType { get; set; }
#endif
        /// <summary>The verificationMaterial property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::GitHub.Orgs.Item.Attestations.Item.WithSubject_digestGetResponse_attestations_bundle_verificationMaterial? VerificationMaterial { get; set; }
#nullable restore
#else
        public global::GitHub.Orgs.Item.Attestations.Item.WithSubject_digestGetResponse_attestations_bundle_verificationMaterial VerificationMaterial { get; set; }
#endif
        /// <summary>
        /// Instantiates a new <see cref="global::GitHub.Orgs.Item.Attestations.Item.WithSubject_digestGetResponse_attestations_bundle"/> and sets the default values.
        /// </summary>
        public WithSubject_digestGetResponse_attestations_bundle()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::GitHub.Orgs.Item.Attestations.Item.WithSubject_digestGetResponse_attestations_bundle"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::GitHub.Orgs.Item.Attestations.Item.WithSubject_digestGetResponse_attestations_bundle CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::GitHub.Orgs.Item.Attestations.Item.WithSubject_digestGetResponse_attestations_bundle();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "dsseEnvelope", n => { DsseEnvelope = n.GetObjectValue<global::GitHub.Orgs.Item.Attestations.Item.WithSubject_digestGetResponse_attestations_bundle_dsseEnvelope>(global::GitHub.Orgs.Item.Attestations.Item.WithSubject_digestGetResponse_attestations_bundle_dsseEnvelope.CreateFromDiscriminatorValue); } },
                { "mediaType", n => { MediaType = n.GetStringValue(); } },
                { "verificationMaterial", n => { VerificationMaterial = n.GetObjectValue<global::GitHub.Orgs.Item.Attestations.Item.WithSubject_digestGetResponse_attestations_bundle_verificationMaterial>(global::GitHub.Orgs.Item.Attestations.Item.WithSubject_digestGetResponse_attestations_bundle_verificationMaterial.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<global::GitHub.Orgs.Item.Attestations.Item.WithSubject_digestGetResponse_attestations_bundle_dsseEnvelope>("dsseEnvelope", DsseEnvelope);
            writer.WriteStringValue("mediaType", MediaType);
            writer.WriteObjectValue<global::GitHub.Orgs.Item.Attestations.Item.WithSubject_digestGetResponse_attestations_bundle_verificationMaterial>("verificationMaterial", VerificationMaterial);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
#pragma warning restore CS0618
