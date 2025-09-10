using BeauProject.Identity.Application.DTOs.User;
using BeauProject.Shared.Application.DTOs.Files;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BeauProject.Presentation.Blazor.Components.Pages
{
    public partial class Login
    {
        private byte[]? profileImage;
        private UserDto userDto = new();
        private GetUserDto? user;
        void RegisterPage()
        {
            _navigator.NavigateTo("/register");
        }

        async Task SignIn()
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

        async Task CloseWindow()
        {
            await _js.InvokeVoidAsync("closeWindow");
        }

        async Task LoadProfileImage(KeyboardEventArgs e)
        {
            if (e.Key == "Enter")
            {
                user = await _authService.GetUserAsync(userDto.UserName);
                FilesDto filesDto = new FilesDto() { EntityName = "Users", EntityId = user.Id.ToString() };
                var files = await _filesService.LoadAsync(filesDto);
                if (files != null && files?.Data.Count > 0)
                {
                    foreach (var file in files.Data)
                    {
                        profileImage = file.FileContent;
                    }
                }
                await _js.InvokeVoidAsync("passwordFocus");
            }
        }

        async Task GotoDesktop(KeyboardEventArgs e)
        {
            if (e.Key == "Enter")
            {
                await SignIn();
            }
        }
    }
}
