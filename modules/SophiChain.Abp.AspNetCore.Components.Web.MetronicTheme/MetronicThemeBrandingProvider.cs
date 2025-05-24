using Microsoft.Extensions.Localization;
using SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme;

[Dependency(ReplaceServices = true)]

public class MetronicThemeBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<MetronicResource> _localizer;

    public MetronicThemeBrandingProvider(IStringLocalizer<MetronicResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
    public override string LogoUrl => GetLogoUrl("light-logo");
    public override string LogoReverseUrl => GetLogoUrl("dark-logo");

    public string GetAppName()
    {
        return "توریست پنل";
    }

    public string GetLogoUrl(string type)
    {
        var tname = "touristpanel";
        //return $"https://files.touristpanel.me/assets/logo/{tname}-{type}-logo.png";
        switch (type)
        {
            case "light-logo":
                return "/_content/SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme/assets/media/logos/default.svg";

            case "dark-logo":
                return "/_content/SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme/assets/media/logos/default-dark.svg";

            case "minimized-logo":
                return "/_content/SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme/assets/media/logos/favicon.ico";

            default:
                return "/_content/SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme/assets/media/logos/default.svg";
        }
    }
}
