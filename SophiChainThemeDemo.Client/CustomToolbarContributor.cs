using SophiChainThemeDemo.Components.Toolbars;
using Volo.Abp.AspNetCore.Components.Web.Theming.Toolbars;

namespace SophiChainThemeDemo;

public class CustomToolbarContributor : IToolbarContributor
{
    public Task ConfigureToolbarAsync(IToolbarConfigurationContext context)
    {
        if (context.Toolbar.Name == StandardToolbars.Main)
        {
            context.Toolbar.Items.Insert(0, new ToolbarItem(typeof(ToolbarChatToggle)));
            context.Toolbar.Items.Insert(1, new ToolbarItem(typeof(ToolbarUserAccount)));
        }

        return Task.CompletedTask;
    }
}
