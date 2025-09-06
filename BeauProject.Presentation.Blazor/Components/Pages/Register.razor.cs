using BeauProject.Identity.Application.DTOs.User;
using Microsoft.JSInterop;

namespace BeauProject.Presentation.Blazor.Components.Pages
{
    public partial class Register
    {
        private CreateUserDto createUserDto = new();
        private string message = "";
        private async Task RegisterUser()
        {
            var result = await _authService.RegisterAsync(createUserDto);
            if (result)
            {
                _navigator.NavigateTo("/dashboard");
            }
            else
            {
                message = "Invalid username or password.";
            }
        }

        async Task SignInPage()
        {
            _navigator.NavigateTo("/login");
        }

        async Task CloseWindow()
        {
            await _js.InvokeVoidAsync("closeWindow");
        }
    }
}
