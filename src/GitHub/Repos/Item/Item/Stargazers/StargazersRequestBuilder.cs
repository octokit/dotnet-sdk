// <auto-generated/>
using GitHub.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace GitHub.Repos.Item.Item.Stargazers {
    /// <summary>
    /// Builds and executes requests for operations under \repos\{owner-id}\{repo-id}\stargazers
    /// </summary>
    public class StargazersRequestBuilder : BaseRequestBuilder {
        /// <summary>
        /// Instantiates a new <see cref="StargazersRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public StargazersRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/repos/{owner%2Did}/{repo%2Did}/stargazers{?page*,per_page*}", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new <see cref="StargazersRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public StargazersRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/repos/{owner%2Did}/{repo%2Did}/stargazers{?page*,per_page*}", rawUrl) {
        }
        /// <summary>
        /// Lists the people that have starred the repository.This endpoint supports the following custom media types. For more information, see &quot;[Media types](https://docs.github.com/rest/using-the-rest-api/getting-started-with-the-rest-api#media-types).&quot;- **`application/vnd.github.star+json`**: Includes a timestamp of when the star was created.
        /// API method documentation <see href="https://docs.github.com/rest/activity/starring#list-stargazers" />
        /// </summary>
        /// <returns>A <see cref="StargazersGetResponse"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="ValidationError">When receiving a 422 status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<StargazersGetResponse?> GetAsync(Action<RequestConfiguration<StargazersRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task<StargazersGetResponse> GetAsync(Action<RequestConfiguration<StargazersRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"422", ValidationError.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<StargazersGetResponse>(requestInfo, StargazersGetResponse.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Lists the people that have starred the repository.This endpoint supports the following custom media types. For more information, see &quot;[Media types](https://docs.github.com/rest/using-the-rest-api/getting-started-with-the-rest-api#media-types).&quot;- **`application/vnd.github.star+json`**: Includes a timestamp of when the star was created.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<StargazersRequestBuilderGetQueryParameters>>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<StargazersRequestBuilderGetQueryParameters>> requestConfiguration = default) {
#endif
            var requestInfo = new RequestInformation(Method.GET, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }
        /// <summary>
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <returns>A <see cref="StargazersRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public StargazersRequestBuilder WithUrl(string rawUrl) {
            return new StargazersRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Composed type wrapper for classes List&lt;SimpleUser&gt;, List&lt;Stargazer&gt;
        /// </summary>
        public class StargazersGetResponse : IComposedTypeWrapper, IParsable {
            /// <summary>Composed type representation for type List&lt;GitHub.Repos.Item.Item.Stargazers.SimpleUser&gt;</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public List<GitHub.Repos.Item.Item.Stargazers.SimpleUser>? SimpleUser { get; set; }
#nullable restore
#else
            public List<GitHub.Repos.Item.Item.Stargazers.SimpleUser> SimpleUser { get; set; }
#endif
            /// <summary>Composed type representation for type List&lt;GitHub.Repos.Item.Item.Stargazers.Stargazer&gt;</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public List<GitHub.Repos.Item.Item.Stargazers.Stargazer>? Stargazer { get; set; }
#nullable restore
#else
            public List<GitHub.Repos.Item.Item.Stargazers.Stargazer> Stargazer { get; set; }
#endif
            /// <summary>
            /// Creates a new instance of the appropriate class based on discriminator value
            /// </summary>
            /// <returns>A <see cref="StargazersGetResponse"/></returns>
            /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
            public static StargazersGetResponse CreateFromDiscriminatorValue(IParseNode parseNode) {
                _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
                var result = new StargazersGetResponse();
                if(parseNode.GetCollectionOfObjectValues<GitHub.Repos.Item.Item.Stargazers.SimpleUser>(GitHub.Repos.Item.Item.Stargazers.SimpleUser.CreateFromDiscriminatorValue)?.ToList() is List<GitHub.Repos.Item.Item.Stargazers.SimpleUser> simpleUserValue) {
                    result.SimpleUser = simpleUserValue;
                }
                else if(parseNode.GetCollectionOfObjectValues<GitHub.Repos.Item.Item.Stargazers.Stargazer>(GitHub.Repos.Item.Item.Stargazers.Stargazer.CreateFromDiscriminatorValue)?.ToList() is List<GitHub.Repos.Item.Item.Stargazers.Stargazer> stargazerValue) {
                    result.Stargazer = stargazerValue;
                }
                return result;
            }
            /// <summary>
            /// The deserialization information for the current model
            /// </summary>
            /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
            public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
                return new Dictionary<string, Action<IParseNode>>();
            }
            /// <summary>
            /// Serializes information the current object
            /// </summary>
            /// <param name="writer">Serialization writer to use to serialize this model</param>
            public virtual void Serialize(ISerializationWriter writer) {
                _ = writer ?? throw new ArgumentNullException(nameof(writer));
                if(SimpleUser != null) {
                    writer.WriteCollectionOfObjectValues<GitHub.Repos.Item.Item.Stargazers.SimpleUser>(null, SimpleUser);
                }
                else if(Stargazer != null) {
                    writer.WriteCollectionOfObjectValues<GitHub.Repos.Item.Item.Stargazers.Stargazer>(null, Stargazer);
                }
            }
        }
        /// <summary>
        /// Lists the people that have starred the repository.This endpoint supports the following custom media types. For more information, see &quot;[Media types](https://docs.github.com/rest/using-the-rest-api/getting-started-with-the-rest-api#media-types).&quot;- **`application/vnd.github.star+json`**: Includes a timestamp of when the star was created.
        /// </summary>
        public class StargazersRequestBuilderGetQueryParameters {
            /// <summary>The page number of the results to fetch. For more information, see &quot;[Using pagination in the REST API](https://docs.github.com/rest/using-the-rest-api/using-pagination-in-the-rest-api).&quot;</summary>
            [QueryParameter("page")]
            public int? Page { get; set; }
            /// <summary>The number of results per page (max 100). For more information, see &quot;[Using pagination in the REST API](https://docs.github.com/rest/using-the-rest-api/using-pagination-in-the-rest-api).&quot;</summary>
            [QueryParameter("per_page")]
            public int? PerPage { get; set; }
        }
    }
}
