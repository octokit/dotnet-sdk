// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace GitHub.Models {
    public class CodeScanningAlertRule : IAdditionalDataHolder, IParsable 
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>A short description of the rule used to detect the alert.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Description { get; set; }
#nullable restore
#else
        public string Description { get; set; }
#endif
        /// <summary>description of the rule used to detect the alert.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? FullDescription { get; set; }
#nullable restore
#else
        public string FullDescription { get; set; }
#endif
        /// <summary>Detailed documentation for the rule as GitHub Flavored Markdown.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Help { get; set; }
#nullable restore
#else
        public string Help { get; set; }
#endif
        /// <summary>A link to the documentation for the rule used to detect the alert.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? HelpUri { get; set; }
#nullable restore
#else
        public string HelpUri { get; set; }
#endif
        /// <summary>A unique identifier for the rule used to detect the alert.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Id { get; set; }
#nullable restore
#else
        public string Id { get; set; }
#endif
        /// <summary>The name of the rule used to detect the alert.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Name { get; set; }
#nullable restore
#else
        public string Name { get; set; }
#endif
        /// <summary>The security severity of the alert.</summary>
        public CodeScanningAlertRule_security_severity_level? SecuritySeverityLevel { get; set; }
        /// <summary>The severity of the alert.</summary>
        public CodeScanningAlertRule_severity? Severity { get; set; }
        /// <summary>A set of tags applicable for the rule.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? Tags { get; set; }
#nullable restore
#else
        public List<string> Tags { get; set; }
#endif
        /// <summary>
        /// Instantiates a new <see cref="CodeScanningAlertRule"/> and sets the default values.
        /// </summary>
        public CodeScanningAlertRule()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="CodeScanningAlertRule"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static CodeScanningAlertRule CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new CodeScanningAlertRule();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                {"description", n => { Description = n.GetStringValue(); } },
                {"full_description", n => { FullDescription = n.GetStringValue(); } },
                {"help", n => { Help = n.GetStringValue(); } },
                {"help_uri", n => { HelpUri = n.GetStringValue(); } },
                {"id", n => { Id = n.GetStringValue(); } },
                {"name", n => { Name = n.GetStringValue(); } },
                {"security_severity_level", n => { SecuritySeverityLevel = n.GetEnumValue<CodeScanningAlertRule_security_severity_level>(); } },
                {"severity", n => { Severity = n.GetEnumValue<CodeScanningAlertRule_severity>(); } },
                {"tags", n => { Tags = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("description", Description);
            writer.WriteStringValue("full_description", FullDescription);
            writer.WriteStringValue("help", Help);
            writer.WriteStringValue("help_uri", HelpUri);
            writer.WriteStringValue("id", Id);
            writer.WriteStringValue("name", Name);
            writer.WriteEnumValue<CodeScanningAlertRule_security_severity_level>("security_severity_level", SecuritySeverityLevel);
            writer.WriteEnumValue<CodeScanningAlertRule_severity>("severity", Severity);
            writer.WriteCollectionOfPrimitiveValues<string>("tags", Tags);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
