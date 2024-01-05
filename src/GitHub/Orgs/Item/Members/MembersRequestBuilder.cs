// <auto-generated/>
using GitHub.Models;
using GitHub.Orgs.Item.Members.Item;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace GitHub.Orgs.Item.Members {
    /// <summary>
    /// Builds and executes requests for operations under \orgs\{org}\members
    /// </summary>
    public class MembersRequestBuilder : BaseRequestBuilder {
        /// <summary>Gets an item from the GitHub.orgs.item.members.item collection</summary>
        /// <param name="position">The handle for the GitHub user account.</param>
        public WithUsernameItemRequestBuilder this[string position] { get {
            var urlTplParams = new Dictionary<string, object>(PathParameters);
            urlTplParams.Add("username", position);
            return new WithUsernameItemRequestBuilder(urlTplParams, RequestAdapter);
        } }
        /// <summary>
        /// Instantiates a new MembersRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public MembersRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/orgs/{org}/members{?filter*,role*,per_page*,page*}", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new MembersRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public MembersRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/orgs/{org}/members{?filter*,role*,per_page*,page*}", rawUrl) {
        }
        /// <summary>
        /// List all users who are members of an organization. If the authenticated user is also a member of this organization then both concealed and public members will be returned.
        /// API method documentation <see href="https://docs.github.com/rest/orgs/members#list-organization-members" />
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<List<SimpleUser>?> GetAsync(Action<RequestConfiguration<MembersRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task<List<SimpleUser>> GetAsync(Action<RequestConfiguration<MembersRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"422", ValidationError.CreateFromDiscriminatorValue},
            };
            var collectionResult = await RequestAdapter.SendCollectionAsync<SimpleUser>(requestInfo, SimpleUser.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
            return collectionResult?.ToList();
        }
        /// <summary>
        /// List all users who are members of an organization. If the authenticated user is also a member of this organization then both concealed and public members will be returned.
        /// </summary>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<MembersRequestBuilderGetQueryParameters>>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<MembersRequestBuilderGetQueryParameters>> requestConfiguration = default) {
#endif
            var requestInfo = new RequestInformation(Method.GET, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }
        /// <summary>
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public MembersRequestBuilder WithUrl(string rawUrl) {
            return new MembersRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// List all users who are members of an organization. If the authenticated user is also a member of this organization then both concealed and public members will be returned.
        /// </summary>
        public class MembersRequestBuilderGetQueryParameters {
            /// <summary>Filter members returned in the list. `2fa_disabled` means that only members without [two-factor authentication](https://github.com/blog/1614-two-factor-authentication) enabled will be returned. This options is only available for organization owners.</summary>
            [Obsolete("This property is deprecated, use filterAsGetFilterQueryParameterType instead")]
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("filter")]
            public string? Filter { get; set; }
#nullable restore
#else
            [QueryParameter("filter")]
            public string Filter { get; set; }
#endif
            /// <summary>Filter members returned in the list. `2fa_disabled` means that only members without [two-factor authentication](https://github.com/blog/1614-two-factor-authentication) enabled will be returned. This options is only available for organization owners.</summary>
            [QueryParameter("filter")]
            public GetFilterQueryParameterType? FilterAsGetFilterQueryParameterType { get; set; }
            /// <summary>The page number of the results to fetch. For more information, see &quot;[Using pagination in the REST API](https://docs.github.com/rest/using-the-rest-api/using-pagination-in-the-rest-api).&quot;</summary>
            [QueryParameter("page")]
            public int? Page { get; set; }
            /// <summary>The number of results per page (max 100). For more information, see &quot;[Using pagination in the REST API](https://docs.github.com/rest/using-the-rest-api/using-pagination-in-the-rest-api).&quot;</summary>
            [QueryParameter("per_page")]
            public int? PerPage { get; set; }
            /// <summary>Filter members returned by their role.</summary>
            [Obsolete("This property is deprecated, use roleAsGetRoleQueryParameterType instead")]
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("role")]
            public string? Role { get; set; }
#nullable restore
#else
            [QueryParameter("role")]
            public string Role { get; set; }
#endif
            /// <summary>Filter members returned by their role.</summary>
            [QueryParameter("role")]
            public GetRoleQueryParameterType? RoleAsGetRoleQueryParameterType { get; set; }
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        public class MembersRequestBuilderGetRequestConfiguration : RequestConfiguration<MembersRequestBuilderGetQueryParameters> {
        }
    }
}
