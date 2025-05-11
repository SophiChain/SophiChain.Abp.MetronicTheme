using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace SophiChain.Abp.AspNetCore.Mvc.UI.Theme.Metronic.Themes.Metronic.Components.MainNavbar;

public class MainNavbarViewComponent : AbpViewComponent
{
    public virtual IViewComponentResult Invoke()
    {
        return View("~/Themes/Basic/Components/MainNavbar/Default.cshtml");
    }
}
