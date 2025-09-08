using BeauProject.Identity.Application.DTOs.User;
using Microsoft.JSInterop;

namespace BeauProject.Presentation.Blazor.Components.Pages
{
    public partial class Register
    {
        private CreateUserDto createUserDto = new();
        private async Task RegisterUser()
        {
            var result = await _authService.RegisterAsync(createUserDto);
            if (result.Data)
            {
                await _js.InvokeVoidAsync("showSnackbar", "ثبت نام با موفقیت انجام شد. 👍");
                Thread.Sleep(1000);
                await _authService.LoginAsync(createUserDto.UserName, createUserDto.Password);
                _navigator.NavigateTo("/dashboard");
            }
            else
            {
                string text;
                if (result.Error.Count == 0 || result == null)
                    text = "نام کاربری و رمز عبور نامعتبر است. 😔";
                else
                    text = $"{result.Error[0]} ⛔";
                await _js.InvokeVoidAsync("showSnackbar", text);
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
