using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Helpers;
using Volo.Abp.AspNetCore.Components.Web.Theming.Layout;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Layouts.WebApp1Layout.Partials.Header;
public partial class WA1PageTitle
{
    [CascadingParameter(Name = "ThemeState")]
    public ThemeCascadingState ThemeState { get; set; }

    [Inject] public IOptions<PageHeaderOptions> Options { get; set; } = default!;

    protected override void OnInitialized()
    {
        UpdatePageHeaderOptions();
    }

    protected override async Task OnInitializedAsync()
    {
        ThemeState.OnStateHasChanged += OnThemeStateChanged;
        await Task.CompletedTask;
    }

    private void OnThemeStateChanged()
    {
        UpdatePageHeaderOptions();
        InvokeAsync(StateHasChanged);
    }

    private void UpdatePageHeaderOptions()
    {
        if (ThemeState.ShowTitle)
        {
            Options.Value.RenderPageTitle = true;
        }

        if (ThemeState.ShowBreadCrumb)
        {
            Options.Value.RenderBreadcrumbs = true;
        }
    }
}
