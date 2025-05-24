using Microsoft.Extensions.Configuration;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Themes.Metronic.libs;

class KTThemeSettings
{
    public static KTThemeBase Config = new KTThemeBase();

    public static void init(IConfiguration configuration)
    {
        Config = configuration.GetSection("Theme").Get<KTThemeBase>() ?? Config;
    }
}
