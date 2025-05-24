using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.Localization;

namespace SophiChain.Abp.AspNetCore.Components.WebAssembly.MetronicTheme.Bundling;

public class MetronicThemeBundleStyleContributor : BundleContributor
{
    private const string RootPath = "/_content/SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme";

    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        //context.Files.AddIfNotContains("_content/SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme/libs/abp/css/theme.css");

        var rtl = CultureHelper.IsRtl ? ".rtl" : string.Empty;

        context.Files.AddIfNotContains($"{RootPath}/assets/plugins/global/plugins.bundle.rtl.css");
        context.Files.AddIfNotContains($"{RootPath}/assets/css/fonts.css");
        context.Files.AddIfNotContains($"{RootPath}/assets/css/style.bundle.rtl.css");
        context.Files.AddIfNotContains($"{RootPath}/assets/css/telerik-override.css");
        context.Files.AddIfNotContains($"{RootPath}/assets/css/metronic-override.css");
        context.Files.AddIfNotContains($"{RootPath}/assets/css/sc-styles.css");
    }
}
