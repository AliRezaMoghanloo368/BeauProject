using AutoMapper;
using BeauProject.Restaurant.Application.DTOs.ModifierItem;
using BeauProject.Restaurant.Application.Features.ModifierItemType.Request.Query;
using BeauProject.Restaurant.Domain.Models.Menu;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.ModifierItemType.Handler.Query
{
    public class GetModifierItemHandler : IRequestHandler<GetModifierItemRequest, Result<ModifierItemDto>>
    {
        private readonly IModifierItemRepository _repo;
        private readonly IMapper _mapper;
        public GetModifierItemHandler(IModifierItemRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Result<ModifierItemDto>> Handle(GetModifierItemRequest request, CancellationToken cancellationToken)
        {
            var food = await _repo.GetModifierItemAsync(request.Id);
            if (food == null)
            {
                food = new ModifierItem();
            }

            var dto = _mapper.Map<ModifierItemDto>(food);
            return Result<ModifierItemDto>.SuccessResult(dto, "عملیات با موفقیت انجام شد.");
        }
    }
}
