// <auto-generated/>
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace GitHub.Models
{
    /// <summary>
    /// Diff Entry
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.17.0")]
    public partial class DiffEntry : IAdditionalDataHolder, IParsable
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The additions property</summary>
        public int? Additions { get; set; }
        /// <summary>The blob_url property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? BlobUrl { get; set; }
#nullable restore
#else
        public string BlobUrl { get; set; }
#endif
        /// <summary>The changes property</summary>
        public int? Changes { get; set; }
        /// <summary>The contents_url property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? ContentsUrl { get; set; }
#nullable restore
#else
        public string ContentsUrl { get; set; }
#endif
        /// <summary>The deletions property</summary>
        public int? Deletions { get; set; }
        /// <summary>The filename property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Filename { get; set; }
#nullable restore
#else
        public string Filename { get; set; }
#endif
        /// <summary>The patch property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Patch { get; set; }
#nullable restore
#else
        public string Patch { get; set; }
#endif
        /// <summary>The previous_filename property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? PreviousFilename { get; set; }
#nullable restore
#else
        public string PreviousFilename { get; set; }
#endif
        /// <summary>The raw_url property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? RawUrl { get; set; }
#nullable restore
#else
        public string RawUrl { get; set; }
#endif
        /// <summary>The sha property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Sha { get; set; }
#nullable restore
#else
        public string Sha { get; set; }
#endif
        /// <summary>The status property</summary>
        public global::GitHub.Models.DiffEntry_status? Status { get; set; }
        /// <summary>
        /// Instantiates a new <see cref="global::GitHub.Models.DiffEntry"/> and sets the default values.
        /// </summary>
        public DiffEntry()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::GitHub.Models.DiffEntry"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::GitHub.Models.DiffEntry CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::GitHub.Models.DiffEntry();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "additions", n => { Additions = n.GetIntValue(); } },
                { "blob_url", n => { BlobUrl = n.GetStringValue(); } },
                { "changes", n => { Changes = n.GetIntValue(); } },
                { "contents_url", n => { ContentsUrl = n.GetStringValue(); } },
                { "deletions", n => { Deletions = n.GetIntValue(); } },
                { "filename", n => { Filename = n.GetStringValue(); } },
                { "patch", n => { Patch = n.GetStringValue(); } },
                { "previous_filename", n => { PreviousFilename = n.GetStringValue(); } },
                { "raw_url", n => { RawUrl = n.GetStringValue(); } },
                { "sha", n => { Sha = n.GetStringValue(); } },
                { "status", n => { Status = n.GetEnumValue<global::GitHub.Models.DiffEntry_status>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("additions", Additions);
            writer.WriteStringValue("blob_url", BlobUrl);
            writer.WriteIntValue("changes", Changes);
            writer.WriteStringValue("contents_url", ContentsUrl);
            writer.WriteIntValue("deletions", Deletions);
            writer.WriteStringValue("filename", Filename);
            writer.WriteStringValue("patch", Patch);
            writer.WriteStringValue("previous_filename", PreviousFilename);
            writer.WriteStringValue("raw_url", RawUrl);
            writer.WriteStringValue("sha", Sha);
            writer.WriteEnumValue<global::GitHub.Models.DiffEntry_status>("status", Status);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
