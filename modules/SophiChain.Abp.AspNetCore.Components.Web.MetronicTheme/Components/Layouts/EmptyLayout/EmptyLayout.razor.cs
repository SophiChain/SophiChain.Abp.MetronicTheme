using SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Helpers;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Layouts.EmptyLayout;
public partial class EmptyLayout
{
    private IKTThemeHelpers? KTHelper;

    protected override void OnAfterRender(bool firstRender)
    {
        KTHelper = new KTThemeHelpers(JS);
        KTHelper.addBodyClass("app-blank");
    }
}
