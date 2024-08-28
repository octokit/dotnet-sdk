// <auto-generated/>
using GitHub.Models;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace GitHub.Repos.Item.Item.Rulesets
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.17.0")]
    #pragma warning disable CS1591
    public partial class RulesetsPostRequestBody : IAdditionalDataHolder, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The actors that can bypass the rules in this ruleset</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::GitHub.Models.RepositoryRulesetBypassActor>? BypassActors { get; set; }
#nullable restore
#else
        public List<global::GitHub.Models.RepositoryRulesetBypassActor> BypassActors { get; set; }
#endif
        /// <summary>Parameters for a repository ruleset ref name condition</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::GitHub.Models.RepositoryRulesetConditions? Conditions { get; set; }
#nullable restore
#else
        public global::GitHub.Models.RepositoryRulesetConditions Conditions { get; set; }
#endif
        /// <summary>The enforcement level of the ruleset. `evaluate` allows admins to test rules before enforcing them. Admins can view insights on the Rule Insights page (`evaluate` is only available with GitHub Enterprise).</summary>
        public global::GitHub.Models.RepositoryRuleEnforcement? Enforcement { get; set; }
        /// <summary>The name of the ruleset.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Name { get; set; }
#nullable restore
#else
        public string Name { get; set; }
#endif
        /// <summary>An array of rules within the ruleset.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::GitHub.Models.RepositoryRule>? Rules { get; set; }
#nullable restore
#else
        public List<global::GitHub.Models.RepositoryRule> Rules { get; set; }
#endif
        /// <summary>The target of the ruleset&gt; [!NOTE]&gt; The `push` target is in beta and is subject to change.</summary>
        public global::GitHub.Repos.Item.Item.Rulesets.RulesetsPostRequestBody_target? Target { get; set; }
        /// <summary>
        /// Instantiates a new <see cref="global::GitHub.Repos.Item.Item.Rulesets.RulesetsPostRequestBody"/> and sets the default values.
        /// </summary>
        public RulesetsPostRequestBody()
        {
            AdditionalData = new Dictionary<string, object>();
            Target = global::GitHub.Repos.Item.Item.Rulesets.RulesetsPostRequestBody_target.Branch;
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::GitHub.Repos.Item.Item.Rulesets.RulesetsPostRequestBody"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::GitHub.Repos.Item.Item.Rulesets.RulesetsPostRequestBody CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::GitHub.Repos.Item.Item.Rulesets.RulesetsPostRequestBody();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "bypass_actors", n => { BypassActors = n.GetCollectionOfObjectValues<global::GitHub.Models.RepositoryRulesetBypassActor>(global::GitHub.Models.RepositoryRulesetBypassActor.CreateFromDiscriminatorValue)?.AsList(); } },
                { "conditions", n => { Conditions = n.GetObjectValue<global::GitHub.Models.RepositoryRulesetConditions>(global::GitHub.Models.RepositoryRulesetConditions.CreateFromDiscriminatorValue); } },
                { "enforcement", n => { Enforcement = n.GetEnumValue<global::GitHub.Models.RepositoryRuleEnforcement>(); } },
                { "name", n => { Name = n.GetStringValue(); } },
                { "rules", n => { Rules = n.GetCollectionOfObjectValues<global::GitHub.Models.RepositoryRule>(global::GitHub.Models.RepositoryRule.CreateFromDiscriminatorValue)?.AsList(); } },
                { "target", n => { Target = n.GetEnumValue<global::GitHub.Repos.Item.Item.Rulesets.RulesetsPostRequestBody_target>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<global::GitHub.Models.RepositoryRulesetBypassActor>("bypass_actors", BypassActors);
            writer.WriteObjectValue<global::GitHub.Models.RepositoryRulesetConditions>("conditions", Conditions);
            writer.WriteEnumValue<global::GitHub.Models.RepositoryRuleEnforcement>("enforcement", Enforcement);
            writer.WriteStringValue("name", Name);
            writer.WriteCollectionOfObjectValues<global::GitHub.Models.RepositoryRule>("rules", Rules);
            writer.WriteEnumValue<global::GitHub.Repos.Item.Item.Rulesets.RulesetsPostRequestBody_target>("target", Target);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
