using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;
using Microsoft.Extensions.Localization;
using SophiChainThemeDemo.Localization;

namespace SophiChainThemeDemo;

public class SophiChainThemeDemoBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<SophiChainThemeDemoResource> _localizer;

    public SophiChainThemeDemoBrandingProvider(IStringLocalizer<SophiChainThemeDemoResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
