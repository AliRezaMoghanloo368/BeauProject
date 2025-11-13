using AutoMapper;
using BeauProject.Accounting.Domain.Models;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Accounting.Application.Features.AccountSubGroupType.Handler.Query
{
    public class GetAccountSubGroupHandler : IRequestHandler<GetAccountGroupRequest, Result<AccountSubGroupDto>>
    {
        private readonly IAccountSubGroupRepository _repo;
        private readonly IMapper _mapper;
        public GetAccountSubGroupHandler(IAccountSubGroupRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Result<AccountSubGroupDto>> Handle(GetAccountGroupRequest request, CancellationToken cancellationToken)
        {
            var food = await _repo.GetAccountSubGroupByIdAsync(request.Id);
            if (food == null)
            {
                food = new AccountSubGroup();
            }

            var dto = _mapper.Map<AccountSubGroupDto>(food);
            return Result<AccountSubGroupDto>.SuccessResult(dto, "عملیات با موفقیت انجام شد.");
        }
    }
}
