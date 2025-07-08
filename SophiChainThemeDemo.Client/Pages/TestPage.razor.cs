using Volo.Abp.BlazoriseUI;

namespace SophiChainThemeDemo.Pages;
public partial class TestPage
{
    public List<BreadcrumbItem> CustomBreadcrumb { get; set; }

    protected override async Task OnInitializedAsync()
    {
        CustomBreadcrumb = new List<BreadcrumbItem>()
        {
            new(text: "خانه", url: "/"),
            new(text: "صفحه هفت"),
        };

        await Task.CompletedTask;
    }
}
