using Microsoft.JSInterop;

namespace BeauProject.Presentation.Blazor.Components.Pages
{
    public partial class Desktop
    {
        async Task CloseWindow()
        {
            await _js.InvokeVoidAsync("closeWindow");
        }

    }
}
