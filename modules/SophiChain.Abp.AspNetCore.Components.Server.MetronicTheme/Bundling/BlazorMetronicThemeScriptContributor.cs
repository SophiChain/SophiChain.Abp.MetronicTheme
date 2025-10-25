using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace SophiChain.Abp.AspNetCore.Components.Server.MetronicTheme.Bundling;

public class BlazorMetronicThemeScriptContributor : BundleContributor
{
    private const string RootPath = "/_content/SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme";

    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.AddIfNotContains($"{RootPath}/assets/plugins/global/plugins.bundle.min.js");
        context.Files.AddIfNotContains($"{RootPath}/assets/js/widgets.bundle.min.js");
        context.Files.AddIfNotContains($"{RootPath}/assets/js/scripts.bundle.min.js");
    }
}
