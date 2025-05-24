using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Volo.Abp.AspNetCore.Components.Web.Theming.Layout;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Layouts.WebApp1Layout.Partials.Page;
public partial class WA1PageToolbar
{
    [Parameter] public string PageMenuName { get; set; } = default!;

    [Inject] public IOptions<PageHeaderOptions> Options { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        Options.Value.RenderToolbar = true;

        await base.OnInitializedAsync();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

    }
}
