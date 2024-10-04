// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace GitHub.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.19.0")]
    #pragma warning disable CS1591
    public partial class SecurityAndAnalysis : IAdditionalDataHolder, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The advanced_security property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::GitHub.Models.SecurityAndAnalysis_advanced_security? AdvancedSecurity { get; set; }
#nullable restore
#else
        public global::GitHub.Models.SecurityAndAnalysis_advanced_security AdvancedSecurity { get; set; }
#endif
        /// <summary>Enable or disable Dependabot security updates for the repository.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::GitHub.Models.SecurityAndAnalysis_dependabot_security_updates? DependabotSecurityUpdates { get; set; }
#nullable restore
#else
        public global::GitHub.Models.SecurityAndAnalysis_dependabot_security_updates DependabotSecurityUpdates { get; set; }
#endif
        /// <summary>The secret_scanning property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::GitHub.Models.SecurityAndAnalysis_secret_scanning? SecretScanning { get; set; }
#nullable restore
#else
        public global::GitHub.Models.SecurityAndAnalysis_secret_scanning SecretScanning { get; set; }
#endif
        /// <summary>The secret_scanning_non_provider_patterns property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::GitHub.Models.SecurityAndAnalysis_secret_scanning_non_provider_patterns? SecretScanningNonProviderPatterns { get; set; }
#nullable restore
#else
        public global::GitHub.Models.SecurityAndAnalysis_secret_scanning_non_provider_patterns SecretScanningNonProviderPatterns { get; set; }
#endif
        /// <summary>The secret_scanning_push_protection property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::GitHub.Models.SecurityAndAnalysis_secret_scanning_push_protection? SecretScanningPushProtection { get; set; }
#nullable restore
#else
        public global::GitHub.Models.SecurityAndAnalysis_secret_scanning_push_protection SecretScanningPushProtection { get; set; }
#endif
        /// <summary>
        /// Instantiates a new <see cref="global::GitHub.Models.SecurityAndAnalysis"/> and sets the default values.
        /// </summary>
        public SecurityAndAnalysis()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::GitHub.Models.SecurityAndAnalysis"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::GitHub.Models.SecurityAndAnalysis CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::GitHub.Models.SecurityAndAnalysis();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "advanced_security", n => { AdvancedSecurity = n.GetObjectValue<global::GitHub.Models.SecurityAndAnalysis_advanced_security>(global::GitHub.Models.SecurityAndAnalysis_advanced_security.CreateFromDiscriminatorValue); } },
                { "dependabot_security_updates", n => { DependabotSecurityUpdates = n.GetObjectValue<global::GitHub.Models.SecurityAndAnalysis_dependabot_security_updates>(global::GitHub.Models.SecurityAndAnalysis_dependabot_security_updates.CreateFromDiscriminatorValue); } },
                { "secret_scanning", n => { SecretScanning = n.GetObjectValue<global::GitHub.Models.SecurityAndAnalysis_secret_scanning>(global::GitHub.Models.SecurityAndAnalysis_secret_scanning.CreateFromDiscriminatorValue); } },
                { "secret_scanning_non_provider_patterns", n => { SecretScanningNonProviderPatterns = n.GetObjectValue<global::GitHub.Models.SecurityAndAnalysis_secret_scanning_non_provider_patterns>(global::GitHub.Models.SecurityAndAnalysis_secret_scanning_non_provider_patterns.CreateFromDiscriminatorValue); } },
                { "secret_scanning_push_protection", n => { SecretScanningPushProtection = n.GetObjectValue<global::GitHub.Models.SecurityAndAnalysis_secret_scanning_push_protection>(global::GitHub.Models.SecurityAndAnalysis_secret_scanning_push_protection.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<global::GitHub.Models.SecurityAndAnalysis_advanced_security>("advanced_security", AdvancedSecurity);
            writer.WriteObjectValue<global::GitHub.Models.SecurityAndAnalysis_dependabot_security_updates>("dependabot_security_updates", DependabotSecurityUpdates);
            writer.WriteObjectValue<global::GitHub.Models.SecurityAndAnalysis_secret_scanning>("secret_scanning", SecretScanning);
            writer.WriteObjectValue<global::GitHub.Models.SecurityAndAnalysis_secret_scanning_non_provider_patterns>("secret_scanning_non_provider_patterns", SecretScanningNonProviderPatterns);
            writer.WriteObjectValue<global::GitHub.Models.SecurityAndAnalysis_secret_scanning_push_protection>("secret_scanning_push_protection", SecretScanningPushProtection);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
#pragma warning restore CS0618
