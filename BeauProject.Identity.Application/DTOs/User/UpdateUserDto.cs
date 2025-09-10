namespace BeauProject.Identity.Application.DTOs.User
{
    public class UpdateUserDto
    {
        public string Id { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
