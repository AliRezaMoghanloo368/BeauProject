using AutoMapper;
using BeauProject.Restaurant.Application.DTOs.ModifierItem;
using BeauProject.Restaurant.Application.Features.ModifierItemType.Request.Query;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.ModifierItemType.Handler.Query
{
    public class GetAllModifierItemHandler : IRequestHandler<GetAllModifierItemRequest, Result<IQueryable<ModifierItemDto>>>
    {
        private readonly IModifierItemRepository _repo;
        private readonly IMapper _mapper;
        public GetAllModifierItemHandler(IModifierItemRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Result<IQueryable<ModifierItemDto>>> Handle(GetAllModifierItemRequest request, CancellationToken cancellationToken)
        {
            var foods = await _repo.GetAllModifierItem();

            var dto = _mapper.Map<IQueryable<ModifierItemDto>>(foods);
            return Result<IQueryable<ModifierItemDto>>.SuccessResult(dto, "عملیات با موفقیت انجام شد.");
        }
    }
}
