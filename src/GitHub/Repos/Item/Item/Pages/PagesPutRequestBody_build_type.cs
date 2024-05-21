// <auto-generated/>
using System.Runtime.Serialization;
using System;
namespace GitHub.Repos.Item.Item.Pages
{
    /// <summary>The process by which the GitHub Pages site will be built. `workflow` means that the site is built by a custom GitHub Actions workflow. `legacy` means that the site is built by GitHub when changes are pushed to a specific branch.</summary>
    public enum PagesPutRequestBody_build_type
    {
        [EnumMember(Value = "legacy")]
        #pragma warning disable CS1591
        Legacy,
        #pragma warning restore CS1591
        [EnumMember(Value = "workflow")]
        #pragma warning disable CS1591
        Workflow,
        #pragma warning restore CS1591
    }
}
