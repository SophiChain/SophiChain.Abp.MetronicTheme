using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components;
using System;
using Volo.Abp.AspNetCore.Components.Web.Theming.Layout;
using SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Navigation;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Shared;
public partial class TopMenuItem
{
    [Inject] protected NavigationManager NavigationManager { get; set; }

    [Inject] protected PageLayout PageLayout { get; set; }

    [Parameter] public MenuViewModel Menu { get; set; }

    [Parameter] public MenuItemViewModel MenuItem { get; set; }

    protected override void OnParametersSet()
    {
        ActivateCurrentPage();
        PageLayout.PropertyChanged += (s, e) =>
        {
            if (e.PropertyName == nameof(PageLayout.MenuItemName))
            {
                ActivateCurrentPage();
            }
        };
    }

    protected override void OnInitialized()
    {
        NavigationManager.LocationChanged += OnLocationChanged;
    }

    protected virtual void OnLocationChanged(object sender, LocationChangedEventArgs e)
    {
        ActivateCurrentPage();
    }

    protected virtual void ActivateCurrentPage()
    {
        if (MenuItem.MenuItem.Url.IsNullOrEmpty())
        {
            return;
        }

        if (PageLayout.MenuItemName.IsNullOrEmpty())
        {
            var menuItemPath = MenuItem.MenuItem.Url.Replace("~/", string.Empty).Trim('/');
            var currentPagePath = new Uri(NavigationManager.Uri.TrimEnd('/')).AbsolutePath.Trim('/');
            if (menuItemPath.TrimEnd('/').Equals(currentPagePath, StringComparison.InvariantCultureIgnoreCase))
            {
                Menu.Activate(MenuItem);
            }

            return;
        }

        if (PageLayout.MenuItemName == MenuItem.MenuItem.Name)
        {
            Menu.Activate(MenuItem);
        }
    }

    protected virtual void ToggleMenu()
    {
        Menu.ToggleOpen(MenuItem);
    }

    private void NavigateToUrl(string url)
    {
        Navigation.NavigateTo(url, true);

    }
}
