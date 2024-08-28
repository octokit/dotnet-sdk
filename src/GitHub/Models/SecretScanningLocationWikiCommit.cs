// <auto-generated/>
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace GitHub.Models
{
    /// <summary>
    /// Represents a &apos;wiki_commit&apos; secret scanning location type. This location type shows that a secret was detected inside a commit to a repository wiki.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.17.0")]
    public partial class SecretScanningLocationWikiCommit : IAdditionalDataHolder, IParsable
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>SHA-1 hash ID of the associated blob</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? BlobSha { get; set; }
#nullable restore
#else
        public string BlobSha { get; set; }
#endif
        /// <summary>SHA-1 hash ID of the associated commit</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? CommitSha { get; set; }
#nullable restore
#else
        public string CommitSha { get; set; }
#endif
        /// <summary>The GitHub URL to get the associated wiki commit</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? CommitUrl { get; set; }
#nullable restore
#else
        public string CommitUrl { get; set; }
#endif
        /// <summary>The column at which the secret ends within the end line when the file is interpreted as 8-bit ASCII.</summary>
        public double? EndColumn { get; set; }
        /// <summary>Line number at which the secret ends in the file</summary>
        public double? EndLine { get; set; }
        /// <summary>The GitHub URL to get the associated wiki page</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? PageUrl { get; set; }
#nullable restore
#else
        public string PageUrl { get; set; }
#endif
        /// <summary>The file path of the wiki page</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Path { get; set; }
#nullable restore
#else
        public string Path { get; set; }
#endif
        /// <summary>The column at which the secret starts within the start line when the file is interpreted as 8-bit ASCII.</summary>
        public double? StartColumn { get; set; }
        /// <summary>Line number at which the secret starts in the file</summary>
        public double? StartLine { get; set; }
        /// <summary>
        /// Instantiates a new <see cref="global::GitHub.Models.SecretScanningLocationWikiCommit"/> and sets the default values.
        /// </summary>
        public SecretScanningLocationWikiCommit()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::GitHub.Models.SecretScanningLocationWikiCommit"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::GitHub.Models.SecretScanningLocationWikiCommit CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::GitHub.Models.SecretScanningLocationWikiCommit();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "blob_sha", n => { BlobSha = n.GetStringValue(); } },
                { "commit_sha", n => { CommitSha = n.GetStringValue(); } },
                { "commit_url", n => { CommitUrl = n.GetStringValue(); } },
                { "end_column", n => { EndColumn = n.GetDoubleValue(); } },
                { "end_line", n => { EndLine = n.GetDoubleValue(); } },
                { "page_url", n => { PageUrl = n.GetStringValue(); } },
                { "path", n => { Path = n.GetStringValue(); } },
                { "start_column", n => { StartColumn = n.GetDoubleValue(); } },
                { "start_line", n => { StartLine = n.GetDoubleValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("blob_sha", BlobSha);
            writer.WriteStringValue("commit_sha", CommitSha);
            writer.WriteStringValue("commit_url", CommitUrl);
            writer.WriteDoubleValue("end_column", EndColumn);
            writer.WriteDoubleValue("end_line", EndLine);
            writer.WriteStringValue("page_url", PageUrl);
            writer.WriteStringValue("path", Path);
            writer.WriteDoubleValue("start_column", StartColumn);
            writer.WriteDoubleValue("start_line", StartLine);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
