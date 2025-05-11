using System;
using Volo.Abp.Bundling;

namespace SophiChain.Abp.AspNetCore.Components.WebAssembly.MetronicTheme;

[Obsolete("This class is obsolete and will be removed in the future versions. Use GlobalAssets instead.")]
public class MetronicThemeBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("_content/SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme/libs/abp/css/theme.css");
    }
}
