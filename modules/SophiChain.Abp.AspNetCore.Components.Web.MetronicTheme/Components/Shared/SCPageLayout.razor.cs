using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Helpers;
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
        ThemeState.PageMenuName = MenuName;
        ThemeState.PageToolbar = Toolbar;
        ThemeState.Title = Title;
        ThemeState.CustomBreadcrumb = BreadcrumbItems;

        ThemeState.NotifyStateChanged();

        await Task.CompletedTask;
    }
}
