using AutoMapper;
using BeauProject.Identity.Application.DTOs.User;
using BeauProject.Identity.Application.Features.UserType.Request.Query;
using BeauProject.Identity.Domain.Interfaces;
using MediatR;

namespace BeauProject.Identity.Application.Features.UserType.Handler.Query
{
    public class GetUserHandler : IRequestHandler<GetUserRequest, GetUserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<GetUserDto> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetWithUserName(request.GetUserDto.UserName);
            if (user == null)
            {
                return new GetUserDto();
            }

            return _mapper.Map<GetUserDto>(user);
        }
    }
}
