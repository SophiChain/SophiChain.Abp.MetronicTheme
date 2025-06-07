using Blazorise.Snackbar;
using SophiChainThemeDemo.Extensions;
using Volo.Abp.AspNetCore.Components.Notifications;
using Volo.Abp.AspNetCore.Components.Web.Theming.PageToolbars;
using Volo.Abp.BlazoriseUI;

namespace SophiChainThemeDemo.Pages;

public partial class Index
{
    public PageToolbar Toolbar { get; set; } = new PageToolbar();
    public List<BreadcrumbItem> CustomBreadcrumb { get; set; }

    public bool IsFilterOpen { get; set; } = true;

    public class TreeItem
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }

    public IEnumerable<TreeItem> Data { get; set; }

    protected override async Task OnInitializedAsync()
    {
        List<TreeItem> items = new List<TreeItem>();
        items.Add(new TreeItem() { Id = 0, Text = "فیلترها" });
        Data = items;



        GetToolbar();

        CustomBreadcrumb = new List<BreadcrumbItem>()
        {
            new(text: "خانه", url: "/"),
            new(text: "صفحه شش"),
        };

        await InvokeAsync(StateHasChanged);
    }

    private async Task ShowSnack()
    {
        await Notify.Warn("این یک متن هشدار برای نوتیفیکیشن است.");
    }

    private async Task ShowMessage()
    {
        //var confirmed = await Message.Confirm(
        //    "این یک متن برای سرویس مسج است.", 
        //    "هشدار",
        //    (options) =>
        //    {
        //        options.MessageIcon = "fa-solid fa-home";
        //        options.OkButtonText = "اوکی";
        //        options.ConfirmButtonText = "تایید";
        //        options.CancelButtonText = "انصراف";

        //    });
        //if (confirmed)
        //{
        //    await Notify.Warn("این یک متن هشدار برای نوتیفیکیشن است.");
        //}

        await Message.Warn(
            "این یک متن هشدار برای مسج است.",
            "هشدار",
            (options) =>
            {
                options.OkButtonText = "فهمیدم";
            }
        );
    }

    private void ShowAlert()
    {
        Alerts.Warning("این یک متن هشدار برای آلرت است.", "هشدار");
        Alerts.Success("این یک متن هشدار برای آلرت است.", "هشدار");
        Alerts.Info("این یک متن هشدار برای آلرت است.", "هشدار");
        Alerts.Danger("این یک متن هشدار برای آلرت است.", "هشدار");
    }

    private void GetToolbar()
    {
        Toolbar!.AddTPMButton("سبد خرید", "fa-duotone fa-solid fa-shopping-cart", "primary", "kt_drawer_cart_toggle");
        Toolbar!.AddTPMButton("فیلترها", "fa-duotone fa-solid fa-filter", "secondary", "kt_drawer_filters_toggle");
        Toolbar!.AddTPMButton("مدیریت", "icon-accounts-management-solid", "light", "kt_drawer_filters_toggle", enabled: false, href: "/");
    }
}
