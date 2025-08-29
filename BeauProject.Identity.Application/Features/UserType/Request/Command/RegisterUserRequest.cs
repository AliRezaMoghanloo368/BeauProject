using BeauProject.Identity.Application.DTOs.User;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Identity.Application.Features.UserType.Request.Command
{
    public class RegisterUserRequest : IRequest<Result<bool>>
    {
        public CreateUserDto CreateUserDto { get; set; }
    }
}
