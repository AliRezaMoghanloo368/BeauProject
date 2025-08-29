using BeauProject.Identity.Application.DTOs.User;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Identity.Application.Features.UserType.Request.Query
{
    public class LoginUserRequest : IRequest<Result<string>>
    {
        public UserDto UserDto { get; set; }
    }
}
