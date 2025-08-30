using SophiChainThemeDemo.Localization;
using Volo.Abp.Account.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Identity.Blazor;
using Volo.Abp.TenantManagement.Blazor.Navigation;

namespace SophiChainThemeDemo.Menus;

public class SophiChainThemeDemoMenuContributor : IMenuContributor
{
    private readonly IConfiguration _configuration;

    public SophiChainThemeDemoMenuContributor(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
        else if (context.Menu.Name == StandardMenus.User)
        {
            await ConfigureUserMenuAsync(context);
        }
        if (context.Menu.Name == StandardMenus.Shortcut)
        {
            await ConfigureShortcutsMenu(context);
        }

        if (context.Menu.Name == SharedMenus.Timche.TimcheSideMenu)
        {
            await ConfigureTimcheMenu(context);
        }
        if (context.Menu.Name == SharedMenus.Settings.SettingsSideMenu)
        {
            await ConfigureSettingsMenu(context);
        }

        if (context.Menu.Name == "reports")
        {
            await ConfigureReportsMenu(context);
        }
    }

    private static async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<SophiChainThemeDemoResource>();

        context.Menu.AddItem(
            new ApplicationMenuItem(
                SophiChainThemeDemoMenus.Home,
                l["خانه"],
                "/",
                icon: "fas fa-home",
                order: 1,
                target: "forceLoad"
            )
        );

        context.Menu.AddItem(
            new ApplicationMenuItem(
                SophiChainThemeDemoMenus.Form,
                l["فرم"],
                "/form",
                icon: "fas fa-circle",
                order: 2
            )
        );

        context.Menu.AddItem(
            new ApplicationMenuItem(
                SophiChainThemeDemoMenus.Form,
                l["تست"],
                "/test",
                icon: "fas fa-circle",
                order: 3
            )
        );

        context.Menu.AddItem(
            new ApplicationMenuItem(
                SophiChainThemeDemoMenus.Telerik,
                l["کامپوننت های تلریک"],
                "/telerik-component",
                icon: "fas fa-circle",
                order: 4
            )
        );

        context.Menu.AddItem(
            new ApplicationMenuItem(
                SophiChainThemeDemoMenus.Auth,
                l["ورود"],
                "/signup",
                icon: "fas fa-circle",
                order: 5
            )
        );

        context.Menu.AddItem(
            new ApplicationMenuItem(
                SophiChainThemeDemoMenus.HomeChild1,
                displayName: l["تیمچه"],
                "/timche",
                icon: "fas fa-globe",
                order: 6
            )
            .AddItem(
                new ApplicationMenuItem(
                    SophiChainThemeDemoMenus.HomeChild3,
                    displayName: l["گزارش"],
                    "/report",
                    icon: "fas fa-globe"
                )
            )
            .AddItem(
                new ApplicationMenuItem(
                    SophiChainThemeDemoMenus.HomeChild2,
                    displayName: l["تیکت"],
                    "/ticket",
                    icon: "fas fa-globe"
                )
            )
        );

        context.Menu.AddItem(
            new ApplicationMenuItem(
                SophiChainThemeDemoMenus.HomeChild4,
                l["مدیریت خدمات"],
                icon: "fas fa-pen",
                order: 7
            )
            .AddItem(
                new ApplicationMenuItem(
                    SophiChainThemeDemoMenus.HomeChild5,
                    displayName: l["صفحه پنج"],
                    icon: "fas fa-globe"
                )
                .AddItem(
                    new ApplicationMenuItem(
                        SophiChainThemeDemoMenus.HomeChild6,
                        displayName: l["صفحه شش"],
                        "/services/pagefive/pagesix",
                        icon: "fas fa-globe",
                        target: "forceLoad"
                    )
                )
            )
        );

        /* Example nested menu definition:

        context.Menu.AddItem(
            new ApplicationMenuItem("Menu0", "Menu Level 0")
            .AddItem(new ApplicationMenuItem("Menu0.1", "Menu Level 0.1", url: "/test01"))
            .AddItem(
                new ApplicationMenuItem("Menu0.2", "Menu Level 0.2")
                    .AddItem(new ApplicationMenuItem("Menu0.2.1", "Menu Level 0.2.1", url: "/test021"))
                    .AddItem(new ApplicationMenuItem("Menu0.2.2", "Menu Level 0.2.2")
                        .AddItem(new ApplicationMenuItem("Menu0.2.2.1", "Menu Level 0.2.2.1", "/test0221"))
                        .AddItem(new ApplicationMenuItem("Menu0.2.2.2", "Menu Level 0.2.2.2", "/test0222"))
                    )
                    .AddItem(new ApplicationMenuItem("Menu0.2.3", "Menu Level 0.2.3", url: "/test023"))
                    .AddItem(new ApplicationMenuItem("Menu0.2.4", "Menu Level 0.2.4", url: "/test024")
                        .AddItem(new ApplicationMenuItem("Menu0.2.4.1", "Menu Level 0.2.4.1", "/test0241"))
                )
                .AddItem(new ApplicationMenuItem("Menu0.2.5", "Menu Level 0.2.5", url: "/test025"))
            )
            .AddItem(new ApplicationMenuItem("Menu0.2", "Menu Level 0.2", url: "/test02"))
        );

        */


        //Administration
        var administration = context.Menu.GetAdministration();
        administration.Order = 3;

