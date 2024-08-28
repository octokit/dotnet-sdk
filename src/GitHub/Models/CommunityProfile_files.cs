// <auto-generated/>
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace GitHub.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.17.0")]
    #pragma warning disable CS1591
    public partial class CommunityProfile_files : IAdditionalDataHolder, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Code of Conduct Simple</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::GitHub.Models.NullableCodeOfConductSimple? CodeOfConduct { get; set; }
#nullable restore
#else
        public global::GitHub.Models.NullableCodeOfConductSimple CodeOfConduct { get; set; }
#endif
        /// <summary>The code_of_conduct_file property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::GitHub.Models.NullableCommunityHealthFile? CodeOfConductFile { get; set; }
#nullable restore
#else
        public global::GitHub.Models.NullableCommunityHealthFile CodeOfConductFile { get; set; }
#endif
        /// <summary>The contributing property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::GitHub.Models.NullableCommunityHealthFile? Contributing { get; set; }
#nullable restore
#else
        public global::GitHub.Models.NullableCommunityHealthFile Contributing { get; set; }
#endif
        /// <summary>The issue_template property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::GitHub.Models.NullableCommunityHealthFile? IssueTemplate { get; set; }
#nullable restore
#else
        public global::GitHub.Models.NullableCommunityHealthFile IssueTemplate { get; set; }
#endif
        /// <summary>License Simple</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::GitHub.Models.NullableLicenseSimple? License { get; set; }
#nullable restore
#else
        public global::GitHub.Models.NullableLicenseSimple License { get; set; }
#endif
        /// <summary>The pull_request_template property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::GitHub.Models.NullableCommunityHealthFile? PullRequestTemplate { get; set; }
#nullable restore
#else
        public global::GitHub.Models.NullableCommunityHealthFile PullRequestTemplate { get; set; }
#endif
        /// <summary>The readme property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::GitHub.Models.NullableCommunityHealthFile? Readme { get; set; }
#nullable restore
#else
        public global::GitHub.Models.NullableCommunityHealthFile Readme { get; set; }
#endif
        /// <summary>
        /// Instantiates a new <see cref="global::GitHub.Models.CommunityProfile_files"/> and sets the default values.
        /// </summary>
        public CommunityProfile_files()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::GitHub.Models.CommunityProfile_files"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::GitHub.Models.CommunityProfile_files CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::GitHub.Models.CommunityProfile_files();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "code_of_conduct", n => { CodeOfConduct = n.GetObjectValue<global::GitHub.Models.NullableCodeOfConductSimple>(global::GitHub.Models.NullableCodeOfConductSimple.CreateFromDiscriminatorValue); } },
                { "code_of_conduct_file", n => { CodeOfConductFile = n.GetObjectValue<global::GitHub.Models.NullableCommunityHealthFile>(global::GitHub.Models.NullableCommunityHealthFile.CreateFromDiscriminatorValue); } },
                { "contributing", n => { Contributing = n.GetObjectValue<global::GitHub.Models.NullableCommunityHealthFile>(global::GitHub.Models.NullableCommunityHealthFile.CreateFromDiscriminatorValue); } },
                { "issue_template", n => { IssueTemplate = n.GetObjectValue<global::GitHub.Models.NullableCommunityHealthFile>(global::GitHub.Models.NullableCommunityHealthFile.CreateFromDiscriminatorValue); } },
                { "license", n => { License = n.GetObjectValue<global::GitHub.Models.NullableLicenseSimple>(global::GitHub.Models.NullableLicenseSimple.CreateFromDiscriminatorValue); } },
                { "pull_request_template", n => { PullRequestTemplate = n.GetObjectValue<global::GitHub.Models.NullableCommunityHealthFile>(global::GitHub.Models.NullableCommunityHealthFile.CreateFromDiscriminatorValue); } },
                { "readme", n => { Readme = n.GetObjectValue<global::GitHub.Models.NullableCommunityHealthFile>(global::GitHub.Models.NullableCommunityHealthFile.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<global::GitHub.Models.NullableCodeOfConductSimple>("code_of_conduct", CodeOfConduct);
            writer.WriteObjectValue<global::GitHub.Models.NullableCommunityHealthFile>("code_of_conduct_file", CodeOfConductFile);
            writer.WriteObjectValue<global::GitHub.Models.NullableCommunityHealthFile>("contributing", Contributing);
            writer.WriteObjectValue<global::GitHub.Models.NullableCommunityHealthFile>("issue_template", IssueTemplate);
            writer.WriteObjectValue<global::GitHub.Models.NullableLicenseSimple>("license", License);
            writer.WriteObjectValue<global::GitHub.Models.NullableCommunityHealthFile>("pull_request_template", PullRequestTemplate);
            writer.WriteObjectValue<global::GitHub.Models.NullableCommunityHealthFile>("readme", Readme);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
