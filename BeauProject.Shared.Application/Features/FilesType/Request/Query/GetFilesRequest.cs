using BeauProject.Shared.Application.DTOs.Files;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Shared.Application.Features.FilesType.Request.Query
{
    public class GetFilesRequest : IRequest<Result<string>>
    {
        public FilesDto FilesDto { get; set; }
    }
}
