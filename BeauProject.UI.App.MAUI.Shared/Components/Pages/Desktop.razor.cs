using Microsoft.JSInterop;

namespace BeauProject.UI.App.MAUI.Shared.Components.Pages
{
    public partial class Desktop
    {
        async Task CloseWindow()
        {
            await _js.InvokeVoidAsync("closeWindow");
        }

    }
}
