using System;
using SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Layouts.Auth1Layout;
using SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Layouts.EmptyLayout;
using SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Layouts.WebApp1Layout;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme
{
    public class MetronicThemeBlazorLayouts
    {
        public static readonly Type WebApp1Layout = typeof(WebApp1Layout);
        public static readonly Type Auth1Layout = typeof(Auth1Layout);
        public static readonly Type EmptyLayout = typeof(EmptyLayout);
    }
}
