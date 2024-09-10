// <auto-generated/>
#pragma warning disable CS0618
using GitHub.Models;
using GitHub.User.Installations.Item.Repositories.Item;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace GitHub.User.Installations.Item.Repositories
{
    /// <summary>
    /// Builds and executes requests for operations under \user\installations\{installation_id}\repositories
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.18.0")]
    public partial class RepositoriesRequestBuilder : BaseRequestBuilder
    {
        /// <summary>Gets an item from the GitHub.user.installations.item.repositories.item collection</summary>
        /// <param name="position">The unique identifier of the repository.</param>
        /// <returns>A <see cref="global::GitHub.User.Installations.Item.Repositories.Item.WithRepository_ItemRequestBuilder"/></returns>
        public global::GitHub.User.Installations.Item.Repositories.Item.WithRepository_ItemRequestBuilder this[int position]
        {
            get
            {
                var urlTplParams = new Dictionary<string, object>(PathParameters);
                urlTplParams.Add("repository_id", position);
                return new global::GitHub.User.Installations.Item.Repositories.Item.WithRepository_ItemRequestBuilder(urlTplParams, RequestAdapter);
            }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::GitHub.User.Installations.Item.Repositories.RepositoriesRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public RepositoriesRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/user/installations/{installation_id}/repositories{?page*,per_page*}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::GitHub.User.Installations.Item.Repositories.RepositoriesRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public RepositoriesRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/user/installations/{installation_id}/repositories{?page*,per_page*}", rawUrl)
        {
        }
        /// <summary>
        /// List repositories that the authenticated user has explicit permission (`:read`, `:write`, or `:admin`) to access for an installation.The authenticated user has explicit permission to access repositories they own, repositories where they are a collaborator, and repositories that they can access through an organization membership.The access the user has to each repository is included in the hash under the `permissions` key.
        /// API method documentation <see href="https://docs.github.com/rest/apps/installations#list-repositories-accessible-to-the-user-access-token" />
        /// </summary>
        /// <returns>A <see cref="global::GitHub.User.Installations.Item.Repositories.RepositoriesGetResponse"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::GitHub.Models.BasicError">When receiving a 403 status code</exception>
        /// <exception cref="global::GitHub.Models.BasicError">When receiving a 404 status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::GitHub.User.Installations.Item.Repositories.RepositoriesGetResponse?> GetAsync(Action<RequestConfiguration<global::GitHub.User.Installations.Item.Repositories.RepositoriesRequestBuilder.RepositoriesRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::GitHub.User.Installations.Item.Repositories.RepositoriesGetResponse> GetAsync(Action<RequestConfiguration<global::GitHub.User.Installations.Item.Repositories.RepositoriesRequestBuilder.RepositoriesRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "403", global::GitHub.Models.BasicError.CreateFromDiscriminatorValue },
                { "404", global::GitHub.Models.BasicError.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<global::GitHub.User.Installations.Item.Repositories.RepositoriesGetResponse>(requestInfo, global::GitHub.User.Installations.Item.Repositories.RepositoriesGetResponse.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// List repositories that the authenticated user has explicit permission (`:read`, `:write`, or `:admin`) to access for an installation.The authenticated user has explicit permission to access repositories they own, repositories where they are a collaborator, and repositories that they can access through an organization membership.The access the user has to each repository is included in the hash under the `permissions` key.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::GitHub.User.Installations.Item.Repositories.RepositoriesRequestBuilder.RepositoriesRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::GitHub.User.Installations.Item.Repositories.RepositoriesRequestBuilder.RepositoriesRequestBuilderGetQueryParameters>> requestConfiguration = default)
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
        /// <returns>A <see cref="global::GitHub.User.Installations.Item.Repositories.RepositoriesRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::GitHub.User.Installations.Item.Repositories.RepositoriesRequestBuilder WithUrl(string rawUrl)
        {
            return new global::GitHub.User.Installations.Item.Repositories.RepositoriesRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// List repositories that the authenticated user has explicit permission (`:read`, `:write`, or `:admin`) to access for an installation.The authenticated user has explicit permission to access repositories they own, repositories where they are a collaborator, and repositories that they can access through an organization membership.The access the user has to each repository is included in the hash under the `permissions` key.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.18.0")]
        public partial class RepositoriesRequestBuilderGetQueryParameters 
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
#pragma warning restore CS0618
