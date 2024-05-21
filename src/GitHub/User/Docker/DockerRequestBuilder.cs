// <auto-generated/>
using GitHub.User.Docker.Conflicts;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
namespace GitHub.User.Docker
{
    /// <summary>
    /// Builds and executes requests for operations under \user\docker
    /// </summary>
    public class DockerRequestBuilder : BaseRequestBuilder
    {
        /// <summary>The conflicts property</summary>
        public ConflictsRequestBuilder Conflicts
        {
            get => new ConflictsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="DockerRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public DockerRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/user/docker", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="DockerRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public DockerRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/user/docker", rawUrl)
        {
        }
    }
}
