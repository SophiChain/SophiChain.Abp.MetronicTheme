using Microsoft.JSInterop;

namespace SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme.Components.Helpers
{
    class KTThemeHelpers : IKTThemeHelpers
    {
        public IJSRuntime _js;

        public KTThemeHelpers(IJSRuntime JS)
        {
            _js = JS;
        }

        public void addBodyAttribute(string attribute, string value)
        {
            _js.InvokeVoidAsync("document.body.setAttribute", attribute, value);
        }

        public void removeBodyAttribute(string attribute)
        {
            _js.InvokeVoidAsync("document.body.classList.removeAttribute", attribute);
        }

        public void addBodyClass(string className)
        {
            _js.InvokeVoidAsync("document.body.classList.add", className);
        }

        public void removeBodyClass(string className)
        {
            _js.InvokeVoidAsync("document.body.classList.remove", className);
        }
    }
}
