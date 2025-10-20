using BeauProject.Restaurant.Application.Features.BranchType.Request.Command;
using BeauProject.Restaurant.Data.Context;
using BeauProject.Restaurant.Domain.Models;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.BranchType.Handle.Command
{
    public class CreateBranchHandler : IRequestHandler<CreateBranchCommand, long>
    {
        private readonly RestaurantContext _context;

        public CreateBranchHandler(RestaurantContext context)
        {
            _context = context;
        }

        public async Task<long> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = new Branch
            {
                RestaurantId = request.RestaurantId,
                Code = request.Code,
                Name = request.Name,
                Locale = request.Locale,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber,
                City = request.City,
                IsMainBranch = request.IsMainBranch
            };

            _context.Branches.Add(branch);
            await _context.SaveChangesAsync(cancellationToken);

            return branch.Id;
        }
    }
}
