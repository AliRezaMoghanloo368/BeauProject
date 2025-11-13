using BeauProject.Accounting.Application.Features.AccountSubGroupType.Request.Command;
using BeauProject.Accounting.Domain.Interfaces;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Accounting.Application.Features.AccountSubGroupType.Handler.Command
{
    public class DeleteAccountSubGroupHandler : IRequestHandler<DeleteAccountSubGroupRequest, Result<bool>>
    {
        private readonly IAccountSubGroupRepository _repo;
        public DeleteAccountSubGroupHandler(IAccountSubGroupRepository repo) => _repo = repo;

        public async Task<Result<bool>> Handle(DeleteAccountSubGroupRequest request, CancellationToken cancellationToken)
        {
            var entity = await _repo.GetAsync(request.Id);
            if (entity == null)
            {
                return Result<bool>.ErrorResult("غذای مورد نظر یافت نشد!");
            }

            await _repo.Delete(entity);
            return Result<bool>.SuccessResult(true, "عملیات حذف انجام شد.");
        }
    }
}
