using BeauProject.Restaurant.Application.DTOs.ModifierItem.Validator;
using BeauProject.Restaurant.Application.Features.ModifierItemType.Request.Command;
using BeauProject.Restaurant.Domain.Interfaces;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.ModifierItemType.Handler.Command
{
    public class UpdateModifierItemHandler : IRequestHandler<UpdateModifierItemRequest, Result<bool>>
    {
        private readonly IModifierItemRepository _repo;
        public UpdateModifierItemHandler(IModifierItemRepository repo) => _repo = repo;

        public async Task<Result<bool>> Handle(UpdateModifierItemRequest request, CancellationToken cancellationToken)
        {
            var valid = new UpdateModifierItemValidator();
            var isValid = await valid.ValidateAsync(request);
            if (!isValid.IsValid)
            {
                return Result<bool>.ErrorResult(isValid.Errors.Select(x => x.ErrorMessage).ToList());
            }

            var entity = await _repo.GetAsync(request.UpdateModifierItemDto.Id);
            entity.Name = request.UpdateModifierItemDto.Name;
            entity.Price = request.UpdateModifierItemDto.Price;
            entity.TrackInventory = request.UpdateModifierItemDto.TrackInventory;
            entity.GroupId = request.UpdateModifierItemDto.GroupId;

            await _repo.Update(entity);
            return Result<bool>.SuccessResult(true);
        }
    }
}
