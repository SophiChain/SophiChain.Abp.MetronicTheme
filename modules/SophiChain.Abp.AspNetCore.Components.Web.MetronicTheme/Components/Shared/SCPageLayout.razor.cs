using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Helpers;
using Volo.Abp.AspNetCore.Components.Web.Theming.Toolbars;
using Volo.Abp.BlazoriseUI;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Shared;
public partial class SCPageLayout
{
    [CascadingParameter(Name = "ThemeState")]
    public ThemeCascadingState ThemeState { get; set; }

    [Parameter] public string? MenuName { get; set; }

    protected override async Task OnInitializedAsync()
    {
        ThemeState.OnStateHasChanged += StateHasChanged;
        await Task.CompletedTask;
    }

    protected async override Task OnParametersSetAsync()
    {
        // Update theme state with current parameters
        ThemeState.PageMenuName = MenuName ?? string.Empty;
        ThemeState.PageToolbar = Toolbar;
        ThemeState.Title = Title ?? string.Empty;
        ThemeState.CustomBreadcrumb = BreadcrumbItems ?? new List<BreadcrumbItem>();
        
        // Notify all components about the state change
        ThemeState.NotifyStateChanged();

        // Clear the inherited properties to prevent them from being rendered
        MenuName = null;
        Toolbar = null;
        BreadcrumbItems = new List<BreadcrumbItem>();

        await InvokeAsync(StateHasChanged);
        await Task.CompletedTask;
    }
}
