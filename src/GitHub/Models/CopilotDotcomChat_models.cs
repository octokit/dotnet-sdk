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
    public partial class CopilotDotcomChat_models : IAdditionalDataHolder, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The training date for the custom model (if applicable).</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? CustomModelTrainingDate { get; set; }
#nullable restore
#else
        public string CustomModelTrainingDate { get; set; }
#endif
        /// <summary>Indicates whether a model is custom or default.</summary>
        public bool? IsCustomModel { get; set; }
        /// <summary>Name of the language used for Copilot code completion suggestions, for the given editor.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Name { get; set; }
#nullable restore
#else
        public string Name { get; set; }
#endif
        /// <summary>Total number of chats initiated by users on github.com.</summary>
        public int? TotalChats { get; set; }
        /// <summary>Total number of users who prompted Copilot Chat on github.com at least once for each model.</summary>
        public int? TotalEngagedUsers { get; set; }
        /// <summary>
        /// Instantiates a new <see cref="global::GitHub.Models.CopilotDotcomChat_models"/> and sets the default values.
        /// </summary>
        public CopilotDotcomChat_models()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::GitHub.Models.CopilotDotcomChat_models"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::GitHub.Models.CopilotDotcomChat_models CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::GitHub.Models.CopilotDotcomChat_models();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "custom_model_training_date", n => { CustomModelTrainingDate = n.GetStringValue(); } },
                { "is_custom_model", n => { IsCustomModel = n.GetBoolValue(); } },
                { "name", n => { Name = n.GetStringValue(); } },
                { "total_chats", n => { TotalChats = n.GetIntValue(); } },
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
            writer.WriteStringValue("custom_model_training_date", CustomModelTrainingDate);
            writer.WriteBoolValue("is_custom_model", IsCustomModel);
            writer.WriteStringValue("name", Name);
            writer.WriteIntValue("total_chats", TotalChats);
            writer.WriteIntValue("total_engaged_users", TotalEngagedUsers);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
#pragma warning restore CS0618
