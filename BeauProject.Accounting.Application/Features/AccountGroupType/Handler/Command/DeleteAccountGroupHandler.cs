using BeauProject.Accounting.Application.Features.AccountGroupType.Request.Command;
using BeauProject.Accounting.Domain.Interfaces;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Accounting.Application.Features.AccountGroupType.Handler.Command
{
    public class DeleteAccountSubGroupHandler : IRequestHandler<DeleteAccountGroupRequest, Result<bool>>
    {
        private readonly IAccountGroupRepository _repo;
        public DeleteAccountSubGroupHandler(IAccountGroupRepository repo) => _repo = repo;

        public async Task<Result<bool>> Handle(DeleteAccountGroupRequest request, CancellationToken cancellationToken)
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
