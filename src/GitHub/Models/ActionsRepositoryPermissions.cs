// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace GitHub.Models {
    public class ActionsRepositoryPermissions : IAdditionalDataHolder, IParsable 
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The permissions policy that controls the actions and reusable workflows that are allowed to run.</summary>
        public GitHub.Models.AllowedActions? AllowedActions { get; set; }
        /// <summary>Whether GitHub Actions is enabled on the repository.</summary>
        public bool? Enabled { get; set; }
        /// <summary>The API URL to use to get or set the actions and reusable workflows that are allowed to run, when `allowed_actions` is set to `selected`.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? SelectedActionsUrl { get; set; }
#nullable restore
#else
        public string SelectedActionsUrl { get; set; }
#endif
        /// <summary>
        /// Instantiates a new <see cref="ActionsRepositoryPermissions"/> and sets the default values.
        /// </summary>
        public ActionsRepositoryPermissions()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="ActionsRepositoryPermissions"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static ActionsRepositoryPermissions CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ActionsRepositoryPermissions();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                {"allowed_actions", n => { AllowedActions = n.GetEnumValue<AllowedActions>(); } },
                {"enabled", n => { Enabled = n.GetBoolValue(); } },
                {"selected_actions_url", n => { SelectedActionsUrl = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteEnumValue<AllowedActions>("allowed_actions", AllowedActions);
            writer.WriteBoolValue("enabled", Enabled);
            writer.WriteStringValue("selected_actions_url", SelectedActionsUrl);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
