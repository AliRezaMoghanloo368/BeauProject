using BeauProject.Identity.Application.DTOs.User;
using BeauProject.Identity.Domain.Models;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Identity.Application.Features.UserType.Request.Command
{
    public class RegisterUserRequest : IRequest<Result<User>>
    {
        public CreateUserDto CreateUserDto { get; set; }
    }
}
