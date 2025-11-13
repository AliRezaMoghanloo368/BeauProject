using AutoMapper;
using BeauProject.Accounting.Domain.Interfaces;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Accounting.Application.Features.AccountSubGroupType.Handler.Query
{
    public class GetAllAccountSubGroupHandler : IRequestHandler<GetAllAccountSubGroupRequest, Result<IQueryable<AccountSubGroupDto>>>
    {
        private readonly IAccountSubGroupRepository _repo;
        private readonly IMapper _mapper;
        public GetAllAccountSubGroupHandler(IAccountSubGroupRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Result<IQueryable<AccountSubGroupDto>>> Handle(GetAllAccountSubGroupRequest request, CancellationToken cancellationToken)
        {
            var foods = await _repo.GetAllAccountSubGroupAsync();

            var dto = _mapper.Map<IQueryable<AccountSubGroupDto>>(foods);
            return Result<IQueryable<AccountSubGroupDto>>.SuccessResult(dto, "عملیات با موفقیت انجام شد.");
        }
    }
}
