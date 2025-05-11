using System.Collections.Generic;
using Volo.Abp.Localization;

namespace SophiChain.Abp.AspNetCore.Mvc.UI.Theme.Metronic.Themes.Metronic.Components.Toolbar.LanguageSwitch;

public class LanguageSwitchViewComponentModel
{
    public LanguageInfo CurrentLanguage { get; set; }

    public List<LanguageInfo> OtherLanguages { get; set; }
}
