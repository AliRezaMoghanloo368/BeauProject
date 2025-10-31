using AutoMapper;
using BeauProject.Restaurant.Application.DTOs.Food;
using BeauProject.Restaurant.Application.DTOs.ModifierGroup;
using BeauProject.Restaurant.Application.Features.ModifierGroupType.Request.Query;
using BeauProject.Restaurant.Domain.Interfaces;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.ModifierGroupType.Handler.Query
{
    public class GetAllModifierGroupHandler : IRequestHandler<GetAllModifierGroupRequest, Result<IQueryable<ModifierGroupDto>>>
    {
        private readonly IModifierGroupRepository _repo;
        private readonly IMapper _mapper;
        public GetAllModifierGroupHandler(IModifierGroupRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Result<IQueryable<ModifierGroupDto>>> Handle(GetAllModifierGroupRequest request, CancellationToken cancellationToken)
        {
            var foods = await _repo.GetAllModifierGroup();
            //var foodDto = foods.Select(x => new ModifierGroupDto
            //{
            //    Name = x.Name,
            //    Description = x.Description,
            //    Id = x.Id,
            //    Calories = x.Calories,
            //    CategoryId = x.CategoryId,
            //    Currency = x.Currency,
            //    IsAvailable = x.IsAvailable,
            //    Price = x.Price,   
            //});

            var dto = _mapper.Map<IQueryable<ModifierGroupDto>>(foods);
            return Result<IQueryable<ModifierGroupDto>>.SuccessResult(dto, "عملیات با موفقیت انجام شد.");
        }
    }
}
