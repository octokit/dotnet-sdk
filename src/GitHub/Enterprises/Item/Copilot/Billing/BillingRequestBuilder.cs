// <auto-generated/>
using GitHub.Enterprises.Item.Copilot.Billing.Seats;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
namespace GitHub.Enterprises.Item.Copilot.Billing {
    /// <summary>
    /// Builds and executes requests for operations under \enterprises\{enterprise}\copilot\billing
    /// </summary>
    public class BillingRequestBuilder : BaseRequestBuilder 
    {
        /// <summary>The seats property</summary>
        public SeatsRequestBuilder Seats
        {
            get => new SeatsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="BillingRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public BillingRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/enterprises/{enterprise}/copilot/billing", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="BillingRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public BillingRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/enterprises/{enterprise}/copilot/billing", rawUrl)
        {
        }
    }
}