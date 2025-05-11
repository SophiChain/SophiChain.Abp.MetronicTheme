using Volo.Abp.Application.Services;
using SophiChainThemeDemo.Localization;

namespace SophiChainThemeDemo.Services;

/* Inherit your application services from this class. */
public abstract class SophiChainThemeDemoAppService : ApplicationService
{
    protected SophiChainThemeDemoAppService()
    {
        LocalizationResource = typeof(SophiChainThemeDemoResource);
    }
}