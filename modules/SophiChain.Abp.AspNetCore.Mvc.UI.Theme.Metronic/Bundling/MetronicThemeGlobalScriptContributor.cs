using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace SophiChain.Abp.AspNetCore.Mvc.UI.Theme.Metronic.Bundling;

public class MetronicThemeGlobalScriptContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.Add("/themes/basic/layout.js");
    }
}
