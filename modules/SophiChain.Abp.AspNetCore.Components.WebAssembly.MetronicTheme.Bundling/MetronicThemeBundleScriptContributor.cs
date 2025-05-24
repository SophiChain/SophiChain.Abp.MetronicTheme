using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace SophiChain.Abp.AspNetCore.Components.WebAssembly.MetronicTheme.Bundling
{
    public class MetronicThemeBundleScriptContributor : BundleContributor
    {
        private const string RootPath = "/_content/SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme";

        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.AddIfNotContains($"{RootPath}/assets/plugins/global/plugins.bundle.js");
            context.Files.AddIfNotContains($"{RootPath}/assets/js/widgets.bundle.js");
            context.Files.AddIfNotContains($"{RootPath}/assets/js/scripts.bundle.js");
        }
    }
}
