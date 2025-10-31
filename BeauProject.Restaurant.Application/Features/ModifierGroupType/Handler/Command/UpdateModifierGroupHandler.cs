using BeauProject.Restaurant.Application.DTOs.ModifierGroup.Validator;
using BeauProject.Restaurant.Application.Features.ModifierGroupType.Request.Command;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.ModifierGroupType.Handler.Command
{
    public class UpdateModifierGroupHandler : IRequestHandler<UpdateModifierGroupRequest, Result<bool>>
    {
        private readonly IModifierGroupRepository _repo;
        public UpdateModifierGroupHandler(IModifierGroupRepository repo) => _repo = repo;

        public async Task<Result<bool>> Handle(UpdateModifierGroupRequest request, CancellationToken cancellationToken)
        {
            var valid = new UpdateModifierGroupValidator();
            var isValid = await valid.ValidateAsync(request);
            if (!isValid.IsValid)
            {
                return Result<bool>.ErrorResult(isValid.Errors.Select(x => x.ErrorMessage).ToList());
            }

            var entity = await _repo.GetModifierGroupAsync(request.UpdateModifierGroupDto.Id);
            entity.Currency = request.UpdateModifierGroupDto.Currency;
            entity.Price = request.UpdateModifierGroupDto.Price;
            entity.Name = request.UpdateModifierGroupDto.Name;
            entity.UpdatedAt = DateTime.UtcNow;

            await _repo.Update(entity);
            return Result<bool>.SuccessResult(true);
        }
    }
}
