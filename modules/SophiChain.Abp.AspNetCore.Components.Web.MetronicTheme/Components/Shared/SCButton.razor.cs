using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Shared;
public partial class SCButton
{
    [Parameter] public string ThemeColor { get; set; } = "primary";
    [Parameter] public string Title { get; set; }
    [Parameter] public bool Enabled { get; set; } = true;
    [Parameter] public object Icon { get; set; }
    [Parameter] public string Id { get; set; }
    [Parameter] public string Href { get; set; }
    [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }
    [Parameter] public RenderFragment ChildContent { get; set; }

    private string GetBootstrapClass()
    {
        return $"btn-{ThemeColor}";
    }
}
