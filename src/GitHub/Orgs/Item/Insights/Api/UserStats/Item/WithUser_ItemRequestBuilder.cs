// <auto-generated/>
#pragma warning disable CS0618
using GitHub.Models;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace GitHub.Orgs.Item.Insights.Api.UserStats.Item
{
    /// <summary>
    /// Builds and executes requests for operations under \orgs\{org}\insights\api\user-stats\{user_id}
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.19.0")]
    public partial class WithUser_ItemRequestBuilder : BaseRequestBuilder
    {
        /// <summary>
        /// Instantiates a new <see cref="global::GitHub.Orgs.Item.Insights.Api.UserStats.Item.WithUser_ItemRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithUser_ItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/orgs/{org}/insights/api/user-stats/{user_id}?max_timestamp={max_timestamp}&min_timestamp={min_timestamp}{&direction*,page*,per_page*,sort*}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::GitHub.Orgs.Item.Insights.Api.UserStats.Item.WithUser_ItemRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithUser_ItemRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/orgs/{org}/insights/api/user-stats/{user_id}?max_timestamp={max_timestamp}&min_timestamp={min_timestamp}{&direction*,page*,per_page*,sort*}", rawUrl)
        {
        }
        /// <summary>
        /// Get API usage statistics within an organization for a user broken down by the type of access.
        /// API method documentation <see href="https://docs.github.com/rest/orgs/api-insights#get-user-stats" />
        /// </summary>
        /// <returns>A List&lt;global::GitHub.Models.ApiInsightsUserStats&gt;</returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<List<global::GitHub.Models.ApiInsightsUserStats>?> GetAsync(Action<RequestConfiguration<global::GitHub.Orgs.Item.Insights.Api.UserStats.Item.WithUser_ItemRequestBuilder.WithUser_ItemRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<List<global::GitHub.Models.ApiInsightsUserStats>> GetAsync(Action<RequestConfiguration<global::GitHub.Orgs.Item.Insights.Api.UserStats.Item.WithUser_ItemRequestBuilder.WithUser_ItemRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var collectionResult = await RequestAdapter.SendCollectionAsync<global::GitHub.Models.ApiInsightsUserStats>(requestInfo, global::GitHub.Models.ApiInsightsUserStats.CreateFromDiscriminatorValue, default, cancellationToken).ConfigureAwait(false);
            return collectionResult?.AsList();
        }
        /// <summary>
        /// Get API usage statistics within an organization for a user broken down by the type of access.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::GitHub.Orgs.Item.Insights.Api.UserStats.Item.WithUser_ItemRequestBuilder.WithUser_ItemRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::GitHub.Orgs.Item.Insights.Api.UserStats.Item.WithUser_ItemRequestBuilder.WithUser_ItemRequestBuilderGetQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.GET, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }
        /// <summary>
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <returns>A <see cref="global::GitHub.Orgs.Item.Insights.Api.UserStats.Item.WithUser_ItemRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::GitHub.Orgs.Item.Insights.Api.UserStats.Item.WithUser_ItemRequestBuilder WithUrl(string rawUrl)
        {
            return new global::GitHub.Orgs.Item.Insights.Api.UserStats.Item.WithUser_ItemRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Get API usage statistics within an organization for a user broken down by the type of access.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.19.0")]
        public partial class WithUser_ItemRequestBuilderGetQueryParameters 
        {
            /// <summary>The direction to sort the results by.</summary>
            [QueryParameter("direction")]
            public global::GitHub.Orgs.Item.Insights.Api.UserStats.Item.GetDirectionQueryParameterType? Direction { get; set; }
            /// <summary>The maximum timestamp to query for stats</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("max_timestamp")]
            public string? MaxTimestamp { get; set; }
#nullable restore
#else
            [QueryParameter("max_timestamp")]
            public string MaxTimestamp { get; set; }
#endif
            /// <summary>The minimum timestamp to query for stats</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("min_timestamp")]
            public string? MinTimestamp { get; set; }
#nullable restore
#else
            [QueryParameter("min_timestamp")]
            public string MinTimestamp { get; set; }
#endif
            /// <summary>The page number of the results to fetch. For more information, see &quot;[Using pagination in the REST API](https://docs.github.com/rest/using-the-rest-api/using-pagination-in-the-rest-api).&quot;</summary>
            [QueryParameter("page")]
            public int? Page { get; set; }
            /// <summary>The number of results per page (max 100). For more information, see &quot;[Using pagination in the REST API](https://docs.github.com/rest/using-the-rest-api/using-pagination-in-the-rest-api).&quot;</summary>
            [QueryParameter("per_page")]
            public int? PerPage { get; set; }
            /// <summary>The property to sort the results by.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("sort")]
            public global::GitHub.Orgs.Item.Insights.Api.UserStats.Item.GetSortQueryParameterType[]? Sort { get; set; }
#nullable restore
#else
            [QueryParameter("sort")]
            public global::GitHub.Orgs.Item.Insights.Api.UserStats.Item.GetSortQueryParameterType[] Sort { get; set; }
#endif
        }
    }
}
#pragma warning restore CS0618
