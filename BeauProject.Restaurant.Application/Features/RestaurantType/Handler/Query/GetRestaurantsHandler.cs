using AutoMapper;
using BeauProject.Restaurant.Application.DTOs.Restaurant;
using BeauProject.Restaurant.Application.Features.RestaurantType.Request.Query;
using BeauProject.Restaurant.Domain.Interfaces;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.RestaurantType.Handler.Query
{
    public class GetRestaurantsHandler : IRequestHandler<GetRestaurantsRequest, Result<List<RestaurantDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IRestaurantRepository _repo;
        public GetRestaurantsHandler(IRestaurantRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Result<List<RestaurantDto>>> Handle(GetRestaurantsRequest req, CancellationToken ct)
        {
            var list = await _repo.GetAll();

            if (list is null)
            {
                return new Result<List<RestaurantDto>> { };
            }

            //// filter deleted
            var dtos = list
                .Where(r => !r.IsDeleted)
                .Select(r => new RestaurantDto
                {
                    Id = r.Id,
                    Code = r.Code,
                    Name = r.Name,
                    DefaultCurrency = r.DefaultCurrency,
                    TimeZone = r.TimeZone
                })
                .ToList();

            return Result<List<RestaurantDto>>.SuccessResult(dtos);
        }
    }
}
