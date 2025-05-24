using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme;
using SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Navigation;

namespace SophiChain.Abp.AspNetCore.Components.Server.MetronicTheme
{
    public class MetronicThemeBlazorOptions
    {
        /// <summary>
        /// Determines layout of appliction. Default value is <see cref="MetronicThemeBlazorLayouts.WebApp1Layout"/>
        /// </summary>
        public Type Layout { get; set; } = MetronicThemeBlazorLayouts.WebApp1Layout;

        public Func<IReadOnlyList<MenuItemViewModel>, IEnumerable<MenuItemViewModel>> MobileMenuSelector { get; set; } = (menuItems) => menuItems.Where(x => x.Items.IsNullOrEmpty());
    }
}
