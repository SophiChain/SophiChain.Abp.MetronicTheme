using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Components.Web.Theming.Toolbars;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Layouts.WebApp1Layout.Partials.Header;
public partial class WA1HeaderToolbar
{
    [Inject] public IToolbarManager ToolbarManager { get; set; } = default!;

    private Toolbar SiteToolbar { get; set; }

    protected override async Task OnInitializedAsync()
    {
        SiteToolbar = await ToolbarManager.GetAsync(StandardToolbars.Main);

        await base.OnInitializedAsync();
    }
}
