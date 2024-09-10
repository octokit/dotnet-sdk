// <auto-generated/>
#pragma warning disable CS0618
using GitHub.Repos.Item.Item.Dependabot.Alerts;
using GitHub.Repos.Item.Item.Dependabot.Secrets;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
namespace GitHub.Repos.Item.Item.Dependabot
{
    /// <summary>
    /// Builds and executes requests for operations under \repos\{owner-id}\{repo-id}\dependabot
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.18.0")]
    public partial class DependabotRequestBuilder : BaseRequestBuilder
    {
        /// <summary>The alerts property</summary>
        public global::GitHub.Repos.Item.Item.Dependabot.Alerts.AlertsRequestBuilder Alerts
        {
            get => new global::GitHub.Repos.Item.Item.Dependabot.Alerts.AlertsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The secrets property</summary>
        public global::GitHub.Repos.Item.Item.Dependabot.Secrets.SecretsRequestBuilder Secrets
        {
            get => new global::GitHub.Repos.Item.Item.Dependabot.Secrets.SecretsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="global::GitHub.Repos.Item.Item.Dependabot.DependabotRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public DependabotRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/repos/{owner%2Did}/{repo%2Did}/dependabot", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::GitHub.Repos.Item.Item.Dependabot.DependabotRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public DependabotRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/repos/{owner%2Did}/{repo%2Did}/dependabot", rawUrl)
        {
        }
    }
}
#pragma warning restore CS0618
