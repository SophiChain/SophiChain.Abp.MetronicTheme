using Microsoft.AspNetCore.Components;
using SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Navigation;
using System.Threading.Tasks;
using System;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Shared;
public partial class ToolbarUserAccount
{
    [Inject] protected MainMenuProvider MainMenuProvider { get; set; }

    protected MenuViewModel Menu { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Menu = await MainMenuProvider.GetMenuAsync("User");
        Menu.StateChanged += RefreshMenu;
    }

    private void RefreshMenu(object sender, EventArgs e)
    {
        InvokeAsync(StateHasChanged);
    }
}
