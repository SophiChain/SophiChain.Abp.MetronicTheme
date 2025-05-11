using System.IO;
using Volo.Abp.VirtualFileSystem;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Volo.Abp.AspNetCore.Components.Web;
using SophiChainThemeDemo.Menus;
using Volo.Abp.Account;
using SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Themes.Metronic;
using Volo.Abp.AspNetCore.Components.WebAssembly.MetronicTheme;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.OpenIddict;
using Volo.Abp.Identity.Blazor.WebAssembly;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.Blazor.WebAssembly;
using Volo.Abp.Autofac.WebAssembly;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.FeatureManagement.Blazor.WebAssembly;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.Blazor.WebAssembly;
using Volo.Abp.SettingManagement.Blazor.WebAssembly;
using Volo.Abp.SettingManagement;
using Volo.Abp.UI.Navigation;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Components.WebAssembly.Theming.Bundling;
using SophiChain.Abp.AspNetCore.Components.WebAssembly.MetronicTheme;
using Volo.Abp.Ui.LayoutHooks;
using SophiChainThemeDemo.Wrapper;

namespace SophiChainThemeDemo;

[DependsOn(
    typeof(SophiChainThemeDemoContractsModule),
        
    // ABP Framework packages
    typeof(AbpAutofacWebAssemblyModule),

    // Theme
    typeof(SophiChainAbpAspNetCoreComponentsWebAssemblyMetronicThemeModule),

    // Account module packages
    typeof(AbpAccountHttpApiClientModule),

    // OpenIddict module packages
    typeof(AbpOpenIddictDomainSharedModule),

    // Identity module packages
    typeof(AbpIdentityBlazorWebAssemblyModule),
    typeof(AbpIdentityHttpApiClientModule),

    // Language Management module packages
    typeof(AbpTenantManagementBlazorWebAssemblyModule),
    typeof(AbpTenantManagementHttpApiClientModule),

    // Permission Management module packages
    typeof(AbpPermissionManagementBlazorWebAssemblyModule),
    typeof(AbpPermissionManagementHttpApiClientModule),

    // Feature Management module packages
    typeof(AbpFeatureManagementBlazorWebAssemblyModule),
    typeof(AbpFeatureManagementHttpApiClientModule),

    // Setting Management module packages
    typeof(AbpSettingManagementHttpApiClientModule),
    typeof(AbpSettingManagementBlazorWebAssemblyModule)
)]
public class SophiChainThemeDemoClientModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<AbpAspNetCoreComponentsWebOptions>(options =>
        {
            options.IsBlazorWebApp = true;
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var environment = context.Services.GetSingletonInstance<IWebAssemblyHostEnvironment>();
        var builder = context.Services.GetSingletonInstance<WebAssemblyHostBuilder>();

        ConfigureAuthentication(builder);
        ConfigureHttpClient(context, environment);
        ConfigureBlazorise(context);
        ConfigureRouter(context);
        ConfigureMenu(context);
        ConfigureAutoMapper(context);
        ConfigureTelerik();

        context.Services.AddHttpClientProxies(typeof(SophiChainThemeDemoContractsModule).Assembly);
    }
    private void ConfigureTelerik()
    {
        Configure<AbpLayoutHookOptions>(options =>
        {
            options.Add(LayoutHooks.Body.First, typeof(StartWrapper));
            options.Add(LayoutHooks.Body.Last, typeof(EndWrapper));
        });
    }
    private void ConfigureRouter(ServiceConfigurationContext context)
    {
        Configure<AbpRouterOptions>(options =>
        {
            options.AppAssembly = typeof(SophiChainThemeDemoClientModule).Assembly;
        });
    }

    private void ConfigureMenu(ServiceConfigurationContext context)
    {
        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new SophiChainThemeDemoMenuContributor(context.Services.GetConfiguration()));
        });
    }

    private void ConfigureBlazorise(ServiceConfigurationContext context)
    {
        context.Services
            .AddBootstrap5Providers()
            .AddFontAwesomeIcons();
    }

    private static void ConfigureAuthentication(WebAssemblyHostBuilder builder)
    {
        builder.Services.AddBlazorWebAppServices();
    }

    private static void ConfigureHttpClient(ServiceConfigurationContext context, IWebAssemblyHostEnvironment environment)
    {
        context.Services.AddTransient(sp => new HttpClient
        {
            BaseAddress = new Uri(environment.BaseAddress)
        });
    }

    private void ConfigureAutoMapper(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<SophiChainThemeDemoClientModule>();
        });
    }
}
