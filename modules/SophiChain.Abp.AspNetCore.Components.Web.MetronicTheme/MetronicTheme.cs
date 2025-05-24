using System;
using Microsoft.Extensions.Options;
using SophiChain.Abp.AspNetCore.Components.Server.MetronicTheme;
using Volo.Abp.AspNetCore.Components.Web.Theming.Layout;
using Volo.Abp.AspNetCore.Components.Web.Theming.Theming;
using Volo.Abp.DependencyInjection;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme;

[ThemeName(Name)]
public class MetronicTheme : ITheme, ITransientDependency
{
    public const string Name = "MetronicTheme";

    private readonly MetronicThemeBlazorOptions _options;

    public MetronicTheme(IOptions<MetronicThemeBlazorOptions> options)
    {
        _options = options.Value;
    }

    public Type GetLayout(string name, bool fallbackToDefault = true)
    {
        switch (name)
        {
            case StandardLayouts.Application:
            case StandardLayouts.Public:
                return _options.Layout;

            case StandardLayouts.Account:
                return MetronicThemeBlazorLayouts.Auth1Layout;

            case StandardLayouts.Empty:
                return MetronicThemeBlazorLayouts.EmptyLayout;

            //case "Demo2":
            //    return typeof(Demo2);

            default:
                return fallbackToDefault ? _options.Layout : MetronicThemeBlazorLayouts.WebApp1Layout;
        }
    }
}