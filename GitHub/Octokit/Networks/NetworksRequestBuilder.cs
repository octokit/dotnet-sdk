// <auto-generated/>
using GitHub.Octokit.Networks.Item;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
namespace GitHub.Octokit.Networks {
    /// <summary>
    /// Builds and executes requests for operations under \networks
    /// </summary>
    public class NetworksRequestBuilder : BaseRequestBuilder {
        /// <summary>Gets an item from the GitHub.Octokit.networks.item collection</summary>
        /// <param name="position">Unique identifier of the item</param>
        public WithOwnerItemRequestBuilder this[string position] { get {
            var urlTplParams = new Dictionary<string, object>(PathParameters);
            urlTplParams.Add("owner", position);
            return new WithOwnerItemRequestBuilder(urlTplParams, RequestAdapter);
        } }
        /// <summary>
        /// Instantiates a new NetworksRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public NetworksRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/networks", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new NetworksRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public NetworksRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/networks", rawUrl) {
        }
    }
}