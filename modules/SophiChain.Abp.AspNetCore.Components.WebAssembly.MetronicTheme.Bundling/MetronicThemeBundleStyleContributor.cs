using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace SophiChain.Abp.AspNetCore.Components.WebAssembly.MetronicTheme.Bundling;

public class MetronicThemeBundleStyleContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.AddIfNotContains("_content/SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme/libs/abp/css/theme.css");
    }
}
