using Volo.Abp.AspNetCore.Components.Web.Theming;
using Volo.Abp.AspNetCore.Components.Web.Theming.Theming;
using Volo.Abp.Modularity;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme;

[DependsOn(
    typeof(AbpAspNetCoreComponentsWebThemingModule)
)]
public class SophiChainAspNetCoreComponentsWebMetronicThemeModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpThemingOptions>(options =>
        {
            options.Themes.Add<MetronicTheme>();

            if (options.DefaultThemeName == null)
            {
                options.DefaultThemeName = MetronicTheme.Name;
            }
        });
    }
}