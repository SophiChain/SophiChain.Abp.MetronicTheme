using Volo.Abp.DependencyInjection;

namespace SophiChainThemeDemo.Components
{
    public class ReportFiltersHelper : IScopedDependency
    {
        public int NumTest { get; set; }

        public event Action OnStateHasChanged;

        public void NotifyStateChanged(int navigationType = 0)
        {
            OnStateHasChanged?.Invoke();
        }
    }
}
