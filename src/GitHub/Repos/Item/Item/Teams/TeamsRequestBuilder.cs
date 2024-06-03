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
namespace GitHub.Repos.Item.Item.Teams {
    /// <summary>
    /// Builds and executes requests for operations under \repos\{owner-id}\{repo-id}\teams
    /// </summary>
    public class TeamsRequestBuilder : BaseRequestBuilder 
    {
        /// <summary>
        /// Instantiates a new <see cref="TeamsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public TeamsRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/repos/{owner%2Did}/{repo%2Did}/teams{?page*,per_page*}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="TeamsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public TeamsRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/repos/{owner%2Did}/{repo%2Did}/teams{?page*,per_page*}", rawUrl)
        {
        }
        /// <summary>
        /// Lists the teams that have access to the specified repository and that are also visible to the authenticated user.For a public repository, a team is listed only if that team added the public repository explicitly.OAuth app tokens and personal access tokens (classic) need the `public_repo` or `repo` scope to use this endpoint with a public repository, and `repo` scope to use this endpoint with a private repository.
        /// API method documentation <see href="https://docs.github.com/rest/repos/repos#list-repository-teams" />
        /// </summary>
        /// <returns>A List&lt;Team&gt;</returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="BasicError">When receiving a 404 status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<List<Team>?> GetAsync(Action<RequestConfiguration<TeamsRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<List<Team>> GetAsync(Action<RequestConfiguration<TeamsRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                {"404", BasicError.CreateFromDiscriminatorValue},
            };
            var collectionResult = await RequestAdapter.SendCollectionAsync<Team>(requestInfo, Team.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
            return collectionResult?.ToList();
        }
        /// <summary>
        /// Lists the teams that have access to the specified repository and that are also visible to the authenticated user.For a public repository, a team is listed only if that team added the public repository explicitly.OAuth app tokens and personal access tokens (classic) need the `public_repo` or `repo` scope to use this endpoint with a public repository, and `repo` scope to use this endpoint with a private repository.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<TeamsRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<TeamsRequestBuilderGetQueryParameters>> requestConfiguration = default)
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
        /// <returns>A <see cref="TeamsRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public TeamsRequestBuilder WithUrl(string rawUrl)
        {
            return new TeamsRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Lists the teams that have access to the specified repository and that are also visible to the authenticated user.For a public repository, a team is listed only if that team added the public repository explicitly.OAuth app tokens and personal access tokens (classic) need the `public_repo` or `repo` scope to use this endpoint with a public repository, and `repo` scope to use this endpoint with a private repository.
        /// </summary>
        public class TeamsRequestBuilderGetQueryParameters 
        {
            /// <summary>The page number of the results to fetch. For more information, see &quot;[Using pagination in the REST API](https://docs.github.com/rest/using-the-rest-api/using-pagination-in-the-rest-api).&quot;</summary>
            [QueryParameter("page")]
            public int? Page { get; set; }
            /// <summary>The number of results per page (max 100). For more information, see &quot;[Using pagination in the REST API](https://docs.github.com/rest/using-the-rest-api/using-pagination-in-the-rest-api).&quot;</summary>
            [QueryParameter("per_page")]
            public int? PerPage { get; set; }
        }
    }
}
