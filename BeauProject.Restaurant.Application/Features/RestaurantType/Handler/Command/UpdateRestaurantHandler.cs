using AutoMapper;
using BeauProject.Restaurant.Application.DTOs.Restaurant.Validator;
using BeauProject.Restaurant.Application.Features.RestaurantType.Request.Command;
using BeauProject.Restaurant.Domain.Interfaces;
using BeauProject.Restaurant.Domain.Models;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.RestaurantType.Handler.Command
{
    public class UpdateRestaurantHandler : IRequestHandler<UpdateRestaurantCommand, Result<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IRestaurantRepository _repo;
        public UpdateRestaurantHandler(IRestaurantRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Result<bool>> Handle(UpdateRestaurantCommand request, CancellationToken ct)
        {
            var valid = new UpdateRestaurantDtoValidator();
            var branchIsValid = await valid.ValidateAsync(request);
            if (!branchIsValid.IsValid)
            {
                return Result<bool>.ErrorResult(branchIsValid.Errors.Select(x => x.ErrorMessage).ToList());
            }

            var entity = await _repo.GetAsync(request.Id);
            if (entity is null) 
                return Result<bool>.ErrorResult("Restaurant not found.");

            entity.Name = request.Name;
            entity.DefaultCurrency = request.DefaultCurrency;
            entity.TimeZone = request.TimeZone;

            var rest = _mapper.Map<RestaurantEntity>(entity);
            await _repo.Update(entity);
            return Result<bool>.SuccessResult(true);
        }
    }
}
