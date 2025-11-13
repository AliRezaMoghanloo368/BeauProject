using AutoMapper;
using BeauProject.Accounting.Application.Features.AccountGroupType.Request.Query;
using BeauProject.Accounting.Domain.Interfaces;
using BeauProject.Accounting.Domain.Models;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Accounting.Application.Features.AccountGroupType.Handler.Query
{
    public class GetAccountSubGroupHandler : IRequestHandler<GetAccountGroupRequest, Result<AccountGroupDto>>
    {
        private readonly IAccountGroupRepository _repo;
        private readonly IMapper _mapper;
        public GetAccountSubGroupHandler(IAccountGroupRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Result<AccountGroupDto>> Handle(GetAccountGroupRequest request, CancellationToken cancellationToken)
        {
            var food = await _repo.GetAccountGroupByIdAsync(request.Id);
            if (food == null)
            {
                food = new AccountGroup();
            }

            var dto = _mapper.Map<AccountGroupDto>(food);
            return Result<AccountGroupDto>.SuccessResult(dto, "عملیات با موفقیت انجام شد.");
        }
    }
}
