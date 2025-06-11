using Microsoft.AspNetCore.Components;
using Telerik.Blazor;
using Telerik.Blazor.Components.Drawer;
using Telerik.Blazor.Components;
using Volo.Abp.AspNetCore.Components.Web.Theming.PageToolbars;
using Telerik.SvgIcons;
using Volo.Abp.AspNetCore.Components;

namespace SophiChainThemeDemo.Pages;
public partial class TelerikComponents 
{
    public PageToolbar PageToolbar { get; set; } = new PageToolbar();
    public string? IsLoadingText { get; set; }

    private int PageIndex = 1;
    public class CarouselModel
    {
        public int ImageID { get; set; }
    }

    public List<CarouselModel> CarouselData { get; set; }

    [CascadingParameter]
    public DialogFactory Dialogs { get; set; }

    private bool Visible { get; set; } = false;
    private bool WindowIsVisible { get; set; }
    private bool ModalIsVisible { get; set; }

    bool SoundOn { get; set; }
    string AudioString { get; set; }

    public class DrawerItem
    {
    }

    public IEnumerable<DrawerItem> DrawerData { get; set; } = new List<DrawerItem>();

    public TelerikDrawer<DrawerItem> Drawer { get; set; }


    public async Task ActivateAlert()
    {
        await Dialogs.AlertAsync("متاسفانه مشکلی پیش آمده است!", "عنوان دیالوگ", "متن دکمه تایید");
    }

    public async Task ActivateConfirm()
    {
        bool confirmed;
        confirmed = await Dialogs.ConfirmAsync("آیا اطمینان دارید؟", "عنوان دیالوگ", "متن دکمه تایید", "متن دکمه انصراف");
    }

    public async Task ActivatePrompt()
    {
        string input;
        input = await Dialogs.PromptAsync("لطفا مبلغ را وارد کنید:", "عنوان دیالوگ", "مقدار دیفالت", "متن دکمه تایید", "متن دکمه انصراف");
    }

    public string Value { get; set; } =
        @"
        <h1 style=""text-align:center;; font-size: large"">
            <span style=""font-family:Verdana, Geneva, sans-serif;"">
                <strong> One of the Most Beautiful Islands on Earth - Tenerife</strong>
            </span>
        </h1>
        <p>
            <span style = ""font-family:Verdana, Geneva, sans-serif;font-size:medium;"" ><strong> Overview </strong>
            </span>
        </p>
        <p>
            <strong>Tenerife</strong> is the largest and most populated island of the eight <a href=""https://en.wikipedia.org/wiki/Canary_Islands"" target=""_blank"">Canary Islands</a>. It is also the most populated island of <strong>Spain</strong>, with a land area of 2,034.38 square kilometers (785 sq mi) and 904,713 inhabitants, 43% of the total population of the <strong>Canary Islands</strong>.
            The archipelago's beaches, climate and important natural attractions, make it a major tourist destination with over 12 million visitors per year.
        </p>
        ";

    public int ArcGaugeValue { get; set; } = 20;

    public List<int?> PageSizes => new List<int?> { 5, 10, 25, 50, null };

    public int Page { get; set; } = 3;
    public int PageSize { get; set; } = 10;
    public int Total { get; set; } = 210;

    private TelerikPopover PopoverRef { get; set; } = null!;
    private TelerikPopover ClickPopoverRef { get; set; } = null!;

    private TelerikForm WizardForm { get; set; }
    public class UserDetails
    {
        public string Email { get; set; } = "john.smith@domain.com";

        public string Password { get; set; } = "12345678";
    }
    private UserDetails RegistrationModel { get; set; } = new UserDetails();

    public int WizardValue { get; set; }

    protected override Task OnInitializedAsync()
    {
        CarouselData = Enumerable.Range(1, 7).Select(x => new CarouselModel
        {
            ImageID = x
        }).ToList();

        return base.OnInitializedAsync();
    }

    private void CloseDialog()
    {
        Visible = false;
    }

    public async Task ToggleDrawer() => await Drawer.ToggleAsync();

    private void ClosePopover()
    {
        ClickPopoverRef.Hide();
    }

    protected void MuteClickHandler()
    {
        AudioString = "Audio: " + (SoundOn ? "100%" : "Muted");
    }

    private void ToggleWindow() => WindowIsVisible = !WindowIsVisible;
    private void ToggleModal() => ModalIsVisible = !ModalIsVisible;

    private void Cancel() => WindowIsVisible = false;
    private void CancelModal() => ModalIsVisible = false;

    private void OnClear()
    {
        WizardValue = 1;
    }

    private DateTime? _date = DateTime.Today;
}
