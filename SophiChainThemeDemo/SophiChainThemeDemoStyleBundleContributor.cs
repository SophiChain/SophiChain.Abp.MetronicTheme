using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace SophiChainThemeDemo;

public class SophiChainThemeDemoStyleBundleContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.Add(new BundleFile("main.css", true));
    }
}
