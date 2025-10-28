using AutoMapper;
using BeauProject.Restaurant.Application.DTOs.Restaurant.Validator;
using BeauProject.Restaurant.Application.Features.RestaurantType.Request.Command;
using BeauProject.Restaurant.Domain.Interfaces;
using BeauProject.Restaurant.Domain.Models;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.RestaurantType.Handler.Command
{
    public class CreateRestaurantHandler : IRequestHandler<CreateRestaurantCommand, Result<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IRestaurantRepository _repo;
        public CreateRestaurantHandler(IMapper mapper, IRestaurantRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<Result<bool>> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var valid = new CreateRestaurantDtoValidator();
            var branchIsValid = await valid.ValidateAsync(request);
            if (!branchIsValid.IsValid)
            {
                return Result<bool>.ErrorResult(branchIsValid.Errors.Select(x => x.ErrorMessage).ToList());
            }

            var rest = _mapper.Map<RestaurantEntity>(request);
            await _repo.Create(rest);
            return Result<bool>.SuccessResult(true);
        }

        //private readonly IRestaurantRepository _restaurantRepository;
        //public CreateRestaurantHandler(IRestaurantRepository restaurantRepository)
        //{
        //    _restaurantRepository = restaurantRepository;
        //}

        //public async Task<Result<RestaurantDto>> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        //{
        //    // Business rule: unique Code per system
        //    var existing = await _restaurantRepository.GetByCodeAsync(request.Code, cancellationToken);
        //    if (existing is not null)
        //        return Result<RestaurantDto>.ErrorResult($"Restaurant with code '{request.Code}' already exists.");

        //    var entity = new RestaurantEntity
        //    {
        //        Code = request.Code,
        //        Name = request.Name,
        //        DefaultCurrency = request.DefaultCurrency,
        //        TimeZone = request.TimeZone,
        //        CreatedAt = DateTime.UtcNow
        //    };

        //    await _restaurantRepository.Create(entity);

        //    var dto = new RestaurantDto
        //    {
        //        Id = entity.Id,
        //        Code = entity.Code,
        //        Name = entity.Name,
        //        DefaultCurrency = entity.DefaultCurrency,
        //        TimeZone = entity.TimeZone
        //    };

        //    return Result<RestaurantDto>.SuccessResult(dto);
        //}
    }
}
