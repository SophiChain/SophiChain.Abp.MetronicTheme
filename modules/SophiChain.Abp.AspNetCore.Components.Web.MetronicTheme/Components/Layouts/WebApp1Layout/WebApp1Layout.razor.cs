using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Helpers;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Layouts.WebApp1Layout;
public partial class WebApp1Layout
{
    [CascadingParameter(Name = "ThemeState")]
    public ThemeCascadingState ThemeState { get; set; } = new();

    private IKTThemeHelpers KTHelper = default!;
    public bool SidebarMinimizeState;
    public bool IsLoading { get; set; } = true;

    protected override void OnInitialized()
    {
        KTHelper = new KTThemeHelpers(JS);
        KTHelper.addBodyAttribute("data-kt-app-page-loading", "on");
    }

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            KTHelper.addBodyAttribute("data-kt-app-header-fixed", "true");
            KTHelper.addBodyAttribute("data-kt-app-sidebar-fixed", "true");
            KTHelper.addBodyAttribute("data-kt-app-sidebar-hoverable", "true");
            KTHelper.addBodyAttribute("data-kt-app-sidebar-push-header", "true");
            KTHelper.addBodyAttribute("data-kt-app-sidebar-push-toolbar", "true");
            KTHelper.addBodyAttribute("data-kt-app-sidebar-push-footer", "true");
            KTHelper.addBodyAttribute("data-kt-app-toolbar-enabled", "true");

            JS.InvokeVoidAsync("KTModalUpgradePlan.init");
            JS.InvokeVoidAsync("KTCreateApp.init");
            JS.InvokeVoidAsync("KTModalUserSearch.init");
            JS.InvokeVoidAsync("KTModalNewTarget.init");
            JS.InvokeVoidAsync("KTAppSidebar.init");
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        var sidebarCookie = await JS.InvokeAsync<string>("localStorage.getItem", "sidebar_minimize_state");

        if (sidebarCookie != null)
        {
            SidebarMinimizeState = string.Equals(sidebarCookie, "on");
            if (SidebarMinimizeState)
            {
                KTHelper.addBodyAttribute("data-kt-app-sidebar-minimize", "on");
            }
        }

        var themeStyle = await JS.InvokeAsync<string>("localStorage.getItem", "data-bs-theme");

        if (themeStyle != null)
        {
            if (themeStyle == "dark")
            {
                KTTheme.SetModeSwitch(true);
                KTHelper.addBodyAttribute("data-kt-app-layout", "dark-sidebar");
                KTHelper.addBodyClass("sc-theme-dark");
                KTHelper.addBodyClass("app-default");
                await JS.InvokeVoidAsync("localStorage.setItem", "data-bs-theme", "dark");
            }
            else if (themeStyle == "light")
            {
                KTTheme.SetModeSwitch(false);
                KTHelper.addBodyAttribute("data-kt-app-layout", "light-sidebar");
                KTHelper.addBodyClass("sc-theme-light");
                KTHelper.addBodyClass("app-default");
                await JS.InvokeVoidAsync("localStorage.setItem", "data-bs-theme", "light");
            }

        }

        await Task.Delay(200);
        await JS.InvokeVoidAsync("document.body.removeAttribute", "data-kt-app-page-loading");

        ThemeState.NotifyStateChanged();

        if (IsLoading)
        {
            IsLoading = false;
            await InvokeAsync(StateHasChanged);
        }
    }
}
