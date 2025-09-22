using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using System;
using SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Navigation;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Layouts.WebApp1Layout.Partials.Sidebar;
public partial class WA1SidebarMenu
{
    [Inject] protected MainMenuProvider MainMenuProvider { get; set; }

    protected MenuViewModel Menu { get; set; }
    public bool IsLoading { get; set; } = true;

    protected override async Task OnInitializedAsync()
    {
        Menu = await MainMenuProvider.GetMenuAsync();
        Menu.StateChanged += RefreshMenu;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await Task.Delay(3000);
        Menu.StateChanged += RefreshMenu;

        await base.OnAfterRenderAsync(firstRender);
    }

    private void RefreshMenu(object sender, EventArgs e)
    {
        InvokeAsync(StateHasChanged);
    }
}
