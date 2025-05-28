using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Helpers;
using Volo.Abp.AspNetCore.Components.Web.Theming.Layout;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Layouts.WebApp1Layout.Partials.Page;
public partial class WA1PageToolbar
{
    [CascadingParameter(Name = "ThemeState")]
    public ThemeCascadingState ThemeState { get; set; }

    protected override void OnInitialized()
    {
        if (ThemeState.ShowToolBar)
        {
            Options.Value.RenderToolbar = true;
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            if (ThemeState.PageToolbar != null)
            {
                var toolbarItems = await PageToolbarManager.GetItemsAsync(ThemeState.PageToolbar);
                ToolbarItemRenders.Clear();

                if (!ShouldRenderToolbarItems(toolbarItems))
                {
                    return;
                }

                if (!Options.Value.RenderToolbar)
                {
                    PageLayout.ToolbarItems.Clear();
                    foreach (var item in toolbarItems)
                    {
                        PageLayout.ToolbarItems.Add(item);
                    }
                    return;
                }

                foreach (var item in toolbarItems)
                {
                    var sequence = 0;
                    ToolbarItemRenders.Add(builder =>
                    {
                        builder.OpenComponent(sequence, item.ComponentType);
                        if (item.Arguments != null)
                        {
                            foreach (var argument in item.Arguments)
                            {
                                sequence++;
                                builder.AddAttribute(sequence, argument.Key, argument.Value);
                            }
                        }
                        builder.CloseComponent();
                    });
                }
            }
        }

        await base.OnAfterRenderAsync(firstRender);
    }
}
