// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace GitHub.Models
{
    /// <summary>
    /// The configuration for GitHub Pages for a repository.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.18.0")]
    public partial class Page : IAdditionalDataHolder, IParsable
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The process in which the Page will be built.</summary>
        public global::GitHub.Models.Page_build_type? BuildType { get; set; }
        /// <summary>The Pages site&apos;s custom domain</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Cname { get; set; }
#nullable restore
#else
        public string Cname { get; set; }
#endif
        /// <summary>Whether the Page has a custom 404 page.</summary>
        public bool? Custom404 { get; set; }
        /// <summary>The web address the Page can be accessed from.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? HtmlUrl { get; set; }
#nullable restore
#else
        public string HtmlUrl { get; set; }
#endif
        /// <summary>The https_certificate property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::GitHub.Models.PagesHttpsCertificate? HttpsCertificate { get; set; }
#nullable restore
#else
        public global::GitHub.Models.PagesHttpsCertificate HttpsCertificate { get; set; }
#endif
        /// <summary>Whether https is enabled on the domain</summary>
        public bool? HttpsEnforced { get; set; }
        /// <summary>The timestamp when a pending domain becomes unverified.</summary>
        public DateTimeOffset? PendingDomainUnverifiedAt { get; set; }
        /// <summary>The state if the domain is verified</summary>
        public global::GitHub.Models.Page_protected_domain_state? ProtectedDomainState { get; set; }
        /// <summary>Whether the GitHub Pages site is publicly visible. If set to `true`, the site is accessible to anyone on the internet. If set to `false`, the site will only be accessible to users who have at least `read` access to the repository that published the site.</summary>
        public bool? Public { get; set; }
        /// <summary>The source property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::GitHub.Models.PagesSourceHash? Source { get; set; }
#nullable restore
#else
        public global::GitHub.Models.PagesSourceHash Source { get; set; }
#endif
        /// <summary>The status of the most recent build of the Page.</summary>
        public global::GitHub.Models.Page_status? Status { get; set; }
        /// <summary>The API address for accessing this Page resource.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Url { get; set; }
#nullable restore
#else
        public string Url { get; set; }
#endif
        /// <summary>
        /// Instantiates a new <see cref="global::GitHub.Models.Page"/> and sets the default values.
        /// </summary>
        public Page()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::GitHub.Models.Page"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::GitHub.Models.Page CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::GitHub.Models.Page();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "build_type", n => { BuildType = n.GetEnumValue<global::GitHub.Models.Page_build_type>(); } },
                { "cname", n => { Cname = n.GetStringValue(); } },
                { "custom_404", n => { Custom404 = n.GetBoolValue(); } },
                { "html_url", n => { HtmlUrl = n.GetStringValue(); } },
                { "https_certificate", n => { HttpsCertificate = n.GetObjectValue<global::GitHub.Models.PagesHttpsCertificate>(global::GitHub.Models.PagesHttpsCertificate.CreateFromDiscriminatorValue); } },
                { "https_enforced", n => { HttpsEnforced = n.GetBoolValue(); } },
                { "pending_domain_unverified_at", n => { PendingDomainUnverifiedAt = n.GetDateTimeOffsetValue(); } },
                { "protected_domain_state", n => { ProtectedDomainState = n.GetEnumValue<global::GitHub.Models.Page_protected_domain_state>(); } },
                { "public", n => { Public = n.GetBoolValue(); } },
                { "source", n => { Source = n.GetObjectValue<global::GitHub.Models.PagesSourceHash>(global::GitHub.Models.PagesSourceHash.CreateFromDiscriminatorValue); } },
                { "status", n => { Status = n.GetEnumValue<global::GitHub.Models.Page_status>(); } },
                { "url", n => { Url = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteEnumValue<global::GitHub.Models.Page_build_type>("build_type", BuildType);
            writer.WriteStringValue("cname", Cname);
            writer.WriteBoolValue("custom_404", Custom404);
            writer.WriteStringValue("html_url", HtmlUrl);
            writer.WriteObjectValue<global::GitHub.Models.PagesHttpsCertificate>("https_certificate", HttpsCertificate);
            writer.WriteBoolValue("https_enforced", HttpsEnforced);
            writer.WriteDateTimeOffsetValue("pending_domain_unverified_at", PendingDomainUnverifiedAt);
            writer.WriteEnumValue<global::GitHub.Models.Page_protected_domain_state>("protected_domain_state", ProtectedDomainState);
            writer.WriteBoolValue("public", Public);
            writer.WriteObjectValue<global::GitHub.Models.PagesSourceHash>("source", Source);
            writer.WriteEnumValue<global::GitHub.Models.Page_status>("status", Status);
            writer.WriteStringValue("url", Url);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
#pragma warning restore CS0618
