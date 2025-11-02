using BeauProject.Restaurant.Application.DTOs.ModifierGroup.Validator;
using BeauProject.Restaurant.Application.Features.ModifierGroupType.Request.Command;
using BeauProject.Restaurant.Domain.Interfaces;
using BeauProject.Restaurant.Domain.Models.Menu;
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

            var entity = await _repo.GetModifierGroupByIdAsync(request.UpdateModifierGroupDto.Id);
            entity.MinSelection= request.UpdateModifierGroupDto.MinSelection;
            entity.MaxSelection = request.UpdateModifierGroupDto.MaxSelection;
            entity.Name = request.UpdateModifierGroupDto.Name;
            entity.MenuItemId = request.UpdateModifierGroupDto.MenuItemId;

            // ساده ترین حالت: حذف همه و اضافه مجدد
            entity.Modifiers.Clear();
            entity.Modifiers = request.UpdateModifierGroupDto.Modifiers.Select(m => new ModifierItem
            {
                Name = m.Name,
                Price = m.Price,
                TrackInventory = m.TrackInventory
            }).ToList();

            await _repo.Update(entity);
            return Result<bool>.SuccessResult(true);
        }
    }
}
