using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using SophiChainThemeDemo.Components;
using Volo.Abp.BlazoriseUI;

namespace SophiChainThemeDemo.Pages;
public partial class AggReport
{
    [CascadingParameter(Name = "ReportFiltersHelper")]
    public required ReportFiltersHelper _Helper { get; set; }

    public List<BreadcrumbItem> CustomBreadcrumb { get; set; }

    protected override async Task OnInitializedAsync()
    {
        CustomBreadcrumb = new List<BreadcrumbItem>()
        {
            new(text: "خانه", url: "/"),
            new(text: "صفحه نه"),
        };

        await Task.CompletedTask;
    }
}
