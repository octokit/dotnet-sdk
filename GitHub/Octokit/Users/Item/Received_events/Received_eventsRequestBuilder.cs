// <auto-generated/>
using GitHub.Octokit.Models;
using GitHub.Octokit.Users.Item.Received_events.Public;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace GitHub.Octokit.Users.Item.Received_events {
    /// <summary>
    /// Builds and executes requests for operations under \users\{username}\received_events
    /// </summary>
    public class Received_eventsRequestBuilder : BaseRequestBuilder {
        /// <summary>The public property</summary>
        public PublicRequestBuilder Public { get =>
            new PublicRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new Received_eventsRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public Received_eventsRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/users/{username}/received_events{?per_page*,page*}", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new Received_eventsRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public Received_eventsRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/users/{username}/received_events{?per_page*,page*}", rawUrl) {
        }
        /// <summary>
        /// These are events that you&apos;ve received by watching repos and following users. If you are authenticated as the given user, you will see private events. Otherwise, you&apos;ll only see public events.
        /// API method documentation <see href="https://docs.github.com/rest/activity/events#list-events-received-by-the-authenticated-user" />
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<List<Event>?> GetAsync(Action<Received_eventsRequestBuilderGetRequestConfiguration>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task<List<Event>> GetAsync(Action<Received_eventsRequestBuilderGetRequestConfiguration> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var collectionResult = await RequestAdapter.SendCollectionAsync<Event>(requestInfo, Event.CreateFromDiscriminatorValue, default, cancellationToken).ConfigureAwait(false);
            return collectionResult?.ToList();
        }
        /// <summary>
        /// These are events that you&apos;ve received by watching repos and following users. If you are authenticated as the given user, you will see private events. Otherwise, you&apos;ll only see public events.
        /// </summary>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<Received_eventsRequestBuilderGetRequestConfiguration>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<Received_eventsRequestBuilderGetRequestConfiguration> requestConfiguration = default) {
#endif
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            if (requestConfiguration != null) {
                var requestConfig = new Received_eventsRequestBuilderGetRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            requestInfo.Headers.TryAdd("Accept", "application/json;q=1");
            return requestInfo;
        }
        /// <summary>
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public Received_eventsRequestBuilder WithUrl(string rawUrl) {
            return new Received_eventsRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// These are events that you&apos;ve received by watching repos and following users. If you are authenticated as the given user, you will see private events. Otherwise, you&apos;ll only see public events.
        /// </summary>
        public class Received_eventsRequestBuilderGetQueryParameters {
            /// <summary>Page number of the results to fetch.</summary>
            [QueryParameter("page")]
            public int? Page { get; set; }
            /// <summary>The number of results per page (max 100).</summary>
            [QueryParameter("per_page")]
            public int? PerPage { get; set; }
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        public class Received_eventsRequestBuilderGetRequestConfiguration {
            /// <summary>Request headers</summary>
            public RequestHeaders Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>Request query parameters</summary>
            public Received_eventsRequestBuilderGetQueryParameters QueryParameters { get; set; } = new Received_eventsRequestBuilderGetQueryParameters();
            /// <summary>
            /// Instantiates a new received_eventsRequestBuilderGetRequestConfiguration and sets the default values.
            /// </summary>
            public Received_eventsRequestBuilderGetRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new RequestHeaders();
            }
        }
    }
}