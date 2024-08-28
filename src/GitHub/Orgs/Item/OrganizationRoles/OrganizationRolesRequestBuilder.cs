// <auto-generated/>
using GitHub.Models;
using GitHub.Orgs.Item.OrganizationRoles.Item;
using GitHub.Orgs.Item.OrganizationRoles.Teams;
using GitHub.Orgs.Item.OrganizationRoles.Users;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace GitHub.Orgs.Item.OrganizationRoles
{
    /// <summary>
    /// Builds and executes requests for operations under \orgs\{org}\organization-roles
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.17.0")]
    public partial class OrganizationRolesRequestBuilder : BaseRequestBuilder
    {
        /// <summary>The teams property</summary>
        public global::GitHub.Orgs.Item.OrganizationRoles.Teams.TeamsRequestBuilder Teams
        {
            get => new global::GitHub.Orgs.Item.OrganizationRoles.Teams.TeamsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The users property</summary>
        public global::GitHub.Orgs.Item.OrganizationRoles.Users.UsersRequestBuilder Users
        {
            get => new global::GitHub.Orgs.Item.OrganizationRoles.Users.UsersRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Gets an item from the GitHub.orgs.item.organizationRoles.item collection</summary>
        /// <param name="position">The unique identifier of the role.</param>
        /// <returns>A <see cref="global::GitHub.Orgs.Item.OrganizationRoles.Item.WithRole_ItemRequestBuilder"/></returns>
        public global::GitHub.Orgs.Item.OrganizationRoles.Item.WithRole_ItemRequestBuilder this[int position]
        {
            get
            {
                var urlTplParams = new Dictionary<string, object>(PathParameters);
                urlTplParams.Add("role_id", position);
                return new global::GitHub.Orgs.Item.OrganizationRoles.Item.WithRole_ItemRequestBuilder(urlTplParams, RequestAdapter);
            }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::GitHub.Orgs.Item.OrganizationRoles.OrganizationRolesRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public OrganizationRolesRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/orgs/{org}/organization-roles", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::GitHub.Orgs.Item.OrganizationRoles.OrganizationRolesRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public OrganizationRolesRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/orgs/{org}/organization-roles", rawUrl)
        {
        }
        /// <summary>
        /// Lists the organization roles available in this organization. For more information on organization roles, see &quot;[Using organization roles](https://docs.github.com/organizations/managing-peoples-access-to-your-organization-with-roles/using-organization-roles).&quot;To use this endpoint, the authenticated user must be one of:- An administrator for the organization.- A user, or a user on a team, with the fine-grained permissions of `read_organization_custom_org_role` in the organization.OAuth app tokens and personal access tokens (classic) need the `admin:org` scope to use this endpoint.
        /// API method documentation <see href="https://docs.github.com/rest/orgs/organization-roles#get-all-organization-roles-for-an-organization" />
        /// </summary>
        /// <returns>A <see cref="global::GitHub.Orgs.Item.OrganizationRoles.OrganizationRolesGetResponse"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::GitHub.Models.BasicError">When receiving a 404 status code</exception>
        /// <exception cref="global::GitHub.Models.ValidationError">When receiving a 422 status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::GitHub.Orgs.Item.OrganizationRoles.OrganizationRolesGetResponse?> GetAsync(Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::GitHub.Orgs.Item.OrganizationRoles.OrganizationRolesGetResponse> GetAsync(Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "404", global::GitHub.Models.BasicError.CreateFromDiscriminatorValue },
                { "422", global::GitHub.Models.ValidationError.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<global::GitHub.Orgs.Item.OrganizationRoles.OrganizationRolesGetResponse>(requestInfo, global::GitHub.Orgs.Item.OrganizationRoles.OrganizationRolesGetResponse.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Lists the organization roles available in this organization. For more information on organization roles, see &quot;[Using organization roles](https://docs.github.com/organizations/managing-peoples-access-to-your-organization-with-roles/using-organization-roles).&quot;To use this endpoint, the authenticated user must be one of:- An administrator for the organization.- A user, or a user on a team, with the fine-grained permissions of `read_organization_custom_org_role` in the organization.OAuth app tokens and personal access tokens (classic) need the `admin:org` scope to use this endpoint.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default)
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
        /// <returns>A <see cref="global::GitHub.Orgs.Item.OrganizationRoles.OrganizationRolesRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::GitHub.Orgs.Item.OrganizationRoles.OrganizationRolesRequestBuilder WithUrl(string rawUrl)
        {
            return new global::GitHub.Orgs.Item.OrganizationRoles.OrganizationRolesRequestBuilder(rawUrl, RequestAdapter);
        }
    }
}
