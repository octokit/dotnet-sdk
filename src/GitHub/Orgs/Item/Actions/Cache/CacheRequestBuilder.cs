// <auto-generated/>
#pragma warning disable CS0618
using GitHub.Orgs.Item.Actions.Cache.Usage;
using GitHub.Orgs.Item.Actions.Cache.UsageByRepository;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
namespace GitHub.Orgs.Item.Actions.Cache
{
    /// <summary>
    /// Builds and executes requests for operations under \orgs\{org}\actions\cache
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.19.0")]
    public partial class CacheRequestBuilder : BaseRequestBuilder
    {
        /// <summary>The usage property</summary>
        public global::GitHub.Orgs.Item.Actions.Cache.Usage.UsageRequestBuilder Usage
        {
            get => new global::GitHub.Orgs.Item.Actions.Cache.Usage.UsageRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The usageByRepository property</summary>
        public global::GitHub.Orgs.Item.Actions.Cache.UsageByRepository.UsageByRepositoryRequestBuilder UsageByRepository
        {
            get => new global::GitHub.Orgs.Item.Actions.Cache.UsageByRepository.UsageByRepositoryRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="global::GitHub.Orgs.Item.Actions.Cache.CacheRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public CacheRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/orgs/{org}/actions/cache", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::GitHub.Orgs.Item.Actions.Cache.CacheRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public CacheRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/orgs/{org}/actions/cache", rawUrl)
        {
        }
    }
}
#pragma warning restore CS0618
