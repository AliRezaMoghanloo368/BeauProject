using AutoMapper;
using BeauProject.Restaurant.Application.DTOs.ModifierGroup.Validator;
using BeauProject.Restaurant.Application.Features.ModifierGroupType.Request.Command;
using BeauProject.Restaurant.Domain.Interfaces;
using BeauProject.Restaurant.Domain.Models.Menu;
using BeauProject.Shared.Patterns.ResultPattern;
using DocumentFormat.OpenXml.Vml.Office;
using FluentValidation;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.ModifierGroupType.Handler.Command
{
    public class CreateAccountSubGroupHandler : IRequestHandler<CreateAccountGroupRequest, Result<bool>>
    {
        private readonly IModifierGroupRepository _repo;
        private readonly IMapper _mapper;
        public CreateAccountSubGroupHandler(IModifierGroupRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<Result<bool>> Handle(CreateAccountGroupRequest request, CancellationToken cancellationToken)
        {
            var valid = new CreateModifierGroupValidator();
            var isValid = await valid.ValidateAsync(request);
            if (!isValid.IsValid)
            {
                return Result<bool>.ErrorResult(isValid.Errors.Select(x => x.ErrorMessage).ToList());
            }

            var entity = _mapper.Map<ModifierGroup>(request.CreateModifierGroupDto);
            entity.Modifiers = request.CreateModifierGroupDto.Modifiers.Select(m => new ModifierItem
            {
                Name = m.Name,
                Price = m.Price,
                TrackInventory = m.TrackInventory
            }).ToList();

            await _repo.Create(entity);
            return Result<bool>.SuccessResult(true);
        }
    }
}
