// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace GitHub.Models {
    public class CommitSearchResultItem_commit : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The author property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public CommitSearchResultItem_commit_author? Author { get; set; }
#nullable restore
#else
        public CommitSearchResultItem_commit_author Author { get; set; }
#endif
        /// <summary>The comment_count property</summary>
        public int? CommentCount { get; set; }
        /// <summary>Metaproperties for Git author/committer information.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public NullableGitUser? Committer { get; set; }
#nullable restore
#else
        public NullableGitUser Committer { get; set; }
#endif
        /// <summary>The message property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Message { get; set; }
#nullable restore
#else
        public string Message { get; set; }
#endif
        /// <summary>The tree property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public CommitSearchResultItem_commit_tree? Tree { get; set; }
#nullable restore
#else
        public CommitSearchResultItem_commit_tree Tree { get; set; }
#endif
        /// <summary>The url property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Url { get; set; }
#nullable restore
#else
        public string Url { get; set; }
#endif
        /// <summary>The verification property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public GitHub.Models.Verification? Verification { get; set; }
#nullable restore
#else
        public GitHub.Models.Verification Verification { get; set; }
#endif
        /// <summary>
        /// Instantiates a new commitSearchResultItem_commit and sets the default values.
        /// </summary>
        public CommitSearchResultItem_commit() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static CommitSearchResultItem_commit CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new CommitSearchResultItem_commit();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"author", n => { Author = n.GetObjectValue<CommitSearchResultItem_commit_author>(CommitSearchResultItem_commit_author.CreateFromDiscriminatorValue); } },
                {"comment_count", n => { CommentCount = n.GetIntValue(); } },
                {"committer", n => { Committer = n.GetObjectValue<NullableGitUser>(NullableGitUser.CreateFromDiscriminatorValue); } },
                {"message", n => { Message = n.GetStringValue(); } },
                {"tree", n => { Tree = n.GetObjectValue<CommitSearchResultItem_commit_tree>(CommitSearchResultItem_commit_tree.CreateFromDiscriminatorValue); } },
                {"url", n => { Url = n.GetStringValue(); } },
                {"verification", n => { Verification = n.GetObjectValue<GitHub.Models.Verification>(GitHub.Models.Verification.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<CommitSearchResultItem_commit_author>("author", Author);
            writer.WriteIntValue("comment_count", CommentCount);
            writer.WriteObjectValue<NullableGitUser>("committer", Committer);
            writer.WriteStringValue("message", Message);
            writer.WriteObjectValue<CommitSearchResultItem_commit_tree>("tree", Tree);
            writer.WriteStringValue("url", Url);
            writer.WriteObjectValue<GitHub.Models.Verification>("verification", Verification);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}