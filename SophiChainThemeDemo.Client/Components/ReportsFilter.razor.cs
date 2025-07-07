using Microsoft.AspNetCore.Components;

namespace SophiChainThemeDemo.Components;
public partial class ReportsFilter
{
    [CascadingParameter(Name = "ReportFiltersHelper")]
    public required ReportFiltersHelper _Helper { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _Helper.OnStateHasChanged += StateHasChanged;
    }

    private async Task ApplyFiltersAsync()
    {
        _Helper.NumTest++;
    }
}
