using System.Threading.Tasks;
using Microsoft.JSInterop;
using SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Helpers;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Shared;
public partial class ToggleTheme
{
    public string ThemeStyle { get; set; }

    private IKTThemeHelpers KTHelper = default!;

    protected override void OnInitialized()
    {
        KTHelper = new KTThemeHelpers(JS);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            ThemeStyle = await JS.InvokeAsync<string>("localStorage.getItem", "data-bs-theme");

            await InvokeAsync(StateHasChanged);
        }
    }

    public async Task ToggleThemeMode(string themeMode)
    {
        ThemeStyle = themeMode == "dark" ? "light" : "dark";

        KTTheme.SetModeDefault(themeMode);

        if (ThemeStyle == "dark")
        {
            KTTheme.SetModeSwitch(true);
            KTHelper.addBodyAttribute("data-kt-app-layout", "dark-sidebar");
            KTHelper.addBodyClass("sc-theme-dark");
            KTHelper.removeBodyClass("sc-theme-light");
            await JS.InvokeVoidAsync("localStorage.setItem", "data-bs-theme", "dark");
            await JS.InvokeVoidAsync("document.documentElement.setAttribute", "data-bs-theme", "dark");
        }
        else if (ThemeStyle == "light")
        {
            KTTheme.SetModeSwitch(false);
            KTHelper.addBodyAttribute("data-kt-app-layout", "light-sidebar");
            KTHelper.addBodyClass("sc-theme-light");
            KTHelper.removeBodyClass("sc-theme-dark");
            await JS.InvokeVoidAsync("localStorage.setItem", "data-bs-theme", "light");
            await JS.InvokeVoidAsync("document.documentElement.setAttribute", "data-bs-theme", "light");
        }
        await InvokeAsync(StateHasChanged);
    }
}
