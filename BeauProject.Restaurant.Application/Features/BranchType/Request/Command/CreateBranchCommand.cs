using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.BranchType.Request.Command
{
    public class CreateBranchCommand : IRequest<Result<bool>>
    {
        //public CreateBranchDto CreateBranchDto { get; set; }
        public long RestaurantId { get; set; } // FK به Restaurant
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Locale { get; set; } = "fa-IR"; // مثلاً "fa-IR" یا "en-US"
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string City { get; set; } = null!;
        public bool IsMainBranch { get; set; }
    }
}
