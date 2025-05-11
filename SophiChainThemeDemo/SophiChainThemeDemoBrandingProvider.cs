using Microsoft.Extensions.Localization;
using SophiChainThemeDemo.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace SophiChainThemeDemo;

[Dependency(ReplaceServices = true)]
public class SophiChainThemeDemoBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<SophiChainThemeDemoResource> _localizer;

    public SophiChainThemeDemoBrandingProvider(IStringLocalizer<SophiChainThemeDemoResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
