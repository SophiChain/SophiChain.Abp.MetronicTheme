using Microsoft.AspNetCore.Components;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Layouts.WebApp1Layout.Partials.Page;
public partial class WA1PageFilters
{
    [Parameter] public RenderFragment FiltersContent { get; set; }
    [Parameter] public RenderFragment FiltersButtons { get; set; }
    [Parameter] public string FiltersTitle { get; set; } = default!;
    [Parameter] public bool IsFilterOpen { get; set; }
    [Parameter] public bool ShowFiltersSave { get; set; }
}
