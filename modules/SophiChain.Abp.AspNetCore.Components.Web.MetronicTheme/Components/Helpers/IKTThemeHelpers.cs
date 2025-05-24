namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Helpers
{
    public interface IKTThemeHelpers
    {
        void addBodyAttribute(string attribute, string value);

        void removeBodyAttribute(string attribute);

        void addBodyClass(string className);

        void removeBodyClass(string className);
    }
}
