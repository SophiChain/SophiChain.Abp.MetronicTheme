using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.Localization;

namespace SophiChain.Abp.AspNetCore.Components.Server.MetronicTheme.Bundling;

public class BlazorMetronicThemeStyleContributor : BundleContributor
{
    private const string RootPath = "/_content/SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme";

    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        var rtl = CultureHelper.IsRtl ? ".rtl" : string.Empty;

        //context.Files.AddIfNotContains("/_content/SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme/libs/abp/css/theme.css");

        context.Files.AddIfNotContains($"{RootPath}/assets/plugins/global/plugins.bundle.rtl.min.css");
        context.Files.AddIfNotContains($"{RootPath}/assets/css/fonts.min.css");
        context.Files.AddIfNotContains($"{RootPath}/assets/css/style.bundle.rtl.min.css");
        context.Files.AddIfNotContains($"{RootPath}/assets/css/metronic-override.min.css");
        context.Files.AddIfNotContains($"{RootPath}/assets/css/sc-styles.min.css");
    }
}
