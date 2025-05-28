using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Helpers;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Shared;
public partial class SCPageLayout
{
    [CascadingParameter(Name = "ThemeState")]
    public ThemeCascadingState ThemeState { get; set; }
    [Parameter] public string? MenuName { get; set; }

    protected async override Task OnParametersSetAsync()
    {
        ThemeState.PageMenuName = MenuName;
        ThemeState.PageToolbar = Toolbar;

        await Task.CompletedTask;
    }
}
