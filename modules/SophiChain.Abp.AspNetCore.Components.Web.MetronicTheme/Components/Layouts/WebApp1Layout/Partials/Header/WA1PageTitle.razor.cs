using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using Volo.Abp.BlazoriseUI;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Layouts.WebApp1Layout.Partials.Header;
public partial class WA1PageTitle
{
    [Parameter] public List<BreadcrumbItem> CustomBreadcrumb { get; set; }
}
