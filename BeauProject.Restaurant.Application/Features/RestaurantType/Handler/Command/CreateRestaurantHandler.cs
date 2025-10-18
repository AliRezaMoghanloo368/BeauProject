using BeauProject.Restaurant.Application.DTOs;
using BeauProject.Restaurant.Application.Features.RestaurantType.Request.Command;
using BeauProject.Restaurant.Domain.Interfaces;
using BeauProject.Restaurant.Domain.Models;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.RestaurantType.Handler.Command
{
    public class CreateRestaurantHandler : IRequestHandler<CreateRestaurantCommand, Result<RestaurantDto>>
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public CreateRestaurantHandler(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<Result<RestaurantDto>> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            // Business rule: unique Code per system
            var existing = await _restaurantRepository.GetByCodeAsync(request.Code, cancellationToken);
            if (existing is not null)
                return Result<RestaurantDto>.ErrorResult($"Restaurant with code '{request.Code}' already exists.");

            var entity = new RestaurantEntity
            {
                Code = request.Code,
                Name = request.Name,
                DefaultCurrency = request.DefaultCurrency,
                TimeZone = request.TimeZone,
                CreatedAt = DateTime.UtcNow
            };

            await _restaurantRepository.AddAsync(entity);
            await _restaurantRepository.SaveChangesAsync(cancellationToken);

            var dto = new RestaurantDto
            {
                Id = entity.Id,
                Code = entity.Code,
                Name = entity.Name,
                DefaultCurrency = entity.DefaultCurrency,
                TimeZone = entity.TimeZone
            };

            return Result<RestaurantDto>.SuccessResult(dto);
        }
    }
}
