using AutoMapper;
using BeauProject.Restaurant.Application.DTOs.Branch.Validator;
using BeauProject.Restaurant.Application.Features.BranchType.Request.Command;
using BeauProject.Restaurant.Domain.Interfaces;
using BeauProject.Restaurant.Domain.Models;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.BranchType.Handle.Command
{
    public class UpdateBranchHandler : IRequestHandler<UpdateBranchCommand, Result<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IBranchRepository _repo;
        public UpdateBranchHandler(IBranchRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Result<bool>> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
        {
            var valid = new UpdateBranchValidator();
            var branchIsValid = await valid.ValidateAsync(request);
            if (!branchIsValid.IsValid)
            {
                return Result<bool>.ErrorResult(branchIsValid.Errors.Select(x => x.ErrorMessage).ToList());
            }

            var entity = await _repo.GetAsync(request.Id);
            if (entity is null)
                return Result<bool>.ErrorResult("Branch not found.");

            entity.Name = request.Name;
            entity.Address = request.Address;
            entity.City = request.City;
            entity.IsMainBranch = request.IsMainBranch;
            entity.PhoneNumber = request.PhoneNumber;
            entity.Locale = request.Locale;

            var rest = _mapper.Map<Branch>(entity);
            await _repo.Update(entity);
            return Result<bool>.SuccessResult(true);
        }
    }
}
