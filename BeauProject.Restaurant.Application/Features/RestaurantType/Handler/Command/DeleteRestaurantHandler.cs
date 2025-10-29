using BeauProject.Restaurant.Application.Features.RestaurantType.Request.Command;
using BeauProject.Restaurant.Domain.Interfaces;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.RestaurantType.Handler.Command
{
    public class DeleteRestaurantHandler : IRequestHandler<DeleteRestaurantCommand, Result<bool>>
    {
        private readonly IRestaurantRepository _repo;
        public DeleteRestaurantHandler(IRestaurantRepository repo) => _repo = repo;

        public async Task<Result<bool>> Handle(DeleteRestaurantCommand request, CancellationToken ct)
        {
            var entity = await _repo.GetAsync(request.Id);
            if (entity is null) return Result<bool>.ErrorResult("Restaurant not found.");
            entity.IsDeleted = true;
            entity.UpdatedAt = DateTime.UtcNow;
            await _repo.Update(entity);
            return Result<bool>.SuccessResult(true);
        }
    }
}
