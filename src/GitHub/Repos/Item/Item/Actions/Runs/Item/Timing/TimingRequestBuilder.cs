// <auto-generated/>
using GitHub.Models;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace GitHub.Repos.Item.Item.Actions.Runs.Item.Timing
{
    /// <summary>
    /// Builds and executes requests for operations under \repos\{owner-id}\{repo-id}\actions\runs\{run_id}\timing
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.17.0")]
    public partial class TimingRequestBuilder : BaseRequestBuilder
    {
        /// <summary>
        /// Instantiates a new <see cref="global::GitHub.Repos.Item.Item.Actions.Runs.Item.Timing.TimingRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public TimingRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/repos/{owner%2Did}/{repo%2Did}/actions/runs/{run_id}/timing", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::GitHub.Repos.Item.Item.Actions.Runs.Item.Timing.TimingRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public TimingRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/repos/{owner%2Did}/{repo%2Did}/actions/runs/{run_id}/timing", rawUrl)
        {
        }
        /// <summary>
        /// Gets the number of billable minutes and total run time for a specific workflow run. Billable minutes only apply to workflows in private repositories that use GitHub-hosted runners. Usage is listed for each GitHub-hosted runner operating system in milliseconds. Any job re-runs are also included in the usage. The usage does not include the multiplier for macOS and Windows runners and is not rounded up to the nearest whole minute. For more information, see &quot;[Managing billing for GitHub Actions](https://docs.github.com/github/setting-up-and-managing-billing-and-payments-on-github/managing-billing-for-github-actions)&quot;.Anyone with read access to the repository can use this endpoint.OAuth app tokens and personal access tokens (classic) need the `repo` scope to use this endpoint with a private repository.
        /// API method documentation <see href="https://docs.github.com/rest/actions/workflow-runs#get-workflow-run-usage" />
        /// </summary>
        /// <returns>A <see cref="global::GitHub.Models.WorkflowRunUsage"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::GitHub.Models.WorkflowRunUsage?> GetAsync(Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::GitHub.Models.WorkflowRunUsage> GetAsync(Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            return await RequestAdapter.SendAsync<global::GitHub.Models.WorkflowRunUsage>(requestInfo, global::GitHub.Models.WorkflowRunUsage.CreateFromDiscriminatorValue, default, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Gets the number of billable minutes and total run time for a specific workflow run. Billable minutes only apply to workflows in private repositories that use GitHub-hosted runners. Usage is listed for each GitHub-hosted runner operating system in milliseconds. Any job re-runs are also included in the usage. The usage does not include the multiplier for macOS and Windows runners and is not rounded up to the nearest whole minute. For more information, see &quot;[Managing billing for GitHub Actions](https://docs.github.com/github/setting-up-and-managing-billing-and-payments-on-github/managing-billing-for-github-actions)&quot;.Anyone with read access to the repository can use this endpoint.OAuth app tokens and personal access tokens (classic) need the `repo` scope to use this endpoint with a private repository.
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
        /// <returns>A <see cref="global::GitHub.Repos.Item.Item.Actions.Runs.Item.Timing.TimingRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::GitHub.Repos.Item.Item.Actions.Runs.Item.Timing.TimingRequestBuilder WithUrl(string rawUrl)
        {
            return new global::GitHub.Repos.Item.Item.Actions.Runs.Item.Timing.TimingRequestBuilder(rawUrl, RequestAdapter);
        }
    }
}
