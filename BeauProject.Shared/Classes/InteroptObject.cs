using Microsoft.JSInterop;

namespace BeauProject.Shared.Classes
{
    public class InteroptObject
    {
        IJSRuntime _runtime { get; set; }
        public InteroptObject(IJSRuntime runtime) => _runtime = runtime;

        [JSInvokable]
        public bool SuccessDelete()
        {
            return true;
        }

        public void Show(string objectId)
        {
            _runtime.InvokeAsync<bool>("show", objectId);
        }

        public void Hide(string objectId)
        {
            _runtime.InvokeAsync<bool>("hide", objectId);
        }
    }
}
