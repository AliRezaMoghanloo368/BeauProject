using AutoMapper;
using BeauProject.Restaurant.Application.DTOs.Branch;
using BeauProject.Restaurant.Application.Features.BranchType.Request.Query;
using BeauProject.Restaurant.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BeauProject.Restaurant.Application.Features.BranchType.Handle.Query
{
    public class GetBranchesByRestaurantQueryHandler
        : IRequestHandler<GetBranchesByRestaurantQuery, List<BranchDto>>
    {
        private readonly RestaurantContext _context;
        private readonly IMapper _mapper;
        public GetBranchesByRestaurantQueryHandler(RestaurantContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BranchDto>> Handle(GetBranchesByRestaurantQuery request, CancellationToken cancellationToken)
        {
            var branches = await _context.Branches
                .Where(b => b.RestaurantId == request.RestaurantId)
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<BranchDto>>(branches);
        }
    }
}
