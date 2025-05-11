using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace SophiChain.Abp.AspNetCore.Components.Server.MetronicTheme.Bundling;

public class BlazorMetronicThemeStyleContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.AddIfNotContains("/_content/SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme/libs/abp/css/theme.css");
    }
}
