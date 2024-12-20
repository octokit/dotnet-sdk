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
    /// Usage metrics for Copilot editor code completions in the IDE.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.19.0")]
    public partial class CopilotIdeCodeCompletions : IAdditionalDataHolder, IParsable
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The editors property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::GitHub.Models.CopilotIdeCodeCompletions_editors>? Editors { get; set; }
#nullable restore
#else
        public List<global::GitHub.Models.CopilotIdeCodeCompletions_editors> Editors { get; set; }
#endif
        /// <summary>Code completion metrics for active languages.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::GitHub.Models.CopilotIdeCodeCompletions_languages>? Languages { get; set; }
#nullable restore
#else
        public List<global::GitHub.Models.CopilotIdeCodeCompletions_languages> Languages { get; set; }
#endif
        /// <summary>Number of users who accepted at least one Copilot code suggestion, across all active editors. Includes both full and partial acceptances.</summary>
        public int? TotalEngagedUsers { get; set; }
        /// <summary>
        /// Instantiates a new <see cref="global::GitHub.Models.CopilotIdeCodeCompletions"/> and sets the default values.
        /// </summary>
        public CopilotIdeCodeCompletions()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::GitHub.Models.CopilotIdeCodeCompletions"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::GitHub.Models.CopilotIdeCodeCompletions CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::GitHub.Models.CopilotIdeCodeCompletions();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "editors", n => { Editors = n.GetCollectionOfObjectValues<global::GitHub.Models.CopilotIdeCodeCompletions_editors>(global::GitHub.Models.CopilotIdeCodeCompletions_editors.CreateFromDiscriminatorValue)?.AsList(); } },
                { "languages", n => { Languages = n.GetCollectionOfObjectValues<global::GitHub.Models.CopilotIdeCodeCompletions_languages>(global::GitHub.Models.CopilotIdeCodeCompletions_languages.CreateFromDiscriminatorValue)?.AsList(); } },
                { "total_engaged_users", n => { TotalEngagedUsers = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<global::GitHub.Models.CopilotIdeCodeCompletions_editors>("editors", Editors);
            writer.WriteCollectionOfObjectValues<global::GitHub.Models.CopilotIdeCodeCompletions_languages>("languages", Languages);
            writer.WriteIntValue("total_engaged_users", TotalEngagedUsers);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
#pragma warning restore CS0618
