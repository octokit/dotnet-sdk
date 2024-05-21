// <auto-generated/>
using GitHub.Repos.Item.Item.CodeScanning.Codeql.VariantAnalyses.Item.Repos.Item;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
namespace GitHub.Repos.Item.Item.CodeScanning.Codeql.VariantAnalyses.Item.Repos
{
    /// <summary>
    /// Builds and executes requests for operations under \repos\{owner-id}\{repo-id}\code-scanning\codeql\variant-analyses\{codeql_variant_analysis_id}\repos
    /// </summary>
    public class ReposRequestBuilder : BaseRequestBuilder
    {
        /// <summary>Gets an item from the GitHub.repos.item.item.codeScanning.codeql.variantAnalyses.item.repos.item collection</summary>
        /// <param name="position">The account owner of the variant analysis repository. The name is not case sensitive.</param>
        /// <returns>A <see cref="WithRepo_ownerItemRequestBuilder"/></returns>
        public WithRepo_ownerItemRequestBuilder this[string position]
        {
            get
            {
                var urlTplParams = new Dictionary<string, object>(PathParameters);
                urlTplParams.Add("repo_owner", position);
                return new WithRepo_ownerItemRequestBuilder(urlTplParams, RequestAdapter);
            }
        }
        /// <summary>
        /// Instantiates a new <see cref="ReposRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public ReposRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/repos/{owner%2Did}/{repo%2Did}/code-scanning/codeql/variant-analyses/{codeql_variant_analysis_id}/repos", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="ReposRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public ReposRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/repos/{owner%2Did}/{repo%2Did}/code-scanning/codeql/variant-analyses/{codeql_variant_analysis_id}/repos", rawUrl)
        {
        }
    }
}
