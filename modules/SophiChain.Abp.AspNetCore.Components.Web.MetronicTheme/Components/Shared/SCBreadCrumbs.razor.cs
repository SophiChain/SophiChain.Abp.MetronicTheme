using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Components.Web.Theming.Layout;
using Volo.Abp.BlazoriseUI;
using Volo.Abp.UI.Navigation;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Shared;
public partial class SCBreadCrumbs
{
    [Inject] public IOptions<PageHeaderOptions> Options { get; set; } = default!;
    [Inject] private IMenuManager MenuManager { get; set; }
    [Inject] protected NavigationManager NavigationManager { get; set; }
    [Parameter] public List<BreadcrumbItem> CustomBreadcrumb { get; set; }

    private List<BreadcrumbItem> Breadcrumbs;

    protected override async Task OnInitializedAsync()
    {
        Options.Value.RenderToolbar = true;
        Options.Value.RenderBreadcrumbs = true;

        var menu = await MenuManager.GetMainMenuAsync();
        var currentUrl = NavigationManager.Uri.Replace(NavigationManager.BaseUri, "/");

        Breadcrumbs = await GenerateBreadcrumbs(menu, currentUrl);

        await base.OnInitializedAsync();
    }

    private void OnBreadcrumbItemClick(BreadcrumbItem item)
    {
        NavigationManager.NavigateTo(item.Url, true);
    }

    public async Task<List<BreadcrumbItem>> GenerateBreadcrumbs(ApplicationMenu rootMenu, string currentUrl)
    {
        var breadcrumbs = new List<BreadcrumbItem>();
        await FindBreadcrumbsByUrl(rootMenu, currentUrl, breadcrumbs);
        breadcrumbs.Reverse();
        return breadcrumbs;
    }

    private async Task<bool> FindBreadcrumbsByUrl(ApplicationMenu currentMenu, string currentUrl, List<BreadcrumbItem> breadcrumbs)
    {
        foreach (var item in currentMenu.Items)
        {
            if (item.Url == currentUrl)
            {
                breadcrumbs.Add(new BreadcrumbItem(item.DisplayName, item.Url));
                breadcrumbs.Add(new BreadcrumbItem(currentMenu.DisplayName));
                return true;
            }

            if (!item.IsLeaf && FindBreadcrumbsByUrlInSubItems(item.Items, currentUrl, breadcrumbs))
            {
                breadcrumbs.Add(new BreadcrumbItem(item.DisplayName, item.Url));
                breadcrumbs.Add(new BreadcrumbItem(currentMenu.DisplayName));
                return true;
            }
        }

        foreach (var group in currentMenu.Groups)
        {

            var groupMenu = await MenuManager.GetAsync(group.Name);

            if (await FindBreadcrumbsByUrl(groupMenu, currentUrl, breadcrumbs))
            {
                breadcrumbs.Add(new BreadcrumbItem(currentMenu.DisplayName));
                return true;
            }
        }

        return false;
    }

    private bool FindBreadcrumbsByUrlInSubItems(ApplicationMenuItemList subItems, string currentUrl, List<BreadcrumbItem> breadcrumbs)
    {
        foreach (var subItem in subItems)
        {
            if (subItem.Url == currentUrl)
            {
                breadcrumbs.Add(new BreadcrumbItem(subItem.DisplayName, subItem.Url));
                return true;
            }

            if (!subItem.IsLeaf && FindBreadcrumbsByUrlInSubItems(subItem.Items, currentUrl, breadcrumbs))
            {
                breadcrumbs.Add(new BreadcrumbItem(subItem.DisplayName, subItem.Url));
                return true;
            }
        }
        return false;
    }

    private string GetRelativePath(string uri) =>
        NavigationManager.ToBaseRelativePath(uri).TrimEnd('/');

    private List<BreadcrumbItem> GetProcessedBreadcrumbs()
    {
        var seen = new HashSet<string>();
        var list = new List<BreadcrumbItem>();

        foreach (var bc in Breadcrumbs)
        {
            var text = bc.Text == "Main" ? "خانه" : bc.Text;
            var url = bc.Text == "Main" || string.IsNullOrWhiteSpace(bc.Url) ? "/" : bc.Url;

            var key = $"{text}|{url?.TrimEnd('/')}";

            if (!seen.Contains(key))
            {
                seen.Add(key);
                list.Add(new BreadcrumbItem(text, url));
            }
        }

        return list;
    }
}
