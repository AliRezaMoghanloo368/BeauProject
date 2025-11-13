using AutoMapper;
using BeauProject.Accounting.Application.Features.AccountSubGroupType.Request.Command;
using BeauProject.Accounting.Data.EntityValidator;
using BeauProject.Accounting.Domain.Interfaces;
using BeauProject.Accounting.Domain.Models;
using BeauProject.Shared.Patterns.ResultPattern;
using FluentValidation;
using MediatR;

namespace BeauProject.Accounting.Application.Features.AccountSubGroupType.Handler.Command
{
    public class CreateAccountSubGroupHandler : IRequestHandler<CreateAccountSubGroupRequest, Result<bool>>
    {
        private readonly IAccountSubGroupRepository _repo;
        private readonly IMapper _mapper;
        public CreateAccountSubGroupHandler(IAccountSubGroupRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<Result<bool>> Handle(CreateAccountSubGroupRequest request, CancellationToken cancellationToken)
        {
            var valid = new AccountSubGroupValidator();
            var isValid = await valid.ValidateAsync(request);
            if (!isValid.IsValid)
            {
                return Result<bool>.ErrorResult(isValid.Errors.Select(x => x.ErrorMessage).ToList());
            }

            var entity = _mapper.Map<AccountSubGroup>(request.CreateAccountSubGroupDto);
            entity.Modifiers = request.CreateAccountSubGroupDto.Modifiers.Select(m => new ModifierItem
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
