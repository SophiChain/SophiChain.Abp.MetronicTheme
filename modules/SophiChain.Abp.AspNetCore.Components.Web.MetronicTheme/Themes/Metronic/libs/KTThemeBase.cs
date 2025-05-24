using System;
using System.Collections.Generic;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Themes.Metronic.libs;

// Base type class for theme settings
class KTThemeBase
{
    public string LayoutDir { get; set; } = string.Empty;

    public string Direction { get; set; } = string.Empty;

    public bool ModeSwitchEnabled { get; set; } = false;

    public string ModeDefault { get; set; } = string.Empty;

    public string AssetsDir { get; set; } = string.Empty;

    public string IconsType { get; set; } = string.Empty;

    public KTThemeAssets Assets { get; set; } = new KTThemeAssets();

    public SortedDictionary<string, SortedDictionary<string, string[]>> Vendors { get; set; } = new SortedDictionary<string, SortedDictionary<string, string[]>>();
}
