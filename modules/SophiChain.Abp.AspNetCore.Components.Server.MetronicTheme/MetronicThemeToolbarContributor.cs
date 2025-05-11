using System.Threading.Tasks;
using SophiChain.Abp.AspNetCore.Components.Server.MetronicTheme.Themes.Metronic;
using Volo.Abp.AspNetCore.Components.Web.Theming.Toolbars;

namespace SophiChain.Abp.AspNetCore.Components.Server.MetronicTheme;

public class MetronicThemeToolbarContributor : IToolbarContributor
{
    public Task ConfigureToolbarAsync(IToolbarConfigurationContext context)
    {
        if (context.Toolbar.Name == StandardToolbars.Main)
        {
            context.Toolbar.Items.Add(new ToolbarItem(typeof(LoginDisplay)));
            context.Toolbar.Items.Add(new ToolbarItem(typeof(LanguageSwitch)));
        }

        return Task.CompletedTask;
    }
}
