using BeauProject.Identity.Application.DTOs.User;

namespace BeauProject.Presentation.Shared.Pages
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
    }
}
