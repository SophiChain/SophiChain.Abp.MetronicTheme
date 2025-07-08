using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Components.Web.Theming.PageToolbars;
using Volo.Abp.BlazoriseUI;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Helpers
{
    public class ThemeCascadingState
    {
        private string _pageMenuName = string.Empty;
        private string _title = string.Empty;
        private bool _showToolBar = true;
        private bool _showTitle = true;
        private bool _showBreadCrumb = true;
        private List<BreadcrumbItem> _customBreadcrumb = new();
        private PageToolbar _pageToolbar = new();

        public string PageMenuName 
        { 
            get => _pageMenuName;
            set
            {
                if (_pageMenuName != value)
                {
                    _pageMenuName = value ?? string.Empty;
                    NotifyStateChanged();
                }
            }
        }

        public string Title 
        { 
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value ?? string.Empty;
                    NotifyStateChanged();
                }
            }
        }

        public bool ShowToolBar 
        { 
            get => _showToolBar;
            set
            {
                if (_showToolBar != value)
                {
                    _showToolBar = value;
                    NotifyStateChanged();
                }
            }
        }

        public bool ShowTitle 
        { 
            get => _showTitle;
            set
            {
                if (_showTitle != value)
                {
                    _showTitle = value;
                    NotifyStateChanged();
                }
            }
        }

        public bool ShowBreadCrumb 
        { 
            get => _showBreadCrumb;
            set
            {
                if (_showBreadCrumb != value)
                {
                    _showBreadCrumb = value;
                    NotifyStateChanged();
                }
            }
        }

        public List<BreadcrumbItem> CustomBreadcrumb 
        { 
            get => _customBreadcrumb;
            set
            {
                _customBreadcrumb = value ?? new List<BreadcrumbItem>();
                NotifyStateChanged();
            }
        }

        public PageToolbar PageToolbar 
        { 
            get => _pageToolbar;
            set
            {
                _pageToolbar = value ?? new PageToolbar();
                NotifyStateChanged();
            }
        }

        public event Action OnStateHasChanged;

        public void NotifyStateChanged(int navigationType = 0)
        {
            OnStateHasChanged?.Invoke();
        }
    }
}
