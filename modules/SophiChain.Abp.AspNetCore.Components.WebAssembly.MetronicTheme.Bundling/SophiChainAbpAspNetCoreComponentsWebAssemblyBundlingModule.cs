using Volo.Abp.AspNetCore.Components.WebAssembly.Theming.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.Modularity;

namespace SophiChain.Abp.AspNetCore.Components.WebAssembly.MetronicTheme.Bundling;

[DependsOn(
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingBundlingModule)
)]
public class SophiChainAbpAspNetCoreComponentsWebAssemblyBundlingModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBundlingOptions>(options =>
        {
            // Configure global styles
            options.StyleBundles.Configure(
                BlazorWebAssemblyStandardBundles.Styles.Global,
                bundle =>
                {
                    bundle.AddContributors(typeof(MetronicThemeBundleStyleContributor));
                }
            );

            // Configure global scripts
            options.ScriptBundles.Configure(
                BlazorWebAssemblyStandardBundles.Scripts.Global,
                bundle =>
                {
                    bundle.AddContributors(typeof(MetronicThemeBundleScriptContributor));
                }
            );
        });
    }
}
