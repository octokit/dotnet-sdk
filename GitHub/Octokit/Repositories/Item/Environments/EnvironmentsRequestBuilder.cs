// <auto-generated/>
using Microsoft.Kiota.Abstractions;
using Octokit.Client.Repositories.Item.Environments.Item;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
namespace Octokit.Client.Repositories.Item.Environments {
    /// <summary>
    /// Builds and executes requests for operations under \repositories\{repository_id}\environments
    /// </summary>
    public class EnvironmentsRequestBuilder : BaseRequestBuilder {
        /// <summary>Gets an item from the GitHub.Octokit.repositories.item.environments.item collection</summary>
        /// <param name="position">The name of the environment. The name must be URL encoded. For example, any slashes in the name must be replaced with `%2F`.</param>
        public WithEnvironment_nameItemRequestBuilder this[string position] { get {
            var urlTplParams = new Dictionary<string, object>(PathParameters);
            urlTplParams.Add("environment_name", position);
            return new WithEnvironment_nameItemRequestBuilder(urlTplParams, RequestAdapter);
        } }
        /// <summary>
        /// Instantiates a new EnvironmentsRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public EnvironmentsRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/repositories/{repository_id}/environments", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new EnvironmentsRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public EnvironmentsRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/repositories/{repository_id}/environments", rawUrl) {
        }
    }
}
