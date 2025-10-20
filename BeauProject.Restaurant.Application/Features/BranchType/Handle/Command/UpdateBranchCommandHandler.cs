using AutoMapper;
using BeauProject.Restaurant.Application.DTOs.Branch;
using BeauProject.Restaurant.Application.Features.BranchType.Request.Command;
using BeauProject.Restaurant.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BeauProject.Restaurant.Application.Features.BranchType.Handle.Command
{
    public class UpdateBranchCommandHandler : IRequestHandler<UpdateBranchCommand, BranchDto>
    {
        private readonly RestaurantContext _context;
        private readonly IMapper _mapper;

        public UpdateBranchCommandHandler(RestaurantContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BranchDto> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = await _context.Branches
                .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

            if (branch == null)
                throw new KeyNotFoundException($"شعبه با شناسه {request.Id} یافت نشد.");

            // Mapping خودکار مقادیر جدید روی entity موجود
            _mapper.Map(request, branch);

            _context.Branches.Update(branch);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<BranchDto>(branch);
        }
    }
}
