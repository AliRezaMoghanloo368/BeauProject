using BeauProject.Identity.Application.DTOs.User;
using BeauProject.Identity.Domain.Models;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Identity.Application.Features.UserType.Request.Query
{
    public class GetUserRequest : IRequest<GetUserDto>
    {
        public GetUserDto GetUserDto { get; set; }
    }
}
