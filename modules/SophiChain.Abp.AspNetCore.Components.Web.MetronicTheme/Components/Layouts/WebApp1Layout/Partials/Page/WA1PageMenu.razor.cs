using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Helpers;
using SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Navigation;
using Volo.Abp.AspNetCore.Components;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Layouts.WebApp1Layout.Partials.Page;
public partial class WA1PageMenu
{
    [CascadingParameter(Name = "ThemeState")]
    public ThemeCascadingState ThemeState { get; set; }

    [Inject] protected MainMenuProvider MainMenuProvider { get; set; }

    [Parameter] public string PageMenuName { get; set; } = default!;

    protected MenuViewModel PageMenu { get; set; }

    protected override async Task OnInitializedAsync()
    {
        ThemeState.OnStateHasChanged += OnThemeStateChanged;
        await Task.CompletedTask;
    }

    protected override async Task OnParametersSetAsync()
    {
        await UpdatePageMenuAsync();
        await base.OnParametersSetAsync();
    }

    private async void OnThemeStateChanged()
    {
        await UpdatePageMenuAsync();
        await InvokeAsync(StateHasChanged);
    }

    private async Task UpdatePageMenuAsync()
    {
        if (!ThemeState.PageMenuName.IsNullOrWhiteSpace())
        {
            try
            {
                PageMenu = await MainMenuProvider.GetMenuAsync(ThemeState.PageMenuName);
                PageMenu.StateChanged += RefreshMenu;
            }
            catch (Exception)
            {
                throw;
            }
        }
        else
        {
            PageMenu = null;
        }
    }

    private void RefreshMenu(object sender, EventArgs e)
    {
        InvokeAsync(StateHasChanged);
    }
}
