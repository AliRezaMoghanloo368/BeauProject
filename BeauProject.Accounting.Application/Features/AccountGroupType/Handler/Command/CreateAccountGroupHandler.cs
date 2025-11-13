using AutoMapper;
using BeauProject.Accounting.Application.DTOs.AccountGroup.Validator;
using BeauProject.Accounting.Application.Features.AccountGroupType.Request.Command;
using BeauProject.Accounting.Domain.Interfaces;
using BeauProject.Accounting.Domain.Models;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Accounting.Application.Features.AccountGroupType.Handler.Command
{
    public class CreateAccountGroupHandler : IRequestHandler<CreateAccountGroupRequest, Result<bool>>
    {
        private readonly IAccountGroupRepository _repo;
        private readonly IMapper _mapper;
        public CreateAccountGroupHandler(IAccountGroupRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<Result<bool>> Handle(CreateAccountGroupRequest request, CancellationToken cancellationToken)
        {
            var valid = new CreateAccountGroupValidator();
            var isValid = await valid.ValidateAsync(request);
            if (!isValid.IsValid)
            {
                return Result<bool>.ErrorResult(isValid.Errors.Select(x => x.ErrorMessage).ToList());
            }

            var entity = _mapper.Map<AccountGroup>(request.CreateAccountGroupDto);
            entity.SubGroups = request.CreateAccountGroupDto.SubGroups.Select(m => new AccountSubGroup
            {
                Code = m.Code,
                Title = m.Title,
                IsActive = m.IsActive
            }).ToList();

            await _repo.Create(entity);
            return Result<bool>.SuccessResult(true);
        }
    }
}
