// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace GitHub.Models
{
    /// <summary>
    /// Details for the GitHub Security Advisory.
    /// </summary>
    public class DependabotAlertSecurityAdvisory : IParsable
    {
        /// <summary>The unique CVE ID assigned to the advisory.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? CveId { get; private set; }
#nullable restore
#else
        public string CveId { get; private set; }
#endif
        /// <summary>Details for the advisory pertaining to the Common Vulnerability Scoring System.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public DependabotAlertSecurityAdvisory_cvss? Cvss { get; private set; }
#nullable restore
#else
        public DependabotAlertSecurityAdvisory_cvss Cvss { get; private set; }
#endif
        /// <summary>Details for the advisory pertaining to Common Weakness Enumeration.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<DependabotAlertSecurityAdvisory_cwes>? Cwes { get; private set; }
#nullable restore
#else
        public List<DependabotAlertSecurityAdvisory_cwes> Cwes { get; private set; }
#endif
        /// <summary>A long-form Markdown-supported description of the advisory.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Description { get; private set; }
#nullable restore
#else
        public string Description { get; private set; }
#endif
        /// <summary>The unique GitHub Security Advisory ID assigned to the advisory.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? GhsaId { get; private set; }
#nullable restore
#else
        public string GhsaId { get; private set; }
#endif
        /// <summary>Values that identify this advisory among security information sources.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<DependabotAlertSecurityAdvisory_identifiers>? Identifiers { get; private set; }
#nullable restore
#else
        public List<DependabotAlertSecurityAdvisory_identifiers> Identifiers { get; private set; }
#endif
        /// <summary>The time that the advisory was published in ISO 8601 format: `YYYY-MM-DDTHH:MM:SSZ`.</summary>
        public DateTimeOffset? PublishedAt { get; private set; }
        /// <summary>Links to additional advisory information.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<DependabotAlertSecurityAdvisory_references>? References { get; private set; }
#nullable restore
#else
        public List<DependabotAlertSecurityAdvisory_references> References { get; private set; }
#endif
        /// <summary>The severity of the advisory.</summary>
        public DependabotAlertSecurityAdvisory_severity? Severity { get; private set; }
        /// <summary>A short, plain text summary of the advisory.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Summary { get; private set; }
#nullable restore
#else
        public string Summary { get; private set; }
#endif
        /// <summary>The time that the advisory was last modified in ISO 8601 format: `YYYY-MM-DDTHH:MM:SSZ`.</summary>
        public DateTimeOffset? UpdatedAt { get; private set; }
        /// <summary>Vulnerable version range information for the advisory.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<DependabotAlertSecurityVulnerability>? Vulnerabilities { get; private set; }
#nullable restore
#else
        public List<DependabotAlertSecurityVulnerability> Vulnerabilities { get; private set; }
#endif
        /// <summary>The time that the advisory was withdrawn in ISO 8601 format: `YYYY-MM-DDTHH:MM:SSZ`.</summary>
        public DateTimeOffset? WithdrawnAt { get; private set; }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="DependabotAlertSecurityAdvisory"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static DependabotAlertSecurityAdvisory CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new DependabotAlertSecurityAdvisory();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "cve_id", n => { CveId = n.GetStringValue(); } },
                { "cvss", n => { Cvss = n.GetObjectValue<DependabotAlertSecurityAdvisory_cvss>(DependabotAlertSecurityAdvisory_cvss.CreateFromDiscriminatorValue); } },
                { "cwes", n => { Cwes = n.GetCollectionOfObjectValues<DependabotAlertSecurityAdvisory_cwes>(DependabotAlertSecurityAdvisory_cwes.CreateFromDiscriminatorValue)?.ToList(); } },
                { "description", n => { Description = n.GetStringValue(); } },
                { "ghsa_id", n => { GhsaId = n.GetStringValue(); } },
                { "identifiers", n => { Identifiers = n.GetCollectionOfObjectValues<DependabotAlertSecurityAdvisory_identifiers>(DependabotAlertSecurityAdvisory_identifiers.CreateFromDiscriminatorValue)?.ToList(); } },
                { "published_at", n => { PublishedAt = n.GetDateTimeOffsetValue(); } },
                { "references", n => { References = n.GetCollectionOfObjectValues<DependabotAlertSecurityAdvisory_references>(DependabotAlertSecurityAdvisory_references.CreateFromDiscriminatorValue)?.ToList(); } },
                { "severity", n => { Severity = n.GetEnumValue<DependabotAlertSecurityAdvisory_severity>(); } },
                { "summary", n => { Summary = n.GetStringValue(); } },
                { "updated_at", n => { UpdatedAt = n.GetDateTimeOffsetValue(); } },
                { "vulnerabilities", n => { Vulnerabilities = n.GetCollectionOfObjectValues<DependabotAlertSecurityVulnerability>(DependabotAlertSecurityVulnerability.CreateFromDiscriminatorValue)?.ToList(); } },
                { "withdrawn_at", n => { WithdrawnAt = n.GetDateTimeOffsetValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
        }
    }
}
