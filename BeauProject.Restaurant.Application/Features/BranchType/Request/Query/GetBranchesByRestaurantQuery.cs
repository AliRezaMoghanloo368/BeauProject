using BeauProject.Restaurant.Application.DTOs.Branch;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.BranchType.Request.Query
{
    public class GetBranchesByRestaurantQuery : IRequest<List<BranchDto>>
    {
        public long RestaurantId { get; set; }
        public GetBranchesByRestaurantQuery(long restaurantId)
        {
            RestaurantId = restaurantId;
        }
    }
}
