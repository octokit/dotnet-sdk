// <auto-generated/>
using GitHub.Users.Item.Attestations.Item;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
namespace GitHub.Users.Item.Attestations
{
    /// <summary>
    /// Builds and executes requests for operations under \users\{username}\attestations
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.17.0")]
    public partial class AttestationsRequestBuilder : BaseRequestBuilder
    {
        /// <summary>Gets an item from the GitHub.users.item.attestations.item collection</summary>
        /// <param name="position">Subject Digest</param>
        /// <returns>A <see cref="global::GitHub.Users.Item.Attestations.Item.WithSubject_digestItemRequestBuilder"/></returns>
        public global::GitHub.Users.Item.Attestations.Item.WithSubject_digestItemRequestBuilder this[string position]
        {
            get
            {
                var urlTplParams = new Dictionary<string, object>(PathParameters);
                urlTplParams.Add("subject_digest", position);
                return new global::GitHub.Users.Item.Attestations.Item.WithSubject_digestItemRequestBuilder(urlTplParams, RequestAdapter);
            }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::GitHub.Users.Item.Attestations.AttestationsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public AttestationsRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/users/{username}/attestations", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::GitHub.Users.Item.Attestations.AttestationsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public AttestationsRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/users/{username}/attestations", rawUrl)
        {
        }
    }
}
