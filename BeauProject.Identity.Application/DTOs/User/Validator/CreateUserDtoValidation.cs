using BeauProject.Identity.Domain.Interfaces;
using FluentValidation;

namespace BeauProject.Identity.Application.DTOs.User.Validator
{
    public class CreateUserDtoValidation : AbstractValidator<CreateUserDto>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserDtoValidation(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage($"نام و نام خانوادگی نباید خالی باشد! لطفا درانتخاب آن دقت فرمایید.");

            RuleFor(x => x.UserName)
            .MustAsync(async (username, token) =>
            {
                var result = await _userRepository.CheckWithUserName(username);
                return !result;
            }).WithMessage("نام کاربری مورد نظر موجود می باشد.");

            //RuleFor(x => x.Email)
            //    .EmailAddress().WithMessage("ایمیل وارد شده صحیح نمی باشد.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("رمز عبور نباید خالی باشد!");
                //.Matches(@"[A-Z]+").WithMessage("حداقل یک حرف بزرگ می خواهد.")
                //.MinimumLength(6).WithMessage("طول پسورد شما کمتر از 6 کاراکتر می باشد.");
        }
    }
}
