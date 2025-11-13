using AutoMapper;
using BeauProject.Restaurant.Application.DTOs.Food;
using BeauProject.Restaurant.Application.DTOs.ModifierGroup;
using BeauProject.Restaurant.Application.Features.ModifierGroupType.Request.Query;
using BeauProject.Restaurant.Domain.Interfaces;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.ModifierGroupType.Handler.Query
{
    public class GetAllAccountSubGroupHandler : IRequestHandler<GetAllAccountGroupRequest, Result<IQueryable<ModifierGroupDto>>>
    {
        private readonly IModifierGroupRepository _repo;
        private readonly IMapper _mapper;
        public GetAllAccountSubGroupHandler(IModifierGroupRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Result<IQueryable<ModifierGroupDto>>> Handle(GetAllAccountGroupRequest request, CancellationToken cancellationToken)
        {
            var foods = await _repo.GetAllModifierGroupAsync();

            var dto = _mapper.Map<IQueryable<ModifierGroupDto>>(foods);
            return Result<IQueryable<ModifierGroupDto>>.SuccessResult(dto, "عملیات با موفقیت انجام شد.");
        }
    }
}
