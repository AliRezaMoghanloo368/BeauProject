using BeauProject.Shared.Application.Interfaces;
using BeauProject.Shared.Domain.Interfaces;
using FluentValidation;

namespace BeauProject.Shared.Application.DTOs.Files.Validator
{
    public class CreateFilesDtoValidation : AbstractValidator<CreateFilesDto>
    {
        private readonly IFilesRepository _filesRepository;
        public CreateFilesDtoValidation(IFilesRepository filesRepository)
        {
            _filesRepository = filesRepository;

            //RuleFor(x => x.FullName)
            //    .NotEmpty().WithMessage("نام نباید خالی باشد!");

            //RuleFor(x => x.FilesName)
            //.MustAsync(async (filesname, token) =>
            //{
            //    var result = await _filesRepository.CheckWithFilesName(filesname);
            //    return !result;
            //}).WithMessage("نام کاربری مورد نظر موجود می باشد.");

            //RuleFor(x => x.Email)
            //    .EmailAddress().WithMessage("ایمیل وارد شده صحیح نمی باشد.");

            //RuleFor(x => x.Password)
            //    .NotEmpty().WithMessage("نباید خالی باشد!");
            //.Matches(@"[A-Z]+").WithMessage("حداقل یک حرف بزرگ می خواهد.")
            //.MinimumLength(6).WithMessage("طول پسورد شما کمتر از 6 کاراکتر می باشد.");
        }
    }
}
