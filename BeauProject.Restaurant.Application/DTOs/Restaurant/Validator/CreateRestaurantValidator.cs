using BeauProject.Restaurant.Application.Features.RestaurantType.Request.Command;
using FluentValidation;

namespace BeauProject.Restaurant.Application.DTOs.Restaurant.Validator
{
    public class CreateRestaurantValidator : AbstractValidator<CreateRestaurantCommand>
    {
        public CreateRestaurantValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("کد رستوران نمی‌تواند خالی باشد.")
                .MaximumLength(50);

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("نام رستوران لازم است.")
                .MaximumLength(200);

            RuleFor(x => x.DefaultCurrency)
                .NotEmpty().WithMessage("واحد پول لازم است.")
                .Length(3).WithMessage("کد ارز باید 3 حرفی ISO 4217 باشد.");
        }
    }
}
