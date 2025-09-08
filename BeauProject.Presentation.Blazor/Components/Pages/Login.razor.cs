using BeauComponents.Components.Controls;
using BeauProject.Identity.Application.DTOs.User;
using BeauProject.Shared.Classes;
using Microsoft.JSInterop;

namespace BeauProject.Presentation.Blazor.Components.Pages
{
    public partial class Login
    {
        private string message = "";
        private UserDto userDto = new();
        private void RegisterPage()
        {
            _navigator.NavigateTo("/register");
        }

        private async Task SignIn()
        {
            var result = await _authService.LoginAsync(userDto.UserName, userDto.Password);
            if (result)
            {
                await _js.InvokeVoidAsync("showSnackbar", "خوش آمدید ❤️🌺");
                Thread.Sleep(1000);
                _navigator.NavigateTo("/dashboard");
            }
            else
            {
                await _js.InvokeVoidAsync("showSnackbar", "نام کاربری و رمز عبور نامعتبر است. 😔");
            }
        }

        public async Task CloseWindow()
        {
            await _js.InvokeVoidAsync("closeWindow");
        }
    }
}
