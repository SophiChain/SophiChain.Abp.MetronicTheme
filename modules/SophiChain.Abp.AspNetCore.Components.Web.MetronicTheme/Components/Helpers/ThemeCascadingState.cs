using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Components.Web.Theming.PageToolbars;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Helpers
{
    public class ThemeCascadingState
    {
        public string PageMenuName { get; set; } = default!;
        public bool ShowToolBar { get; set; } = true;
        public bool ShowTitle { get; set; } = true;
        public bool ShowBreadCrumb { get; set; } = true;
        public PageToolbar PageToolbar { get; set; } = new PageToolbar();
    }
}
