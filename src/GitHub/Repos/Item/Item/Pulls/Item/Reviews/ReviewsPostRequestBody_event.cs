// <auto-generated/>
using System.Runtime.Serialization;
using System;
namespace GitHub.Repos.Item.Item.Pulls.Item.Reviews
{
    /// <summary>The review action you want to perform. The review actions include: `APPROVE`, `REQUEST_CHANGES`, or `COMMENT`. By leaving this blank, you set the review action state to `PENDING`, which means you will need to [submit the pull request review](https://docs.github.com/rest/pulls/reviews#submit-a-review-for-a-pull-request) when you are ready.</summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.17.0")]
    public enum ReviewsPostRequestBody_event
    {
        [EnumMember(Value = "APPROVE")]
        #pragma warning disable CS1591
        APPROVE,
        #pragma warning restore CS1591
        [EnumMember(Value = "REQUEST_CHANGES")]
        #pragma warning disable CS1591
        REQUEST_CHANGES,
        #pragma warning restore CS1591
        [EnumMember(Value = "COMMENT")]
        #pragma warning disable CS1591
        COMMENT,
        #pragma warning restore CS1591
    }
}
