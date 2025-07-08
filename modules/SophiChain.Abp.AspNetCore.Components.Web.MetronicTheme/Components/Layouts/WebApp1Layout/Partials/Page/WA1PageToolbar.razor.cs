using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Helpers;
using Volo.Abp.AspNetCore.Components.Web.Theming.Layout;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Layouts.WebApp1Layout.Partials.Page;
public partial class WA1PageToolbar
{
    [CascadingParameter(Name = "ThemeState")]
    public ThemeCascadingState ThemeState { get; set; }

    private object _lastProcessedToolbarKey;
    private bool _shouldRenderToolbar;

    protected override void OnInitialized()
    {
        _shouldRenderToolbar = ThemeState?.ShowToolBar ?? false;
    }

    protected override async Task OnInitializedAsync()
    {
        ThemeState.OnStateHasChanged += StateHasChanged;
        await Task.CompletedTask;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (ThemeState?.PageToolbar != null && ThemeState.PageToolbar != _lastProcessedToolbarKey)
        {
            _lastProcessedToolbarKey = ThemeState.PageToolbar;

            var toolbarItems = await PageToolbarManager.GetItemsAsync(ThemeState.PageToolbar);
            ToolbarItemRenders.Clear();

            if (!ShouldRenderToolbarItems(toolbarItems))
            {
                return;
            }

            if (!_shouldRenderToolbar)
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

            StateHasChanged();
        }

        await Task.CompletedTask;
    }
}
