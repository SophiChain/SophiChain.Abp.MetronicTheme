using SophiChainThemeDemo.Extensions;
using Volo.Abp.AspNetCore.Components.Web.Theming.Layout;
using Volo.Abp.AspNetCore.Components.Web.Theming.PageToolbars;
using Volo.Abp.BlazoriseUI;

namespace SophiChainThemeDemo.Pages;

public partial class Index
{
    public PageToolbar Toolbar { get; set; } = new PageToolbar();
    public List<BreadcrumbItem> CustomBreadcrumb { get; set; }

    protected override async Task OnInitializedAsync()
    {
        GetToolbar();

        CustomBreadcrumb = new List<BreadcrumbItem>()
        {
            new(text: "خانه", url: "/"),
            new(text: "صفحه شش"),
        };

        await InvokeAsync(StateHasChanged);
    }

    private void GetToolbar()
    {
        Toolbar!.AddTPMButton("سبد خرید", "fa-duotone fa-solid fa-shopping-cart", "primary", "kt_drawer_cart_toggle");
        Toolbar!.AddTPMButton("فیلترها", "fa-duotone fa-solid fa-filter", "secondary", "kt_drawer_filters_toggle");
        Toolbar!.AddTPMButton("مدیریت", "icon-accounts-management-solid", "light", "kt_drawer_filters_toggle", enabled: false, href: "/");
    }
}
