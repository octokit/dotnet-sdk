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
namespace GitHub.Repos.Item.Item.CodeScanning.Analyses.Item
{
    /// <summary>
    /// Builds and executes requests for operations under \repos\{owner-id}\{repo-id}\code-scanning\analyses\{analysis_id}
    /// </summary>
    public class WithAnalysis_ItemRequestBuilder : BaseRequestBuilder
    {
        /// <summary>
        /// Instantiates a new <see cref="WithAnalysis_ItemRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithAnalysis_ItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/repos/{owner%2Did}/{repo%2Did}/code-scanning/analyses/{analysis_id}{?confirm_delete*}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="WithAnalysis_ItemRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithAnalysis_ItemRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/repos/{owner%2Did}/{repo%2Did}/code-scanning/analyses/{analysis_id}{?confirm_delete*}", rawUrl)
        {
        }
        /// <summary>
        /// Deletes a specified code scanning analysis from a repository.You can delete one analysis at a time.To delete a series of analyses, start with the most recent analysis and work backwards.Conceptually, the process is similar to the undo function in a text editor.When you list the analyses for a repository,one or more will be identified as deletable in the response:```&quot;deletable&quot;: true```An analysis is deletable when it&apos;s the most recent in a set of analyses.Typically, a repository will have multiple sets of analysesfor each enabled code scanning tool,where a set is determined by a unique combination of analysis values:* `ref`* `tool`* `category`If you attempt to delete an analysis that is not the most recent in a set,you&apos;ll get a 400 response with the message:```Analysis specified is not deletable.```The response from a successful `DELETE` operation provides you withtwo alternative URLs for deleting the next analysis in the set:`next_analysis_url` and `confirm_delete_url`.Use the `next_analysis_url` URL if you want to avoid accidentally deleting the final analysisin a set. This is a useful option if you want to preserve at least one analysisfor the specified tool in your repository.Use the `confirm_delete_url` URL if you are content to remove all analyses for a tool.When you delete the last analysis in a set, the value of `next_analysis_url` and `confirm_delete_url`in the 200 response is `null`.As an example of the deletion process,let&apos;s imagine that you added a workflow that configured a particular code scanning toolto analyze the code in a repository. This tool has added 15 analyses:10 on the default branch, and another 5 on a topic branch.You therefore have two separate sets of analyses for this tool.You&apos;ve now decided that you want to remove all of the analyses for the tool.To do this you must make 15 separate deletion requests.To start, you must find an analysis that&apos;s identified as deletable.Each set of analyses always has one that&apos;s identified as deletable.Having found the deletable analysis for one of the two sets,delete this analysis and then continue deleting the next analysis in the set until they&apos;re all deleted.Then repeat the process for the second set.The procedure therefore consists of a nested loop:**Outer loop**:* List the analyses for the repository, filtered by tool.* Parse this list to find a deletable analysis. If found:  **Inner loop**:  * Delete the identified analysis.  * Parse the response for the value of `confirm_delete_url` and, if found, use this in the next iteration.The above process assumes that you want to remove all trace of the tool&apos;s analyses from the GitHub user interface, for the specified repository, and it therefore uses the `confirm_delete_url` value. Alternatively, you could use the `next_analysis_url` value, which would leave the last analysis in each set undeleted to avoid removing a tool&apos;s analysis entirely.OAuth app tokens and personal access tokens (classic) need the `repo` scope to use this endpoint with private or public repositories, or the `public_repo` scope to use this endpoint with only public repositories.
        /// API method documentation <see href="https://docs.github.com/rest/code-scanning/code-scanning#delete-a-code-scanning-analysis-from-a-repository" />
        /// </summary>
        /// <returns>A <see cref="CodeScanningAnalysisDeletion"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="BasicError">When receiving a 400 status code</exception>
        /// <exception cref="BasicError">When receiving a 403 status code</exception>
        /// <exception cref="BasicError">When receiving a 404 status code</exception>
        /// <exception cref="CodeScanningAnalysisDeletion503Error">When receiving a 503 status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<CodeScanningAnalysisDeletion?> DeleteAsync(Action<RequestConfiguration<WithAnalysis_ItemRequestBuilderDeleteQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<CodeScanningAnalysisDeletion> DeleteAsync(Action<RequestConfiguration<WithAnalysis_ItemRequestBuilderDeleteQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToDeleteRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "400", BasicError.CreateFromDiscriminatorValue },
                { "403", BasicError.CreateFromDiscriminatorValue },
                { "404", BasicError.CreateFromDiscriminatorValue },
                { "503", CodeScanningAnalysisDeletion503Error.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<CodeScanningAnalysisDeletion>(requestInfo, CodeScanningAnalysisDeletion.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Gets a specified code scanning analysis for a repository.The default JSON response contains fields that describe the analysis.This includes the Git reference and commit SHA to which the analysis relates,the datetime of the analysis, the name of the code scanning tool,and the number of alerts.The `rules_count` field in the default response give the number of rulesthat were run in the analysis.For very old analyses this data is not available,and `0` is returned in this field.This endpoint supports the following custom media types. For more information, see &quot;[Media types](https://docs.github.com/rest/using-the-rest-api/getting-started-with-the-rest-api#media-types).&quot;- **`application/sarif+json`**: Instead of returning a summary of the analysis, this endpoint returns a subset of the analysis data that was uploaded. The data is formatted as [SARIF version 2.1.0](https://docs.oasis-open.org/sarif/sarif/v2.1.0/cs01/sarif-v2.1.0-cs01.html). It also returns additional data such as the `github/alertNumber` and `github/alertUrl` properties.OAuth app tokens and personal access tokens (classic) need the `security_events` scope to use this endpoint with private or public repositories, or the `public_repo` scope to use this endpoint with only public repositories.
        /// API method documentation <see href="https://docs.github.com/rest/code-scanning/code-scanning#get-a-code-scanning-analysis-for-a-repository" />
        /// </summary>
        /// <returns>A <see cref="CodeScanningAnalysis"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="BasicError">When receiving a 403 status code</exception>
        /// <exception cref="BasicError">When receiving a 404 status code</exception>
        /// <exception cref="CodeScanningAnalysis503Error">When receiving a 503 status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<CodeScanningAnalysis?> GetAsync(Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<CodeScanningAnalysis> GetAsync(Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "403", BasicError.CreateFromDiscriminatorValue },
                { "404", BasicError.CreateFromDiscriminatorValue },
                { "503", CodeScanningAnalysis503Error.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<CodeScanningAnalysis>(requestInfo, CodeScanningAnalysis.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Deletes a specified code scanning analysis from a repository.You can delete one analysis at a time.To delete a series of analyses, start with the most recent analysis and work backwards.Conceptually, the process is similar to the undo function in a text editor.When you list the analyses for a repository,one or more will be identified as deletable in the response:```&quot;deletable&quot;: true```An analysis is deletable when it&apos;s the most recent in a set of analyses.Typically, a repository will have multiple sets of analysesfor each enabled code scanning tool,where a set is determined by a unique combination of analysis values:* `ref`* `tool`* `category`If you attempt to delete an analysis that is not the most recent in a set,you&apos;ll get a 400 response with the message:```Analysis specified is not deletable.```The response from a successful `DELETE` operation provides you withtwo alternative URLs for deleting the next analysis in the set:`next_analysis_url` and `confirm_delete_url`.Use the `next_analysis_url` URL if you want to avoid accidentally deleting the final analysisin a set. This is a useful option if you want to preserve at least one analysisfor the specified tool in your repository.Use the `confirm_delete_url` URL if you are content to remove all analyses for a tool.When you delete the last analysis in a set, the value of `next_analysis_url` and `confirm_delete_url`in the 200 response is `null`.As an example of the deletion process,let&apos;s imagine that you added a workflow that configured a particular code scanning toolto analyze the code in a repository. This tool has added 15 analyses:10 on the default branch, and another 5 on a topic branch.You therefore have two separate sets of analyses for this tool.You&apos;ve now decided that you want to remove all of the analyses for the tool.To do this you must make 15 separate deletion requests.To start, you must find an analysis that&apos;s identified as deletable.Each set of analyses always has one that&apos;s identified as deletable.Having found the deletable analysis for one of the two sets,delete this analysis and then continue deleting the next analysis in the set until they&apos;re all deleted.Then repeat the process for the second set.The procedure therefore consists of a nested loop:**Outer loop**:* List the analyses for the repository, filtered by tool.* Parse this list to find a deletable analysis. If found:  **Inner loop**:  * Delete the identified analysis.  * Parse the response for the value of `confirm_delete_url` and, if found, use this in the next iteration.The above process assumes that you want to remove all trace of the tool&apos;s analyses from the GitHub user interface, for the specified repository, and it therefore uses the `confirm_delete_url` value. Alternatively, you could use the `next_analysis_url` value, which would leave the last analysis in each set undeleted to avoid removing a tool&apos;s analysis entirely.OAuth app tokens and personal access tokens (classic) need the `repo` scope to use this endpoint with private or public repositories, or the `public_repo` scope to use this endpoint with only public repositories.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToDeleteRequestInformation(Action<RequestConfiguration<WithAnalysis_ItemRequestBuilderDeleteQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToDeleteRequestInformation(Action<RequestConfiguration<WithAnalysis_ItemRequestBuilderDeleteQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.DELETE, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }
        /// <summary>
        /// Gets a specified code scanning analysis for a repository.The default JSON response contains fields that describe the analysis.This includes the Git reference and commit SHA to which the analysis relates,the datetime of the analysis, the name of the code scanning tool,and the number of alerts.The `rules_count` field in the default response give the number of rulesthat were run in the analysis.For very old analyses this data is not available,and `0` is returned in this field.This endpoint supports the following custom media types. For more information, see &quot;[Media types](https://docs.github.com/rest/using-the-rest-api/getting-started-with-the-rest-api#media-types).&quot;- **`application/sarif+json`**: Instead of returning a summary of the analysis, this endpoint returns a subset of the analysis data that was uploaded. The data is formatted as [SARIF version 2.1.0](https://docs.oasis-open.org/sarif/sarif/v2.1.0/cs01/sarif-v2.1.0-cs01.html). It also returns additional data such as the `github/alertNumber` and `github/alertUrl` properties.OAuth app tokens and personal access tokens (classic) need the `security_events` scope to use this endpoint with private or public repositories, or the `public_repo` scope to use this endpoint with only public repositories.
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
        /// <returns>A <see cref="WithAnalysis_ItemRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public WithAnalysis_ItemRequestBuilder WithUrl(string rawUrl)
        {
            return new WithAnalysis_ItemRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Deletes a specified code scanning analysis from a repository.You can delete one analysis at a time.To delete a series of analyses, start with the most recent analysis and work backwards.Conceptually, the process is similar to the undo function in a text editor.When you list the analyses for a repository,one or more will be identified as deletable in the response:```&quot;deletable&quot;: true```An analysis is deletable when it&apos;s the most recent in a set of analyses.Typically, a repository will have multiple sets of analysesfor each enabled code scanning tool,where a set is determined by a unique combination of analysis values:* `ref`* `tool`* `category`If you attempt to delete an analysis that is not the most recent in a set,you&apos;ll get a 400 response with the message:```Analysis specified is not deletable.```The response from a successful `DELETE` operation provides you withtwo alternative URLs for deleting the next analysis in the set:`next_analysis_url` and `confirm_delete_url`.Use the `next_analysis_url` URL if you want to avoid accidentally deleting the final analysisin a set. This is a useful option if you want to preserve at least one analysisfor the specified tool in your repository.Use the `confirm_delete_url` URL if you are content to remove all analyses for a tool.When you delete the last analysis in a set, the value of `next_analysis_url` and `confirm_delete_url`in the 200 response is `null`.As an example of the deletion process,let&apos;s imagine that you added a workflow that configured a particular code scanning toolto analyze the code in a repository. This tool has added 15 analyses:10 on the default branch, and another 5 on a topic branch.You therefore have two separate sets of analyses for this tool.You&apos;ve now decided that you want to remove all of the analyses for the tool.To do this you must make 15 separate deletion requests.To start, you must find an analysis that&apos;s identified as deletable.Each set of analyses always has one that&apos;s identified as deletable.Having found the deletable analysis for one of the two sets,delete this analysis and then continue deleting the next analysis in the set until they&apos;re all deleted.Then repeat the process for the second set.The procedure therefore consists of a nested loop:**Outer loop**:* List the analyses for the repository, filtered by tool.* Parse this list to find a deletable analysis. If found:  **Inner loop**:  * Delete the identified analysis.  * Parse the response for the value of `confirm_delete_url` and, if found, use this in the next iteration.The above process assumes that you want to remove all trace of the tool&apos;s analyses from the GitHub user interface, for the specified repository, and it therefore uses the `confirm_delete_url` value. Alternatively, you could use the `next_analysis_url` value, which would leave the last analysis in each set undeleted to avoid removing a tool&apos;s analysis entirely.OAuth app tokens and personal access tokens (classic) need the `repo` scope to use this endpoint with private or public repositories, or the `public_repo` scope to use this endpoint with only public repositories.
        /// </summary>
        public class WithAnalysis_ItemRequestBuilderDeleteQueryParameters 
        {
            /// <summary>Allow deletion if the specified analysis is the last in a set. If you attempt to delete the final analysis in a set without setting this parameter to `true`, you&apos;ll get a 400 response with the message: `Analysis is last of its type and deletion may result in the loss of historical alert data. Please specify confirm_delete.`</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("confirm_delete")]
            public string? ConfirmDelete { get; set; }
#nullable restore
#else
            [QueryParameter("confirm_delete")]
            public string ConfirmDelete { get; set; }
#endif
        }
    }
}
