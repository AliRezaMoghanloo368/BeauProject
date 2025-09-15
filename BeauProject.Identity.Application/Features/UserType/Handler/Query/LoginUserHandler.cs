using BeauProject.Identity.Application.Features.UserType.Request.Query;
using BeauProject.Identity.Application.Interfaces;
using BeauProject.Identity.Domain.Interfaces;
using BeauProject.Shared.Application.Interfaces;
using BeauProject.Shared.Data.Services;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace BeauProject.Identity.Application.Features.UserType.Handler.Query
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, Result<string>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IEncrypter _encrypter;
        private readonly IJwtHandler _jwtHandler;
        public LoginUserHandler(IUserRepository userRepository, IConfiguration configuration
            , IEncrypter encrypter, IJwtHandler jwtHandler)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _encrypter = encrypter;
            _jwtHandler = jwtHandler;
        }

        public async Task<Result<string>> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetWithUserName(request.UserDto.UserName);
            if (user == null)
            {
                return Result<string>.ErrorResult("Error");
            }

            var userPassword = request.UserDto.Password.HashPassword(user.Salt, _encrypter);
            if (!user.Password.Equals(userPassword))
            {
                return Result<string>.ErrorResult("Error");
            }

            var token = _jwtHandler.CreateToken(user);
            return Result<string>.SuccessResult(token);
        }
    }
}
