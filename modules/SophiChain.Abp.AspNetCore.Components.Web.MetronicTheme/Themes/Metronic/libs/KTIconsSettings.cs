using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Themes.Metronic.libs;

class KTIconsSettings
{
    public static SortedDictionary<string, int> Config { get; set; } = new SortedDictionary<string, int>();

    public static void init(IConfiguration configuration)
    {
        Config = configuration.GetSection("duotone-paths").Get<SortedDictionary<string, int>>() ?? Config;
    }
}
