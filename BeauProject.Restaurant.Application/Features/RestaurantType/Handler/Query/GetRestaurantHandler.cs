using AutoMapper;
using BeauProject.Restaurant.Application.DTOs.Restaurant;
using BeauProject.Restaurant.Application.Features.RestaurantType.Request.Query;
using BeauProject.Restaurant.Domain.Interfaces;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.RestaurantType.Handler.Query
{
    public class GetRestaurantHandler : IRequestHandler<GetRestaurantRequest, Result<RestaurantDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRestaurantRepository _repo;
        public GetRestaurantHandler(IRestaurantRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Result<RestaurantDto>> Handle(GetRestaurantRequest request, CancellationToken ct)
        {
            var list = await _repo.GetAsync(request.Id);

            if (list is null)
            {
                return new Result<RestaurantDto> { };
            }

            var dto = _mapper.Map<RestaurantDto>(list);
            return Result<RestaurantDto>.SuccessResult(dto);
        }
    }
}
