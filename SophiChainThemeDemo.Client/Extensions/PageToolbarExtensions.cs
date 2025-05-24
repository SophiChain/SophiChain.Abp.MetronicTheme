using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Telerik.Blazor.Components;
using Volo.Abp.AspNetCore.Components.Web.Theming.PageToolbars;
using SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Shared;

namespace SophiChainThemeDemo.Extensions
{
    public static class PageToolbarExtensions
    {
        public static PageToolbar AddTelerikButton(this PageToolbar toolbar, string title, Func<Task> clicked, object icon = null, string color = null, bool enabled = true, int order = 0, string requiredPolicyName = null)
        {
            RenderFragment value = delegate (RenderTreeBuilder builder)
            {
                builder.AddContent(0, title);
            };
            toolbar.AddComponent<TelerikButton>(new Dictionary<string, object>
            {
                {
                    "ThemeColor",
                    color ?? "primary"
                },
                { "Title", title },
                { "Enabled", enabled },
                { "Icon", icon },
                {
                    "OnClick",
                    EventCallback.Factory.Create<MouseEventArgs>(toolbar, clicked)
                },
                { "ChildContent", value }
            }, order, requiredPolicyName);
            return toolbar;
        }

        public static PageToolbar AddTelerikDropDownButton(this PageToolbar toolbar, string title, List<(string Icon, string Text, Func<Task> ItemClicked)> items, object icon = null, string color = null, bool enabled = true, int order = 0, string requiredPolicyName = null)
        {
            RenderFragment value = delegate (RenderTreeBuilder builder)
            {
                builder.AddContent(0, title);
            };
            RenderFragment value2 = delegate (RenderTreeBuilder builder)
            {
                foreach (var item in items)
                {
                    RenderFragment value3 = delegate (RenderTreeBuilder builder)
                    {
                        builder.AddContent(0, item.Text);
                    };
                    builder.OpenComponent<DropDownButtonItem>(0);
                    builder.AddComponentParameter(1, "Icon", item.Icon);
                    builder.AddComponentParameter(2, "OnClick", EventCallback.Factory.Create<MouseEventArgs>(toolbar, item.ItemClicked));
                    builder.AddComponentParameter(3, "ChildContent", value3);
                    builder.CloseComponent();
                }
            };
            toolbar.AddComponent<TelerikDropDownButton>(new Dictionary<string, object>
            {
                {
                    "ThemeColor",
                    color ?? "primary"
                },
                { "Title", title },
                { "Enabled", enabled },
                { "Icon", icon },
                { "DropDownButtonContent", value },
                { "DropDownButtonItems", value2 }
            }, order, requiredPolicyName);
            return toolbar;
        }

        public static PageToolbar AddTPMButton(this PageToolbar toolbar, string title, object icon = null, string color = null, string id = null, Func<Task> clicked = null, bool enabled = true, int order = 0, string href = null)
        {
            RenderFragment value = delegate (RenderTreeBuilder builder)
            {
                builder.AddContent(0, title);
            };

            toolbar.AddComponent<SCButton>(new Dictionary<string, object>
            {
                {
                    "ThemeColor",
                    color ?? "primary"
                },
                { "Title", title },
                { "Enabled", enabled },
                { "Icon", icon },
                { "Id", id },
                { "Href", href },
                {
                    "OnClick",
                    EventCallback.Factory.Create<MouseEventArgs>(toolbar, clicked)
                },
                { "ChildContent", value }
            }, order);
            return toolbar;
        }
    }
}
