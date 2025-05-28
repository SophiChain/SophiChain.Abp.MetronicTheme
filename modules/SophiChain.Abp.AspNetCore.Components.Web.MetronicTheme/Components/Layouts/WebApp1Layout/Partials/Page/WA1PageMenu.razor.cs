using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using System;
using SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Navigation;
using Volo.Abp.AspNetCore.Components;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Layouts.WebApp1Layout.Partials.Page;
public partial class WA1PageMenu
{
    [Parameter] public string PageMenuName { get; set; } = default!;
    [Inject] protected MainMenuProvider MainMenuProvider { get; set; }

    protected MenuViewModel PageMenu { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        if (!PageMenuName.IsNullOrWhiteSpace())
        {
            try
            {
                PageMenu = await MainMenuProvider.GetMenuAsync(PageMenuName);
                PageMenu.StateChanged += RefreshMenu;
            }
            catch (Exception)
            {
                throw;
            }
        }
        await base.OnParametersSetAsync();
    }

    private void RefreshMenu(object sender, EventArgs e)
    {
        InvokeAsync(StateHasChanged);
    }
}
