using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SophiChain.Abp.AspNetCore.Mvc.UI.Theme.Metronic;
using SophiChain.Abp.AspNetCore.Mvc.UI.Theme.Metronic.Themes.Metronic.Components.Toolbar.LanguageSwitch;
using SophiChain.Abp.AspNetCore.Mvc.UI.Theme.Metronic.Themes.Metronic.Components.Toolbar.UserMenu;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.Localization;
using Volo.Abp.Users;

namespace SophiChain.Abp.AspNetCore.Mvc.UI.Theme.Metronic.Toolbars;

public class MetronicThemeMainTopToolbarContributor : IToolbarContributor
{
    public async Task ConfigureToolbarAsync(IToolbarConfigurationContext context)
    {
        if (context.Toolbar.Name != StandardToolbars.Main)
        {
            return;
        }

        if (!(context.Theme is MetronicTheme))
        {
            return;
        }

        var languageProvider = context.ServiceProvider.GetService<ILanguageProvider>();

        //TODO: This duplicates GetLanguages() usage. Can we eleminate this?
        var languages = await languageProvider.GetLanguagesAsync();
        if (languages.Count > 1)
        {
            context.Toolbar.Items.Add(new ToolbarItem(typeof(LanguageSwitchViewComponent)));
        }

        if (context.ServiceProvider.GetRequiredService<ICurrentUser>().IsAuthenticated)
        {
            context.Toolbar.Items.Add(new ToolbarItem(typeof(UserMenuViewComponent)));
        }
    }
}
