// <auto-generated/>
using System.Runtime.Serialization;
using System;
namespace GitHub.Repos.Item.Item {
    /// <summary>The default value for a squash merge commit message:- `PR_BODY` - default to the pull request&apos;s body.- `COMMIT_MESSAGES` - default to the branch&apos;s commit messages.- `BLANK` - default to a blank commit message.</summary>
    public enum RepoPatchRequestBody_squash_merge_commit_message
    {
        [EnumMember(Value = "PR_BODY")]
        PR_BODY,
        [EnumMember(Value = "COMMIT_MESSAGES")]
        COMMIT_MESSAGES,
        [EnumMember(Value = "BLANK")]
        BLANK,
    }
}
