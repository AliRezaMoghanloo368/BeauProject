using BeauProject.Shared.Application.DTOs.Files;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Shared.Application.Features.FilesType.Request.Command
{
    public class SetFilesRequest : IRequest<Result<bool>>
    {
        public CreateFilesDto CreateFilesDto { get; set; }
    }
}
