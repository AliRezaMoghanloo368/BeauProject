using BeauProject.Accounting.Application.Features.AccountGroupType.Request.Command;
using BeauProject.Accounting.Domain.Interfaces;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Accounting.Application.Features.AccountGroupType.Handler.Command
{
    public class UpdateAccountSubGroupHandler : IRequestHandler<UpdateAccountGroupRequest, Result<bool>>
    {
        private readonly IAccountGroupRepository _repo;
        public UpdateAccountSubGroupHandler(IAccountGroupRepository repo) => _repo = repo;

        public async Task<Result<bool>> Handle(UpdateAccountGroupRequest request, CancellationToken cancellationToken)
        {
            var valid = new UpdateAccountGroupValidator();
            var isValid = await valid.ValidateAsync(request);
            if (!isValid.IsValid)
            {
                return Result<bool>.ErrorResult(isValid.Errors.Select(x => x.ErrorMessage).ToList());
            }

            var entity = await _repo.GetAccountGroupByIdAsync(request.UpdateAccountGroupDto.Id);
            entity.MinSelection = request.UpdateAccountGroupDto.MinSelection;
            entity.MaxSelection = request.UpdateAccountGroupDto.MaxSelection;
            entity.Name = request.UpdateAccountGroupDto.Name;
            entity.MenuItemId = request.UpdateAccountGroupDto.MenuItemId;

            // ساده ترین حالت: حذف همه و اضافه مجدد
            entity.Modifiers.Clear();
            entity.Modifiers = request.UpdateAccountGroupDto.Modifiers.Select(m => new ModifierItem
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
