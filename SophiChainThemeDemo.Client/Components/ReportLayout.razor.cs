using Microsoft.AspNetCore.Components;

namespace SophiChainThemeDemo.Components;
public partial class ReportLayout
{
    [CascadingParameter(Name = "ReportFiltersHelper")]
    public required ReportFiltersHelper _Helper { get; set; }
}
