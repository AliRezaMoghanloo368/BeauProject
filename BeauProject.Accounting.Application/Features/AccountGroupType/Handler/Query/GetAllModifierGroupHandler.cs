using AutoMapper;
using BeauProject.Accounting.Domain.Interfaces;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Accounting.Application.Features.AccountGroupType.Handler.Query
{
    public class GetAllAccountSubGroupHandler : IRequestHandler<GetAllAccountGroupRequest, Result<IQueryable<AccountGroupDto>>>
    {
        private readonly IAccountGroupRepository _repo;
        private readonly IMapper _mapper;
        public GetAllAccountSubGroupHandler(IAccountGroupRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Result<IQueryable<AccountGroupDto>>> Handle(GetAllAccountGroupRequest request, CancellationToken cancellationToken)
        {
            var foods = await _repo.GetAllAccountGroupAsync();

            var dto = _mapper.Map<IQueryable<AccountGroupDto>>(foods);
            return Result<IQueryable<AccountGroupDto>>.SuccessResult(dto, "عملیات با موفقیت انجام شد.");
        }
    }
}
