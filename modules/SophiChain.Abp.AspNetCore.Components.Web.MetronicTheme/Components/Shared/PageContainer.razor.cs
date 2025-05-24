using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Volo.Abp.AspNetCore.Components.Web.Theming.PageToolbars;
using Volo.Abp.BlazoriseUI;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Shared;
public partial class PageContainer
{
    [Parameter] public RenderFragment MainContent { get; set; }
    [Parameter] public RenderFragment PageFilters { get; set; }
    [Parameter] public RenderFragment Drawers { get; set; }
    [Parameter] public PageToolbar PageToolbar { get; set; }
    [Parameter] public string PageMenuName { get; set; } = default!;
    [Parameter] public string PageHeaderTitle { get; set; }
    [Parameter] public bool IsLoading { get; set; } = false;
    [Parameter] public string IsLoadingText { get; set; }
    [Parameter] public List<BreadcrumbItem> CustomBreadcrumb { get; set; }

    public string SelectedLayout { get; set; }

    protected override void OnInitialized()
    {
        SelectedLayout = "WebApp1Layout";
    }

    //protected override void OnParametersSet()
    //{
    //    if (!IsLoading)
    //    {
    //        KTHelper.addBodyAttribute("data-kt-app-page-loading", "off");
    //    }
    //}

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            var layoutFromStorage = await JS.InvokeAsync<string>("localStorage.getItem", "selectedLayout");

            if (!string.IsNullOrEmpty(layoutFromStorage))
            {
                SelectedLayout = layoutFromStorage;
                await InvokeAsync(StateHasChanged);
            }
        }
    }
}
