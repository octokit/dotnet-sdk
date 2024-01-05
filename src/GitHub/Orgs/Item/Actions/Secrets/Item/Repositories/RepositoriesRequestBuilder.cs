// <auto-generated/>
using GitHub.Orgs.Item.Actions.Secrets.Item.Repositories.Item;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace GitHub.Orgs.Item.Actions.Secrets.Item.Repositories {
    /// <summary>
    /// Builds and executes requests for operations under \orgs\{org}\actions\secrets\{secret_name}\repositories
    /// </summary>
    public class RepositoriesRequestBuilder : BaseRequestBuilder {
        /// <summary>Gets an item from the GitHub.orgs.item.actions.secrets.item.repositories.item collection</summary>
        /// <param name="position">Unique identifier of the item</param>
        public WithRepository_ItemRequestBuilder this[int position] { get {
            var urlTplParams = new Dictionary<string, object>(PathParameters);
            urlTplParams.Add("repository_id", position);
            return new WithRepository_ItemRequestBuilder(urlTplParams, RequestAdapter);
        } }
        /// <summary>Gets an item from the GitHub.orgs.item.actions.secrets.item.repositories.item collection</summary>
        /// <param name="position">Unique identifier of the item</param>
        [Obsolete("This indexer is deprecated and will be removed in the next major version. Use the one with the typed parameter instead.")]
        public WithRepository_ItemRequestBuilder this[string position] { get {
            var urlTplParams = new Dictionary<string, object>(PathParameters);
            if (!string.IsNullOrWhiteSpace(position)) urlTplParams.Add("repository_id", position);
            return new WithRepository_ItemRequestBuilder(urlTplParams, RequestAdapter);
        } }
        /// <summary>
        /// Instantiates a new RepositoriesRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public RepositoriesRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/orgs/{org}/actions/secrets/{secret_name}/repositories{?page*,per_page*}", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new RepositoriesRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public RepositoriesRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/orgs/{org}/actions/secrets/{secret_name}/repositories{?page*,per_page*}", rawUrl) {
        }
        /// <summary>
        /// Lists all repositories that have been selected when the `visibility`for repository access to a secret is set to `selected`.You must authenticate using an access token with the `admin:org` scope to use this endpoint.If the repository is private, you must use an access token with the `repo` scope.GitHub Apps must have the `secrets` organization permission to use this endpoint.Authenticated users must have collaborator access to a repository to create, update, or read secrets.
        /// API method documentation <see href="https://docs.github.com/rest/actions/secrets#list-selected-repositories-for-an-organization-secret" />
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<RepositoriesGetResponse?> GetAsRepositoriesGetResponseAsync(Action<RequestConfiguration<RepositoriesRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task<RepositoriesGetResponse> GetAsRepositoriesGetResponseAsync(Action<RequestConfiguration<RepositoriesRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            return await RequestAdapter.SendAsync<RepositoriesGetResponse>(requestInfo, RepositoriesGetResponse.CreateFromDiscriminatorValue, default, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Lists all repositories that have been selected when the `visibility`for repository access to a secret is set to `selected`.You must authenticate using an access token with the `admin:org` scope to use this endpoint.If the repository is private, you must use an access token with the `repo` scope.GitHub Apps must have the `secrets` organization permission to use this endpoint.Authenticated users must have collaborator access to a repository to create, update, or read secrets.
        /// API method documentation <see href="https://docs.github.com/rest/actions/secrets#list-selected-repositories-for-an-organization-secret" />
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        [Obsolete("This method is obsolete. Use GetAsRepositoriesGetResponse instead.")]
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<RepositoriesResponse?> GetAsync(Action<RequestConfiguration<RepositoriesRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task<RepositoriesResponse> GetAsync(Action<RequestConfiguration<RepositoriesRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            return await RequestAdapter.SendAsync<RepositoriesResponse>(requestInfo, RepositoriesResponse.CreateFromDiscriminatorValue, default, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Replaces all repositories for an organization secret when the `visibility`for repository access is set to `selected`. The visibility is set when you [Createor update an organization secret](https://docs.github.com/rest/actions/secrets#create-or-update-an-organization-secret).You must authenticate using an access token with the `admin:org` scope to use this endpoint.If the repository is private, you must use an access token with the `repo` scope.GitHub Apps must have the `secrets` organization permission to use this endpoint.Authenticated users must have collaborator access to a repository to create, update, or read secrets.
        /// API method documentation <see href="https://docs.github.com/rest/actions/secrets#set-selected-repositories-for-an-organization-secret" />
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task PutAsync(RepositoriesPutRequestBody body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task PutAsync(RepositoriesPutRequestBody body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = ToPutRequestInformation(body, requestConfiguration);
            await RequestAdapter.SendNoContentAsync(requestInfo, default, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Lists all repositories that have been selected when the `visibility`for repository access to a secret is set to `selected`.You must authenticate using an access token with the `admin:org` scope to use this endpoint.If the repository is private, you must use an access token with the `repo` scope.GitHub Apps must have the `secrets` organization permission to use this endpoint.Authenticated users must have collaborator access to a repository to create, update, or read secrets.
        /// </summary>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<RepositoriesRequestBuilderGetQueryParameters>>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<RepositoriesRequestBuilderGetQueryParameters>> requestConfiguration = default) {
#endif
            var requestInfo = new RequestInformation(Method.GET, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }
        /// <summary>
        /// Replaces all repositories for an organization secret when the `visibility`for repository access is set to `selected`. The visibility is set when you [Createor update an organization secret](https://docs.github.com/rest/actions/secrets#create-or-update-an-organization-secret).You must authenticate using an access token with the `admin:org` scope to use this endpoint.If the repository is private, you must use an access token with the `repo` scope.GitHub Apps must have the `secrets` organization permission to use this endpoint.Authenticated users must have collaborator access to a repository to create, update, or read secrets.
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPutRequestInformation(RepositoriesPutRequestBody body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToPutRequestInformation(RepositoriesPutRequestBody body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default) {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation(Method.PUT, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            return requestInfo;
        }
        /// <summary>
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public RepositoriesRequestBuilder WithUrl(string rawUrl) {
            return new RepositoriesRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Lists all repositories that have been selected when the `visibility`for repository access to a secret is set to `selected`.You must authenticate using an access token with the `admin:org` scope to use this endpoint.If the repository is private, you must use an access token with the `repo` scope.GitHub Apps must have the `secrets` organization permission to use this endpoint.Authenticated users must have collaborator access to a repository to create, update, or read secrets.
        /// </summary>
        public class RepositoriesRequestBuilderGetQueryParameters {
            /// <summary>The page number of the results to fetch. For more information, see &quot;[Using pagination in the REST API](https://docs.github.com/rest/using-the-rest-api/using-pagination-in-the-rest-api).&quot;</summary>
            [QueryParameter("page")]
            public int? Page { get; set; }
            /// <summary>The number of results per page (max 100). For more information, see &quot;[Using pagination in the REST API](https://docs.github.com/rest/using-the-rest-api/using-pagination-in-the-rest-api).&quot;</summary>
            [QueryParameter("per_page")]
            public int? PerPage { get; set; }
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        public class RepositoriesRequestBuilderGetRequestConfiguration : RequestConfiguration<RepositoriesRequestBuilderGetQueryParameters> {
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        public class RepositoriesRequestBuilderPutRequestConfiguration : RequestConfiguration<DefaultQueryParameters> {
        }
    }
}
