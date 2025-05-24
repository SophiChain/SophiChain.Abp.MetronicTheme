using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Themes.Metronic.libs;
using Volo.Abp.AspNetCore.Components.Web.Theming;
using Volo.Abp.AspNetCore.Components.Web.Theming.Layout;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.AspNetCore.Components.Web.Theming.Theming;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme;

[DependsOn(
    typeof(AbpAspNetCoreComponentsWebThemingModule),
    typeof(AbpVirtualFileSystemModule),
    typeof(AbpAutoMapperModule)
)]
public class SophiChainAspNetCoreComponentsWebMetronicThemeModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<SophiChainAspNetCoreComponentsWebMetronicThemeModule>();

        ConfigurePageHeaderOptions();
        ConfigureRouterOptions();
        ConfigureSophiChainTheme();

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<SophiChainAspNetCoreComponentsWebMetronicThemeModule>();
        });


        // Register IKTTheme service
        context.Services.AddSingleton<IKTTheme, KTTheme>();

        IConfiguration themeConfiguration = new ConfigurationBuilder()
            .AddJsonFile($"themesettings.json")
            .Build();

        IConfiguration iconsConfiguration = new ConfigurationBuilder()
            .AddJsonFile($"icons.json")
            .Build();

        KTThemeSettings.init(themeConfiguration);
        KTIconsSettings.init(iconsConfiguration);
    }

    private void ConfigurePageHeaderOptions()
    {
        Configure<PageHeaderOptions>(options =>
        {
            options.RenderPageTitle = false;
            options.RenderBreadcrumbs = false;
            options.RenderToolbar = false;
        });
    }

    private void ConfigureRouterOptions()
    {
        Configure<AbpRouterOptions>(options =>
        {
            options.AdditionalAssemblies.Add(typeof(SophiChainAspNetCoreComponentsWebMetronicThemeModule).Assembly);
        });
    }

    private void ConfigureSophiChainTheme()
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