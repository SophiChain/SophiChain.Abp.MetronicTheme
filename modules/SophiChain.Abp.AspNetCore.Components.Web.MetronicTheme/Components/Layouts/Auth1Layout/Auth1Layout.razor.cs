using Microsoft.JSInterop;
using SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Helpers;
using System.Threading.Tasks;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Layouts.Auth1Layout;
public partial class Auth1Layout
{
    private IKTThemeHelpers? KTHelper;

    protected override void OnAfterRender(bool firstRender)
    {
        KTHelper = new KTThemeHelpers(JS);
        KTHelper.addBodyClass("app-blank");
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await Task.Delay(300);
        await JS.InvokeVoidAsync("document.body.removeAttribute", "data-kt-app-reset-transition");
    }
}
