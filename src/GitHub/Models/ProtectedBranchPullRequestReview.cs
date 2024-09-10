// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace GitHub.Models
{
    /// <summary>
    /// Protected Branch Pull Request Review
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.18.0")]
    public partial class ProtectedBranchPullRequestReview : IAdditionalDataHolder, IParsable
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Allow specific users, teams, or apps to bypass pull request requirements.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::GitHub.Models.ProtectedBranchPullRequestReview_bypass_pull_request_allowances? BypassPullRequestAllowances { get; set; }
#nullable restore
#else
        public global::GitHub.Models.ProtectedBranchPullRequestReview_bypass_pull_request_allowances BypassPullRequestAllowances { get; set; }
#endif
        /// <summary>The dismissal_restrictions property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::GitHub.Models.ProtectedBranchPullRequestReview_dismissal_restrictions? DismissalRestrictions { get; set; }
#nullable restore
#else
        public global::GitHub.Models.ProtectedBranchPullRequestReview_dismissal_restrictions DismissalRestrictions { get; set; }
#endif
        /// <summary>The dismiss_stale_reviews property</summary>
        public bool? DismissStaleReviews { get; set; }
        /// <summary>The require_code_owner_reviews property</summary>
        public bool? RequireCodeOwnerReviews { get; set; }
        /// <summary>The required_approving_review_count property</summary>
        public int? RequiredApprovingReviewCount { get; set; }
        /// <summary>Whether the most recent push must be approved by someone other than the person who pushed it.</summary>
        public bool? RequireLastPushApproval { get; set; }
        /// <summary>The url property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Url { get; set; }
#nullable restore
#else
        public string Url { get; set; }
#endif
        /// <summary>
        /// Instantiates a new <see cref="global::GitHub.Models.ProtectedBranchPullRequestReview"/> and sets the default values.
        /// </summary>
        public ProtectedBranchPullRequestReview()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::GitHub.Models.ProtectedBranchPullRequestReview"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::GitHub.Models.ProtectedBranchPullRequestReview CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::GitHub.Models.ProtectedBranchPullRequestReview();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "bypass_pull_request_allowances", n => { BypassPullRequestAllowances = n.GetObjectValue<global::GitHub.Models.ProtectedBranchPullRequestReview_bypass_pull_request_allowances>(global::GitHub.Models.ProtectedBranchPullRequestReview_bypass_pull_request_allowances.CreateFromDiscriminatorValue); } },
                { "dismiss_stale_reviews", n => { DismissStaleReviews = n.GetBoolValue(); } },
                { "dismissal_restrictions", n => { DismissalRestrictions = n.GetObjectValue<global::GitHub.Models.ProtectedBranchPullRequestReview_dismissal_restrictions>(global::GitHub.Models.ProtectedBranchPullRequestReview_dismissal_restrictions.CreateFromDiscriminatorValue); } },
                { "require_code_owner_reviews", n => { RequireCodeOwnerReviews = n.GetBoolValue(); } },
                { "require_last_push_approval", n => { RequireLastPushApproval = n.GetBoolValue(); } },
                { "required_approving_review_count", n => { RequiredApprovingReviewCount = n.GetIntValue(); } },
                { "url", n => { Url = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<global::GitHub.Models.ProtectedBranchPullRequestReview_bypass_pull_request_allowances>("bypass_pull_request_allowances", BypassPullRequestAllowances);
            writer.WriteObjectValue<global::GitHub.Models.ProtectedBranchPullRequestReview_dismissal_restrictions>("dismissal_restrictions", DismissalRestrictions);
            writer.WriteBoolValue("dismiss_stale_reviews", DismissStaleReviews);
            writer.WriteBoolValue("require_code_owner_reviews", RequireCodeOwnerReviews);
            writer.WriteIntValue("required_approving_review_count", RequiredApprovingReviewCount);
            writer.WriteBoolValue("require_last_push_approval", RequireLastPushApproval);
            writer.WriteStringValue("url", Url);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
#pragma warning restore CS0618
