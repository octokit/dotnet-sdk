// <auto-generated/>
#pragma warning disable CS0618
using GitHub.Models;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace GitHub.Projects.Columns.Item.Cards
{
    /// <summary>
    /// Builds and executes requests for operations under \projects\columns\{column_id}\cards
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.19.0")]
    public partial class CardsRequestBuilder : BaseRequestBuilder
    {
        /// <summary>
        /// Instantiates a new <see cref="global::GitHub.Projects.Columns.Item.Cards.CardsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public CardsRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/projects/columns/{column_id}/cards{?archived_state*,page*,per_page*}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::GitHub.Projects.Columns.Item.Cards.CardsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public CardsRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/projects/columns/{column_id}/cards{?archived_state*,page*,per_page*}", rawUrl)
        {
        }
        /// <summary>
        /// Lists the project cards in a project.
        /// API method documentation <see href="https://docs.github.com/rest/projects/cards#list-project-cards" />
        /// </summary>
        /// <returns>A List&lt;global::GitHub.Models.ProjectCard&gt;</returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::GitHub.Models.BasicError">When receiving a 401 status code</exception>
        /// <exception cref="global::GitHub.Models.BasicError">When receiving a 403 status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<List<global::GitHub.Models.ProjectCard>?> GetAsync(Action<RequestConfiguration<global::GitHub.Projects.Columns.Item.Cards.CardsRequestBuilder.CardsRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<List<global::GitHub.Models.ProjectCard>> GetAsync(Action<RequestConfiguration<global::GitHub.Projects.Columns.Item.Cards.CardsRequestBuilder.CardsRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "401", global::GitHub.Models.BasicError.CreateFromDiscriminatorValue },
                { "403", global::GitHub.Models.BasicError.CreateFromDiscriminatorValue },
            };
            var collectionResult = await RequestAdapter.SendCollectionAsync<global::GitHub.Models.ProjectCard>(requestInfo, global::GitHub.Models.ProjectCard.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
            return collectionResult?.AsList();
        }
        /// <summary>
        /// Create a project card
        /// API method documentation <see href="https://docs.github.com/rest/projects/cards#create-a-project-card" />
        /// </summary>
        /// <returns>A <see cref="global::GitHub.Models.ProjectCard"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::GitHub.Models.BasicError">When receiving a 401 status code</exception>
        /// <exception cref="global::GitHub.Models.BasicError">When receiving a 403 status code</exception>
        /// <exception cref="global::GitHub.Projects.Columns.Item.Cards.ProjectCard503Error">When receiving a 503 status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::GitHub.Models.ProjectCard?> PostAsync(global::GitHub.Projects.Columns.Item.Cards.CardsRequestBuilder.CardsPostRequestBody body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::GitHub.Models.ProjectCard> PostAsync(global::GitHub.Projects.Columns.Item.Cards.CardsRequestBuilder.CardsPostRequestBody body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = ToPostRequestInformation(body, requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "401", global::GitHub.Models.BasicError.CreateFromDiscriminatorValue },
                { "403", global::GitHub.Models.BasicError.CreateFromDiscriminatorValue },
                { "503", global::GitHub.Projects.Columns.Item.Cards.ProjectCard503Error.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<global::GitHub.Models.ProjectCard>(requestInfo, global::GitHub.Models.ProjectCard.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Lists the project cards in a project.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::GitHub.Projects.Columns.Item.Cards.CardsRequestBuilder.CardsRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::GitHub.Projects.Columns.Item.Cards.CardsRequestBuilder.CardsRequestBuilderGetQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.GET, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPostRequestInformation(global::GitHub.Projects.Columns.Item.Cards.CardsRequestBuilder.CardsPostRequestBody body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToPostRequestInformation(global::GitHub.Projects.Columns.Item.Cards.CardsRequestBuilder.CardsPostRequestBody body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation(Method.POST, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            return requestInfo;
        }
        /// <summary>
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <returns>A <see cref="global::GitHub.Projects.Columns.Item.Cards.CardsRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::GitHub.Projects.Columns.Item.Cards.CardsRequestBuilder WithUrl(string rawUrl)
        {
            return new global::GitHub.Projects.Columns.Item.Cards.CardsRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Composed type wrapper for classes <see cref="global::GitHub.Projects.Columns.Item.Cards.CardsPostRequestBodyMember1"/>, <see cref="global::GitHub.Projects.Columns.Item.Cards.CardsPostRequestBodyMember2"/>
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.19.0")]
        public partial class CardsPostRequestBody : IComposedTypeWrapper, IParsable
        {
            /// <summary>Composed type representation for type <see cref="global::GitHub.Projects.Columns.Item.Cards.CardsPostRequestBodyMember1"/></summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public global::GitHub.Projects.Columns.Item.Cards.CardsPostRequestBodyMember1? CardsPostRequestBodyCardsPostRequestBodyMember1 { get; set; }
#nullable restore
#else
            public global::GitHub.Projects.Columns.Item.Cards.CardsPostRequestBodyMember1 CardsPostRequestBodyCardsPostRequestBodyMember1 { get; set; }
#endif
            /// <summary>Composed type representation for type <see cref="global::GitHub.Projects.Columns.Item.Cards.CardsPostRequestBodyMember2"/></summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public global::GitHub.Projects.Columns.Item.Cards.CardsPostRequestBodyMember2? CardsPostRequestBodyCardsPostRequestBodyMember2 { get; set; }
#nullable restore
#else
            public global::GitHub.Projects.Columns.Item.Cards.CardsPostRequestBodyMember2 CardsPostRequestBodyCardsPostRequestBodyMember2 { get; set; }
#endif
            /// <summary>Composed type representation for type <see cref="global::GitHub.Projects.Columns.Item.Cards.CardsPostRequestBodyMember1"/></summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public global::GitHub.Projects.Columns.Item.Cards.CardsPostRequestBodyMember1? CardsPostRequestBodyMember1 { get; set; }
#nullable restore
#else
            public global::GitHub.Projects.Columns.Item.Cards.CardsPostRequestBodyMember1 CardsPostRequestBodyMember1 { get; set; }
#endif
            /// <summary>Composed type representation for type <see cref="global::GitHub.Projects.Columns.Item.Cards.CardsPostRequestBodyMember2"/></summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public global::GitHub.Projects.Columns.Item.Cards.CardsPostRequestBodyMember2? CardsPostRequestBodyMember2 { get; set; }
#nullable restore
#else
            public global::GitHub.Projects.Columns.Item.Cards.CardsPostRequestBodyMember2 CardsPostRequestBodyMember2 { get; set; }
#endif
            /// <summary>
            /// Creates a new instance of the appropriate class based on discriminator value
            /// </summary>
            /// <returns>A <see cref="global::GitHub.Projects.Columns.Item.Cards.CardsRequestBuilder.CardsPostRequestBody"/></returns>
            /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
            public static global::GitHub.Projects.Columns.Item.Cards.CardsRequestBuilder.CardsPostRequestBody CreateFromDiscriminatorValue(IParseNode parseNode)
            {
                _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
                var mappingValue = parseNode.GetChildNode("")?.GetStringValue();
                var result = new global::GitHub.Projects.Columns.Item.Cards.CardsRequestBuilder.CardsPostRequestBody();
                if("".Equals(mappingValue, StringComparison.OrdinalIgnoreCase))
                {
                    result.CardsPostRequestBodyCardsPostRequestBodyMember1 = new global::GitHub.Projects.Columns.Item.Cards.CardsPostRequestBodyMember1();
                }
                else if("".Equals(mappingValue, StringComparison.OrdinalIgnoreCase))
                {
                    result.CardsPostRequestBodyCardsPostRequestBodyMember2 = new global::GitHub.Projects.Columns.Item.Cards.CardsPostRequestBodyMember2();
                }
                else if("".Equals(mappingValue, StringComparison.OrdinalIgnoreCase))
                {
                    result.CardsPostRequestBodyMember1 = new global::GitHub.Projects.Columns.Item.Cards.CardsPostRequestBodyMember1();
                }
                else if("".Equals(mappingValue, StringComparison.OrdinalIgnoreCase))
                {
                    result.CardsPostRequestBodyMember2 = new global::GitHub.Projects.Columns.Item.Cards.CardsPostRequestBodyMember2();
                }
                return result;
            }
            /// <summary>
            /// The deserialization information for the current model
            /// </summary>
            /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
            public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
            {
                if(CardsPostRequestBodyCardsPostRequestBodyMember1 != null)
                {
                    return CardsPostRequestBodyCardsPostRequestBodyMember1.GetFieldDeserializers();
                }
                else if(CardsPostRequestBodyCardsPostRequestBodyMember2 != null)
                {
                    return CardsPostRequestBodyCardsPostRequestBodyMember2.GetFieldDeserializers();
                }
                else if(CardsPostRequestBodyMember1 != null)
                {
                    return CardsPostRequestBodyMember1.GetFieldDeserializers();
                }
                else if(CardsPostRequestBodyMember2 != null)
                {
                    return CardsPostRequestBodyMember2.GetFieldDeserializers();
                }
                return new Dictionary<string, Action<IParseNode>>();
            }
            /// <summary>
            /// Serializes information the current object
            /// </summary>
            /// <param name="writer">Serialization writer to use to serialize this model</param>
            public virtual void Serialize(ISerializationWriter writer)
            {
                _ = writer ?? throw new ArgumentNullException(nameof(writer));
                if(CardsPostRequestBodyCardsPostRequestBodyMember1 != null)
                {
                    writer.WriteObjectValue<global::GitHub.Projects.Columns.Item.Cards.CardsPostRequestBodyMember1>(null, CardsPostRequestBodyCardsPostRequestBodyMember1);
                }
                else if(CardsPostRequestBodyCardsPostRequestBodyMember2 != null)
                {
                    writer.WriteObjectValue<global::GitHub.Projects.Columns.Item.Cards.CardsPostRequestBodyMember2>(null, CardsPostRequestBodyCardsPostRequestBodyMember2);
                }
                else if(CardsPostRequestBodyMember1 != null)
                {
                    writer.WriteObjectValue<global::GitHub.Projects.Columns.Item.Cards.CardsPostRequestBodyMember1>(null, CardsPostRequestBodyMember1);
                }
                else if(CardsPostRequestBodyMember2 != null)
                {
                    writer.WriteObjectValue<global::GitHub.Projects.Columns.Item.Cards.CardsPostRequestBodyMember2>(null, CardsPostRequestBodyMember2);
                }
            }
        }
        /// <summary>
        /// Lists the project cards in a project.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.19.0")]
        public partial class CardsRequestBuilderGetQueryParameters 
        {
            /// <summary>Filters the project cards that are returned by the card&apos;s state.</summary>
            [QueryParameter("archived_state")]
            public global::GitHub.Projects.Columns.Item.Cards.GetArchived_stateQueryParameterType? ArchivedState { get; set; }
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
