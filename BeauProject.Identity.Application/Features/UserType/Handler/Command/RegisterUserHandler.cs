using AutoMapper;
using BeauProject.Identity.Application.DTOs.User.Validator;
using BeauProject.Identity.Application.Features.UserType.Request.Command;
using BeauProject.Identity.Domain.Interfaces;
using BeauProject.Identity.Domain.Models;
using BeauProject.Shared.Extensions;
using BeauProject.Shared.Interfaces;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Identity.Application.Features.UserType.Handler.Command
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserRequest, Result<bool>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IEncrypter _encrypter;
        public RegisterUserHandler(IUserRepository userRepository, IMapper mapper, IEncrypter encrypter)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _encrypter = encrypter;
        }
        public async Task<Result<bool>> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            var valid = new CreateUserDtoValidation(_userRepository);
            var userIsValid = await valid.ValidateAsync(request.CreateUserDto);
            if (!userIsValid.IsValid)
            {
                return Result<bool>.ErrorResult(userIsValid.Errors.Select(x => x.ErrorMessage).ToList());
            }

            var userEntity = _mapper.Map<User>(request.CreateUserDto);
            userEntity.Salt = userEntity.Salt.GenerateSalt(_encrypter);
            userEntity.Password = userEntity.Password.HashPassword(userEntity.Salt, _encrypter);
            await _userRepository.Create(userEntity);
            return Result<bool>.SuccessResult(true);
        }
    }
}
