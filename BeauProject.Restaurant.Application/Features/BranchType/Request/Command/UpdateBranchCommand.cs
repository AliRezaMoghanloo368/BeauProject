﻿using BeauProject.Restaurant.Application.DTOs.Branch;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.BranchType.Request.Command
{
    public class UpdateBranchCommand : IRequest<BranchDto>
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Locale { get; set; } = "fa-IR"; // مثلاً "fa-IR" یا "en-US"
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string City { get; set; } = null!;
        public bool IsMainBranch { get; set; }
    }
}
