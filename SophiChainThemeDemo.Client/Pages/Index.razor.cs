using SophiChainThemeDemo.Extensions;
using Volo.Abp.AspNetCore.Components.Web.Theming.PageToolbars;

namespace SophiChainThemeDemo.Pages;

public partial class Index
{
    public PageToolbar PageToolbar { get; set; } = new PageToolbar();
    private bool IsLoading { get; set; }
    public string? IsLoadingText { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await GetToolbar();

        //IsLoadingText = "لطفا صبر کنید ...";
        //IsLoading = true;
        //await Task.Delay(5000);
        //IsLoading = false;
    }

    private async Task GetToolbar()
    {
        PageToolbar!.AddTPMButton("سبد خرید", "fa-duotone fa-solid fa-shopping-cart", "primary", "kt_drawer_cart_toggle");
        PageToolbar!.AddTPMButton("فیلترها", "fa-duotone fa-solid fa-filter", "secondary", "kt_drawer_filters_toggle");
        PageToolbar!.AddTPMButton("مدیریت", "icon-accounts-management-solid", "light", "kt_drawer_filters_toggle", enabled: false, href: "/");
    }
}
