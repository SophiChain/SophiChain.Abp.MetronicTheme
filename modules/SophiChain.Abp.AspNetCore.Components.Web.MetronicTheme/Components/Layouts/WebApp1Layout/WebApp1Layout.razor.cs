using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Helpers;
using Volo.Abp.AspNetCore.Components.Web;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Layouts.WebApp1Layout;
public partial class WebApp1Layout
{
    [Inject] public CookieService CookieService { get; set; }

    private IKTThemeHelpers KTHelper = default!;
    public bool SidebarMinimizeState;

    protected override void OnInitialized()
    {
        KTHelper = new KTThemeHelpers(JS);
    }

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            KTHelper.addBodyClass("app-default");

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
        if (firstRender)
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
                    await JS.InvokeVoidAsync("localStorage.setItem", "data-bs-theme", "dark");
                }
                else if (themeStyle == "light")
                {
                    KTTheme.SetModeSwitch(false);
                    KTHelper.addBodyAttribute("data-kt-app-layout", "light-sidebar");
                    KTHelper.addBodyClass("sc-theme-light");
                    await JS.InvokeVoidAsync("localStorage.setItem", "data-bs-theme", "light");
                }
                await InvokeAsync(StateHasChanged);
            }
        }
    }
}
