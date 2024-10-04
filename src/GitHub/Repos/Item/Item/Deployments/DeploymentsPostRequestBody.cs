// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace GitHub.Repos.Item.Item.Deployments
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.19.0")]
    #pragma warning disable CS1591
    public partial class DeploymentsPostRequestBody : IAdditionalDataHolder, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Attempts to automatically merge the default branch into the requested ref, if it&apos;s behind the default branch.</summary>
        public bool? AutoMerge { get; set; }
        /// <summary>Short description of the deployment.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Description { get; set; }
#nullable restore
#else
        public string Description { get; set; }
#endif
        /// <summary>Name for the target deployment environment (e.g., `production`, `staging`, `qa`).</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Environment { get; set; }
#nullable restore
#else
        public string Environment { get; set; }
#endif
        /// <summary>The payload property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Payload { get; set; }
#nullable restore
#else
        public string Payload { get; set; }
#endif
        /// <summary>Specifies if the given environment is one that end-users directly interact with. Default: `true` when `environment` is `production` and `false` otherwise.</summary>
        public bool? ProductionEnvironment { get; set; }
        /// <summary>The ref to deploy. This can be a branch, tag, or SHA.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Ref { get; set; }
#nullable restore
#else
        public string Ref { get; set; }
#endif
        /// <summary>The [status](https://docs.github.com/rest/commits/statuses) contexts to verify against commit status checks. If you omit this parameter, GitHub verifies all unique contexts before creating a deployment. To bypass checking entirely, pass an empty array. Defaults to all unique contexts.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? RequiredContexts { get; set; }
#nullable restore
#else
        public List<string> RequiredContexts { get; set; }
#endif
        /// <summary>Specifies a task to execute (e.g., `deploy` or `deploy:migrations`).</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Task { get; set; }
#nullable restore
#else
        public string Task { get; set; }
#endif
        /// <summary>Specifies if the given environment is specific to the deployment and will no longer exist at some point in the future. Default: `false`</summary>
        public bool? TransientEnvironment { get; set; }
        /// <summary>
        /// Instantiates a new <see cref="global::GitHub.Repos.Item.Item.Deployments.DeploymentsPostRequestBody"/> and sets the default values.
        /// </summary>
        public DeploymentsPostRequestBody()
        {
            AdditionalData = new Dictionary<string, object>();
            Environment = "production";
            Task = "deploy";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::GitHub.Repos.Item.Item.Deployments.DeploymentsPostRequestBody"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::GitHub.Repos.Item.Item.Deployments.DeploymentsPostRequestBody CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::GitHub.Repos.Item.Item.Deployments.DeploymentsPostRequestBody();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "auto_merge", n => { AutoMerge = n.GetBoolValue(); } },
                { "description", n => { Description = n.GetStringValue(); } },
                { "environment", n => { Environment = n.GetStringValue(); } },
                { "payload", n => { Payload = n.GetStringValue(); } },
                { "production_environment", n => { ProductionEnvironment = n.GetBoolValue(); } },
                { "ref", n => { Ref = n.GetStringValue(); } },
                { "required_contexts", n => { RequiredContexts = n.GetCollectionOfPrimitiveValues<string>()?.AsList(); } },
                { "task", n => { Task = n.GetStringValue(); } },
                { "transient_environment", n => { TransientEnvironment = n.GetBoolValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteBoolValue("auto_merge", AutoMerge);
            writer.WriteStringValue("description", Description);
            writer.WriteStringValue("environment", Environment);
            writer.WriteStringValue("payload", Payload);
            writer.WriteBoolValue("production_environment", ProductionEnvironment);
            writer.WriteStringValue("ref", Ref);
            writer.WriteCollectionOfPrimitiveValues<string>("required_contexts", RequiredContexts);
            writer.WriteStringValue("task", Task);
            writer.WriteBoolValue("transient_environment", TransientEnvironment);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
#pragma warning restore CS0618
