// <auto-generated/>
using GitHub.Repos.Item.Item.Stats.Code_frequency;
using GitHub.Repos.Item.Item.Stats.Commit_activity;
using GitHub.Repos.Item.Item.Stats.Contributors;
using GitHub.Repos.Item.Item.Stats.Participation;
using GitHub.Repos.Item.Item.Stats.Punch_card;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
namespace GitHub.Repos.Item.Item.Stats {
    /// <summary>
    /// Builds and executes requests for operations under \repos\{owner-id}\{repo-id}\stats
    /// </summary>
    public class StatsRequestBuilder : BaseRequestBuilder {
        /// <summary>The code_frequency property</summary>
        public Code_frequencyRequestBuilder Code_frequency { get =>
            new Code_frequencyRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The commit_activity property</summary>
        public Commit_activityRequestBuilder Commit_activity { get =>
            new Commit_activityRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The contributors property</summary>
        public ContributorsRequestBuilder Contributors { get =>
            new ContributorsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The participation property</summary>
        public ParticipationRequestBuilder Participation { get =>
            new ParticipationRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The punch_card property</summary>
        public Punch_cardRequestBuilder Punch_card { get =>
            new Punch_cardRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="StatsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public StatsRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/repos/{owner%2Did}/{repo%2Did}/stats", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new <see cref="StatsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public StatsRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/repos/{owner%2Did}/{repo%2Did}/stats", rawUrl) {
        }
    }
}
