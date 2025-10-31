using AutoMapper;
using BeauProject.Restaurant.Application.DTOs.ModifierItem.Validator;
using BeauProject.Restaurant.Application.Features.ModifierItemType.Request.Command;
using BeauProject.Restaurant.Domain.Interfaces;
using BeauProject.Restaurant.Domain.Models.Menu;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.ModifierItemType.Handler.Command
{
    public class CreateModifierItemHandler : IRequestHandler<CreateModifierItemRequest, Result<bool>>
    {
        private readonly IFoodItemRepository _repo;
        private readonly IMapper _mapper;
        public CreateModifierItemHandler(IFoodItemRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<Result<bool>> Handle(CreateModifierItemRequest request, CancellationToken cancellationToken)
        {
            var valid = new CreateModifierItemValidator();
            var isValid = await valid.ValidateAsync(request);
            if (!isValid.IsValid)
            {
                return Result<bool>.ErrorResult(isValid.Errors.Select(x => x.ErrorMessage).ToList());
            }

            var entity = _mapper.Map<FoodItem>(request.CreateModifierItemDto);
            await _repo.Create(entity);
            return Result<bool>.SuccessResult(true);
        }
    }
}
