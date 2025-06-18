using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Volo.Abp.AspNetCore.Components.Web.Theming.Toolbars;
using Volo.Abp.MultiTenancy;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Users;
using System.Linq;
using SophiChain.Abp.AspNetCore.Components.Server.MetronicTheme;
using SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Navigation;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Layouts.WebApp1Layout.Partials.Mobile;
public partial class MobileBottomMenu
{
    [Inject] protected IMenuManager MenuManager { get; set; }
    [Inject] protected ICurrentUser CurrentUser { get; set; }
    [Inject] protected MainMenuProvider MainMenuProvider { get; set; }
    [Inject] protected IOptions<MetronicThemeBlazorOptions> Options { get; set; }
    protected ApplicationMenu UserMenu { get; set; }
    protected string ProfileImageUrl { get; set; }
    protected List<MenuItemViewModel> SelectedMenuItems { get; set; } = new();
    protected virtual string LoginLink => "account/login";

    protected override async Task OnInitializedAsync()
    {
        await SetMenuAndProfileAsync();
    }

    protected virtual async Task SetMenuAndProfileAsync()
    {
        UserMenu = await MenuManager.GetAsync(StandardMenus.User);

        var shortcutsMenu = await MainMenuProvider.GetMenuAsync(StandardMenus.Shortcut);

        if(shortcutsMenu.Items.Count > 0)
        {
            SelectedMenuItems = Options.Value.MobileMenuSelector(shortcutsMenu.Items.AsReadOnly()).ToList();
        }

        if (CurrentUser.IsAuthenticated && CurrentUser.Id != null)
        {
            ProfileImageUrl = GetProfilePictureURL(CurrentUser.GetId());
        }
    }

    protected virtual string GetProfilePictureURL(Guid userId)
    {
        return $"api/account/profile-picture-file/{userId}";
    }
}
