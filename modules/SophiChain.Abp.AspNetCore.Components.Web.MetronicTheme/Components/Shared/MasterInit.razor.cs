using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Shared;
public partial class MasterInit
{
    protected override void OnAfterRender(bool firstRender)
    {
        JS.InvokeVoidAsync("KTThemeMode.init");
        JS.InvokeVoidAsync("emptyBody");
        if (firstRender)
        {
            JS.InvokeVoidAsync("scrollTo", 0, 0);
            JS.InvokeVoidAsync("KTComponents.init");
            JS.InvokeVoidAsync("KTMenu.updateByLinkAttribute", $"/{NavigationManager.ToBaseRelativePath(NavigationManager.Uri)}");
        }
        JS.InvokeVoidAsync("KTLayoutSearch.init");
    }


    protected override void OnInitialized()
    {
        NavigationManager.LocationChanged += OnLocationChanged;
    }

    async void OnLocationChanged(object sender, LocationChangedEventArgs args)
    {
        await JS.InvokeVoidAsync("scrollTo", 0, 0);
        await JS.InvokeVoidAsync("KTComponents.init");
        await JS.InvokeVoidAsync("KTMenu.updateByLinkAttribute", $"/{NavigationManager.ToBaseRelativePath(args.Location)}");
    }

    public void Dispose()
    {
        NavigationManager.LocationChanged -= OnLocationChanged;
    }
}
