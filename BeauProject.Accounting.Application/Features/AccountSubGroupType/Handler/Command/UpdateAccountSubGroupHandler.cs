using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Accounting.Application.Features.AccountSubGroupType.Handler.Command
{
    public class UpdateAccountSubGroupHandler : IRequestHandler<UpdateAccountSubGroupRequest, Result<bool>>
    {
        private readonly IAccountSubGroupRepository _repo;
        public UpdateAccountSubGroupHandler(IAccountSubGroupRepository repo) => _repo = repo;

        public async Task<Result<bool>> Handle(UpdateAccountGroupRequest request, CancellationToken cancellationToken)
        {
            var valid = new UpdateAccountSubGroupValidator();
            var isValid = await valid.ValidateAsync(request);
            if (!isValid.IsValid)
            {
                return Result<bool>.ErrorResult(isValid.Errors.Select(x => x.ErrorMessage).ToList());
            }

            var entity = await _repo.GetAccountSubGroupByIdAsync(request.UpdateAccountSubGroupDto.Id);
            entity.MinSelection = request.UpdateAccountSubGroupDto.MinSelection;
            entity.MaxSelection = request.UpdateAccountSubGroupDto.MaxSelection;
            entity.Name = request.UpdateAccountSubGroupDto.Name;
            entity.MenuItemId = request.UpdateAccountSubGroupDto.MenuItemId;

            // ساده ترین حالت: حذف همه و اضافه مجدد
            entity.Modifiers.Clear();
            entity.Modifiers = request.UpdateAccountSubGroupDto.Modifiers.Select(m => new ModifierItem
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
