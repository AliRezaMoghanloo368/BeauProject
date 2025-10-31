using AutoMapper;
using BeauProject.Restaurant.Application.DTOs.ModifierGroup.Validator;
using BeauProject.Restaurant.Application.Features.ModifierGroupType.Request.Command;
using BeauProject.Restaurant.Domain.Models.Menu;
using BeauProject.Shared.Patterns.ResultPattern;
using FluentValidation;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.ModifierGroupType.Handler.Command
{
    public class CreateModifierGroupHandler : IRequestHandler<CreateModifierGroupRequest, Result<bool>>
    {
        private readonly IModifierGroupRepository _repo;
        private readonly IMapper _mapper;
        public CreateModifierGroupHandler(IModifierGroupRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<Result<bool>> Handle(CreateModifierGroupRequest request, CancellationToken cancellationToken)
        {
            var valid = new CreateModifierGroupValidator();
            var foodsIsValid = await valid.ValidateAsync(request);
            if (!foodsIsValid.IsValid)
            {
                return Result<bool>.ErrorResult(foodsIsValid.Errors.Select(x => x.ErrorMessage).ToList());
            }

            var foodsEntity = _mapper.Map<ModifierGroup>(request.CreateModifierGroupDto);
            await _repo.Create(foodsEntity);
            return Result<bool>.SuccessResult(true);
        }
    }
}
