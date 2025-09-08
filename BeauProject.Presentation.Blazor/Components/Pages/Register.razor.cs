using BeauProject.Identity.Application.DTOs.User;
using BeauProject.Shared.Classes;
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
                Variables.SnackbarMessage = "ثبت نام با موفقیت انجام شد. 👍";
                _navigator.NavigateTo("/dashboard");
            }
            else
            {
                Variables.SnackbarMessage = "نام کاربری و رمز عبور نامعتبر است. 😔";
                await _js.InvokeVoidAsync("showSnackbar");
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
