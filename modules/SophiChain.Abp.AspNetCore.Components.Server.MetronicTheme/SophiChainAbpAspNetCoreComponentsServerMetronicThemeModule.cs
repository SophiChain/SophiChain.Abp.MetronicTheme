using SophiChain.Abp.AspNetCore.Components.Server.MetronicTheme.Bundling;
using SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme;
using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.AspNetCore.Components.Server.Theming.Bundling;
using Volo.Abp.AspNetCore.Components.Web.Theming.Toolbars;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.Modularity;

namespace SophiChain.Abp.AspNetCore.Components.Server.MetronicTheme;

[DependsOn(
    typeof(SophiChainAspNetCoreComponentsWebMetronicThemeModule),
    typeof(AbpAspNetCoreComponentsServerThemingModule)
    )]
public class SophiChainAbpAspNetCoreComponentsServerMetronicThemeModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpToolbarOptions>(options =>
        {
            options.Contributors.Add(new MetronicThemeToolbarContributor());
        });

        Configure<AbpBundlingOptions>(options =>
        {
            options
                .StyleBundles
                .Add(BlazorMetronicThemeBundles.Styles.Global, bundle =>
                {
                    bundle
                        .AddBaseBundles(BlazorStandardBundles.Styles.Global)
                        .AddContributors(typeof(BlazorMetronicThemeStyleContributor));
                });

            options
                .ScriptBundles
                .Add(BlazorMetronicThemeBundles.Scripts.Global, bundle =>
                {
                    bundle
                        .AddBaseBundles(BlazorStandardBundles.Scripts.Global)
                        .AddContributors(typeof(BlazorMetronicThemeScriptContributor));
                });
        });
    }
}
