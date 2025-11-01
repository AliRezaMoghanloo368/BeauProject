using AutoMapper;
using BeauProject.Restaurant.Application.DTOs.ModifierGroup;
using BeauProject.Restaurant.Application.Features.ModifierGroupType.Request.Query;
using BeauProject.Restaurant.Domain.Interfaces;
using BeauProject.Restaurant.Domain.Models.Menu;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.ModifierGroupType.Handler.Query
{
    public class GetModifierGroupHandler : IRequestHandler<GetModifierGroupRequest, Result<ModifierGroupDto>>
    {
        private readonly IModifierGroupRepository _repo;
        private readonly IMapper _mapper;
        public GetModifierGroupHandler(IModifierGroupRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Result<ModifierGroupDto>> Handle(GetModifierGroupRequest request, CancellationToken cancellationToken)
        {
            var food = await _repo.GetModifierGroupByIdAsync(request.Id);
            if (food == null)
            {
                food = new ModifierGroup();
            }

            var dto = _mapper.Map<ModifierGroupDto>(food);
            return Result<ModifierGroupDto>.SuccessResult(dto, "عملیات با موفقیت انجام شد.");
        }
    }
}