        //Administration->Identity
        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 1);

        //Administration->Tenant Management
        administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 2);

        //Administration->Settings
        administration.SetSubItemOrder(SettingManagementMenus.GroupName, 7);
    }

    private async Task ConfigureUserMenuAsync(MenuConfigurationContext context)
    {
        if (OperatingSystem.IsBrowser())
        {
            //Blazor wasm menu items

            var authServerUrl = _configuration["AuthServer:Authority"] ?? "";
            var accountResource = context.GetLocalizer<AccountResource>();

            context.Menu.AddItem(new ApplicationMenuItem("Account.Manage", accountResource["MyAccount"], $"{authServerUrl.EnsureEndsWith('/')}Account/Manage", icon: "fa fa-cog", order: 900,  target: "_blank").RequireAuthenticated());

        }
        else
        {
            //Blazor server menu items

        }

        await Task.CompletedTask;
    }

    private async Task ConfigureTimcheMenu(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<SophiChainThemeDemoResource>();

        context.Menu.AddItem(
            new ApplicationMenuItem(
                SophiChainThemeDemoMenus.Home,
                l["Menu:Home"],
                "/",
                icon: "fas fa-home",
                order: 1
                //target: "forceLoad"
            )
            .AddItem(
                new ApplicationMenuItem(
                    SophiChainThemeDemoMenus.HomeChild1,
                    displayName: l["تیمچه"],
                    "/timche",
                    icon: "fas fa-pen",
                    target: "forceLoad"
                )
                .AddItem(
                    new ApplicationMenuItem(
                        SophiChainThemeDemoMenus.HomeChild3,
                        displayName: l["گزارش"],
                        "/report",
                        icon: "fas fa-globe",
                        target: "forceLoad"
                    )
                )
            )
            .AddItem(
                new ApplicationMenuItem(
                    SophiChainThemeDemoMenus.HomeChild2,
                    displayName: l["تیکت"],
                    "/ticket",
                    icon: "fas fa-globe",
                    target: "forceLoad"
                )
            )
        );

        context.Menu.AddItem(
            new ApplicationMenuItem(
                SophiChainThemeDemoMenus.HomeChild4,
                l["مدیریت خدمات"],
                "/next/test",
                icon: "fas fa-pen",
                order: 2,
                target: "forceLoad"
            )
        );

        await Task.CompletedTask;
    }

    private async Task ConfigureSettingsMenu(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<SophiChainThemeDemoResource>();

        context.Menu.AddItem(
            new ApplicationMenuItem(
                SophiChainThemeDemoMenus.HomeChild1,
                displayName: l["تیمچه"],
                "/timche",
                icon: "fas fa-pen",
                order: 1,
                target: "forceLoad"
            )
            .AddItem(
                new ApplicationMenuItem(
                    SophiChainThemeDemoMenus.HomeChild3,
                    displayName: l["گزارش"],
                    "/report",
                    target: "forceLoad"
                )
            )
            .AddItem(
                new ApplicationMenuItem(
                    SophiChainThemeDemoMenus.HomeChild2,
                    displayName: l["تیکت"],
                    "/ticket",
                    target: "forceLoad"
                )
            )
        );

        context.Menu.AddItem(
            new ApplicationMenuItem(
                SophiChainThemeDemoMenus.HomeChild4,
                l["مدیریت خدمات"],
                "/next/test",
                icon: "fas fa-pen",
                order: 2,
                target: "forceLoad"
            )
        );

        await Task.CompletedTask;
    }

    private async Task ConfigureShortcutsMenu(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<SophiChainThemeDemoResource>();

        context.Menu.AddItem(
            new ApplicationMenuItem(
                SophiChainThemeDemoMenus.HomeChild3,
                displayName: l["گزارش"],
                "/report",
                icon: "fas fa-pen",
                order: 2,
                target: "forceLoad"
            )
        );

        context.Menu.AddItem(
            new ApplicationMenuItem(
                SophiChainThemeDemoMenus.HomeChild2,
                displayName: l["تیکت"],
                "/ticket",
                icon: "fas fa-pen",
                target: "forceLoad"
            )
        );

        context.Menu.AddItem(
            new ApplicationMenuItem(
                SophiChainThemeDemoMenus.HomeChild4,
                l["مدیریت خدمات"],
                "/next/test",
                icon: "fas fa-pen",
                order: 2,
                target: "forceLoad"
            )
        );

        await Task.CompletedTask;
    }

    private async Task ConfigureReportsMenu(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<SophiChainThemeDemoResource>();

        context.Menu.AddItem(
            new ApplicationMenuItem(
                SophiChainThemeDemoMenus.HomeChild3,
                displayName: l["فاکتور"],
                "/report/invoice",
                icon: "fas fa-pen",
                order: 1
            )
        );

        context.Menu.AddItem(
            new ApplicationMenuItem(
                SophiChainThemeDemoMenus.HomeChild2,
                displayName: l["تیکت"],
                "/report/ticket",
                icon: "fas fa-pen",
                order: 2
            )
        );

        context.Menu.AddItem(
            new ApplicationMenuItem(
                SophiChainThemeDemoMenus.HomeChild4,
                displayName: l["تجمیعی"],
                "/report/agg",
                icon: "fas fa-pen",
                order: 3
            )
        );

        await Task.CompletedTask;
    }
}
