using BeauProject.Shared.Application.Features.FilesType.Request.Query;
using BeauProject.Shared.Application.Interfaces;
using BeauProject.Shared.Domain.Models;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Shared.Application.Features.FilesType.Handler.Query
{
    public class GetFilesHandler : IRequestHandler<GetFilesRequest, Result<List<Files>>>
    {
        private readonly IFilesRepository _filesRepository;
        public GetFilesHandler(IFilesRepository filesRepository)
        {
            _filesRepository = filesRepository;
        }

        public async Task<Result<List<Files>>> Handle(GetFilesRequest request, CancellationToken cancellationToken)
        {
            var files = await _filesRepository.GetFilesAsync(request.FilesDto.EntityName, request.FilesDto.EntityId);
            if (files == null)
            {
                return Result<List<Files>>.ErrorResult("Error");
            }

            return Result<List<Files>>.SuccessResult(files);
        }
    }
}
