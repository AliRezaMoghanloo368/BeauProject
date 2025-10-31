using BeauProject.Restaurant.Application.DTOs.ModifierItem.Validator;
using BeauProject.Restaurant.Application.Features.ModifierItemType.Request.Command;
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

            var entity = await _repo.GetModifierItemAsync(request.UpdateModifierItemDto.Id);
            entity.Currency = request.UpdateModifierItemDto.Currency;
            entity.Price = request.UpdateModifierItemDto.Price;
            entity.Name = request.UpdateModifierItemDto.Name;
            entity.UpdatedAt = DateTime.UtcNow;

            await _repo.Update(entity);
            return Result<bool>.SuccessResult(true);
        }
    }
}
