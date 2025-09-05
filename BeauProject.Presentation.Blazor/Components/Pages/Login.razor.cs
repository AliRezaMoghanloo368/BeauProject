using BeauProject.Identity.Application.DTOs.User;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace BeauProject.Presentation.Blazor.Components.Pages
{
    public partial class Login
    {
        private UserDto userDto = new();
        private string message = "";
        private async Task SignIn()
        {
            var result = await _authService.LoginAsync(userDto.UserName, userDto.Password);
            if (result)
            {
                _navigator.NavigateTo("/dashboard");
            }
            else
            {
                message = "Invalid username or password.";
            }
        }

        private void OnPasswordClick(MouseEventArgs e)
        {
            _js.InvokeVoidAsync("inputPassword", "txt-password");
        }
    }
}
