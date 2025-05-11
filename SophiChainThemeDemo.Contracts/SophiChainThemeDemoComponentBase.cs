using SophiChainThemeDemo.Localization;
using Volo.Abp.AspNetCore.Components;

namespace SophiChainThemeDemo;

public abstract class SophiChainThemeDemoComponentBase : AbpComponentBase
{
    protected SophiChainThemeDemoComponentBase()
    {
        LocalizationResource = typeof(SophiChainThemeDemoResource);
    }
}
