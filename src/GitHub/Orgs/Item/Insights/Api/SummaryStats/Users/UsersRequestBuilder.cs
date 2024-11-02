// <auto-generated/>
#pragma warning disable CS0618
using GitHub.Orgs.Item.Insights.Api.SummaryStats.Users.Item;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
namespace GitHub.Orgs.Item.Insights.Api.SummaryStats.Users
{
    /// <summary>
    /// Builds and executes requests for operations under \orgs\{org}\insights\api\summary-stats\users
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.19.0")]
    public partial class UsersRequestBuilder : BaseRequestBuilder
    {
        /// <summary>Gets an item from the GitHub.orgs.item.insights.api.summaryStats.users.item collection</summary>
        /// <param name="position">The ID of the user to query for stats</param>
        /// <returns>A <see cref="global::GitHub.Orgs.Item.Insights.Api.SummaryStats.Users.Item.WithUser_ItemRequestBuilder"/></returns>
        public global::GitHub.Orgs.Item.Insights.Api.SummaryStats.Users.Item.WithUser_ItemRequestBuilder this[string position]
        {
            get
            {
                var urlTplParams = new Dictionary<string, object>(PathParameters);
                urlTplParams.Add("user_id", position);
                return new global::GitHub.Orgs.Item.Insights.Api.SummaryStats.Users.Item.WithUser_ItemRequestBuilder(urlTplParams, RequestAdapter);
            }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::GitHub.Orgs.Item.Insights.Api.SummaryStats.Users.UsersRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public UsersRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/orgs/{org}/insights/api/summary-stats/users", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::GitHub.Orgs.Item.Insights.Api.SummaryStats.Users.UsersRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public UsersRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/orgs/{org}/insights/api/summary-stats/users", rawUrl)
        {
        }
    }
}
#pragma warning restore CS0618
