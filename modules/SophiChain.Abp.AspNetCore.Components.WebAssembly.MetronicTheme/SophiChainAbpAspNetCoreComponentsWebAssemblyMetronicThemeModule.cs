using Microsoft.Extensions.DependencyInjection;
using SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme;
using SophiChain.Abp.AspNetCore.Components.WebAssembly.MetronicTheme.Bundling;
using Volo.Abp;
using Volo.Abp.AspNetCore.Components.Web;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.AspNetCore.Components.Web.Theming.Toolbars;
using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Http.Client.IdentityModel.WebAssembly;
using Volo.Abp.Modularity;

namespace SophiChain.Abp.AspNetCore.Components.WebAssembly.MetronicTheme;

[DependsOn(
    typeof(SophiChainAbpAspNetCoreComponentsWebAssemblyBundlingModule),
    typeof(SophiChainAspNetCoreComponentsWebMetronicThemeModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule),
    typeof(AbpHttpClientIdentityModelWebAssemblyModule)
    )]
public class SophiChainAbpAspNetCoreComponentsWebAssemblyMetronicThemeModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpRouterOptions>(options =>
        {
            options.AdditionalAssemblies.Add(typeof(SophiChainAbpAspNetCoreComponentsWebAssemblyMetronicThemeModule).Assembly);
        });

        Configure<AbpToolbarOptions>(options =>
        {
            options.Contributors.Add(new MetronicThemeToolbarContributor());
        });

        if (context.Services.ExecutePreConfiguredActions<AbpAspNetCoreComponentsWebOptions>().IsBlazorWebApp)
        {
            Configure<AuthenticationOptions>(options =>
            {
                options.LoginUrl = "Account/Login";
                options.LogoutUrl = "Account/Logout";
            });
        }
    }
}
