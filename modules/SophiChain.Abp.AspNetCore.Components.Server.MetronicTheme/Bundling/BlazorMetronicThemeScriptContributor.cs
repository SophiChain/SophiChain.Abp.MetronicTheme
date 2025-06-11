using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace SophiChain.Abp.AspNetCore.Components.Server.MetronicTheme.Bundling;

public class BlazorMetronicThemeScriptContributor : BundleContributor
{
    private const string RootPath = "/_content/SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme";

    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        //MUD & TELERIK TO BE REMOVED LATER IF NEEDED
        context.Files.AddIfNotContains($"_content/Telerik.UI.for.Blazor/js/telerik-blazor.js");
        context.Files.AddIfNotContains($"_content/MudBlazor/MudBlazor.min.js");
        context.Files.AddIfNotContains($"{RootPath}/assets/plugins/global/plugins.bundle.js");
        context.Files.AddIfNotContains($"{RootPath}/assets/js/widgets.bundle.js");
        context.Files.AddIfNotContains($"{RootPath}/assets/js/scripts.bundle.js");
    }
}
