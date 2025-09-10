namespace BeauProject.Identity.Application.DTOs.User
{
    public class CreateUserDto
    {
        public string? FullName { get; set; }
        public string UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
