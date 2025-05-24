using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using System;
using SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Navigation;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Layouts.WebApp1Layout.Partials.Sidebar;
public partial class WA1SidebarMenu
{
    [Inject] protected MainMenuProvider MainMenuProvider { get; set; }

    protected MenuViewModel Menu { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Menu = await MainMenuProvider.GetMenuAsync();
        Menu.StateChanged += RefreshMenu;
    }

    private void RefreshMenu(object sender, EventArgs e)
    {
        InvokeAsync(StateHasChanged);
    }
}
