using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using System;
using SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Navigation;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Layouts.WebApp1Layout.Partials.Page;
public partial class WA1PageMenu
{
    [Parameter] public string PageMenuName { get; set; } = default!;
    [Inject] protected MainMenuProvider MainMenuProvider { get; set; }

    protected MenuViewModel PageMenu { get; set; }

    protected override async Task OnInitializedAsync()
    {
        PageMenu = await MainMenuProvider.GetMenuAsync(PageMenuName);
        PageMenu.StateChanged += RefreshMenu;
    }

    private void RefreshMenu(object sender, EventArgs e)
    {
        InvokeAsync(StateHasChanged);
    }
}
