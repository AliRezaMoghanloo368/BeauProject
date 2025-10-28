using AutoMapper;
using BeauProject.Restaurant.Application.DTOs.Branch.Validator;
using BeauProject.Restaurant.Application.Features.BranchType.Request.Command;
using BeauProject.Restaurant.Domain.Interfaces;
using BeauProject.Restaurant.Domain.Models;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.BranchType.Handle.Command
{
    public class CreateBranchHandler : IRequestHandler<CreateBranchCommand, Result<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IBranchRepository _repo;
        public CreateBranchHandler(IMapper mapper, IBranchRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<Result<bool>> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            var valid = new CreateBranchValidator();
            var branchIsValid = await valid.ValidateAsync(request);
            if (!branchIsValid.IsValid)
            {
                return Result<bool>.ErrorResult(branchIsValid.Errors.Select(x => x.ErrorMessage).ToList());
            }

            var branch = _mapper.Map<Branch>(request);
            await _repo.Create(branch);
            return Result<bool>.SuccessResult(true);
        }
    }
}
