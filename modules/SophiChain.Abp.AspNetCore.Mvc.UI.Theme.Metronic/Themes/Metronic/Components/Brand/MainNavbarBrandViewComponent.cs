using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace SophiChain.Abp.AspNetCore.Mvc.UI.Theme.Metronic.Themes.Metronic.Components.Brand;

public class MainNavbarBrandViewComponent : AbpViewComponent
{
    public virtual IViewComponentResult Invoke()
    {
        return View("~/Themes/Basic/Components/Brand/Default.cshtml");
    }
}
