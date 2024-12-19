// <auto-generated/>
#pragma warning disable CS0618
using GitHub.Models;
using GitHub.Orgs.Item.Insights.Api.TimeStats.Item;
using GitHub.Orgs.Item.Insights.Api.TimeStats.Users;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace GitHub.Orgs.Item.Insights.Api.TimeStats
{
    /// <summary>
    /// Builds and executes requests for operations under \orgs\{org}\insights\api\time-stats
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.19.0")]
    public partial class TimeStatsRequestBuilder : BaseRequestBuilder
    {
        /// <summary>The users property</summary>
        public global::GitHub.Orgs.Item.Insights.Api.TimeStats.Users.UsersRequestBuilder Users
        {
            get => new global::GitHub.Orgs.Item.Insights.Api.TimeStats.Users.UsersRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Gets an item from the GitHub.orgs.item.insights.api.timeStats.item collection</summary>
        /// <param name="position">The type of the actor</param>
        /// <returns>A <see cref="global::GitHub.Orgs.Item.Insights.Api.TimeStats.Item.WithActor_typeItemRequestBuilder"/></returns>
        public global::GitHub.Orgs.Item.Insights.Api.TimeStats.Item.WithActor_typeItemRequestBuilder this[string position]
        {
            get
            {
                var urlTplParams = new Dictionary<string, object>(PathParameters);
                urlTplParams.Add("actor_type", position);
                return new global::GitHub.Orgs.Item.Insights.Api.TimeStats.Item.WithActor_typeItemRequestBuilder(urlTplParams, RequestAdapter);
            }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::GitHub.Orgs.Item.Insights.Api.TimeStats.TimeStatsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public TimeStatsRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/orgs/{org}/insights/api/time-stats?min_timestamp={min_timestamp}&timestamp_increment={timestamp_increment}{&max_timestamp*}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::GitHub.Orgs.Item.Insights.Api.TimeStats.TimeStatsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public TimeStatsRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/orgs/{org}/insights/api/time-stats?min_timestamp={min_timestamp}&timestamp_increment={timestamp_increment}{&max_timestamp*}", rawUrl)
        {
        }
        /// <summary>
        /// Get the number of API requests and rate-limited requests made within an organization over a specified time period.
        /// API method documentation <see href="https://docs.github.com/rest/orgs/api-insights#get-time-stats" />
        /// </summary>
        /// <returns>A List&lt;global::GitHub.Models.ApiInsightsTimeStats&gt;</returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<List<global::GitHub.Models.ApiInsightsTimeStats>?> GetAsync(Action<RequestConfiguration<global::GitHub.Orgs.Item.Insights.Api.TimeStats.TimeStatsRequestBuilder.TimeStatsRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<List<global::GitHub.Models.ApiInsightsTimeStats>> GetAsync(Action<RequestConfiguration<global::GitHub.Orgs.Item.Insights.Api.TimeStats.TimeStatsRequestBuilder.TimeStatsRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var collectionResult = await RequestAdapter.SendCollectionAsync<global::GitHub.Models.ApiInsightsTimeStats>(requestInfo, global::GitHub.Models.ApiInsightsTimeStats.CreateFromDiscriminatorValue, default, cancellationToken).ConfigureAwait(false);
            return collectionResult?.AsList();
        }
        /// <summary>
        /// Get the number of API requests and rate-limited requests made within an organization over a specified time period.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::GitHub.Orgs.Item.Insights.Api.TimeStats.TimeStatsRequestBuilder.TimeStatsRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::GitHub.Orgs.Item.Insights.Api.TimeStats.TimeStatsRequestBuilder.TimeStatsRequestBuilderGetQueryParameters>> requestConfiguration = default)
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
        /// <returns>A <see cref="global::GitHub.Orgs.Item.Insights.Api.TimeStats.TimeStatsRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::GitHub.Orgs.Item.Insights.Api.TimeStats.TimeStatsRequestBuilder WithUrl(string rawUrl)
        {
            return new global::GitHub.Orgs.Item.Insights.Api.TimeStats.TimeStatsRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Get the number of API requests and rate-limited requests made within an organization over a specified time period.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.19.0")]
        public partial class TimeStatsRequestBuilderGetQueryParameters 
        {
            /// <summary>The maximum timestamp to query for stats. Defaults to the time 30 days ago. This is a timestamp in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format: `YYYY-MM-DDTHH:MM:SSZ`.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("max_timestamp")]
            public string? MaxTimestamp { get; set; }
#nullable restore
#else
            [QueryParameter("max_timestamp")]
            public string MaxTimestamp { get; set; }
#endif
            /// <summary>The minimum timestamp to query for stats. This is a timestamp in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format: `YYYY-MM-DDTHH:MM:SSZ`.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("min_timestamp")]
            public string? MinTimestamp { get; set; }
#nullable restore
#else
            [QueryParameter("min_timestamp")]
            public string MinTimestamp { get; set; }
#endif
            /// <summary>The increment of time used to breakdown the query results (5m, 10m, 1h, etc.)</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("timestamp_increment")]
            public string? TimestampIncrement { get; set; }
#nullable restore
#else
            [QueryParameter("timestamp_increment")]
            public string TimestampIncrement { get; set; }
#endif
        }
    }
}
#pragma warning restore CS0618
