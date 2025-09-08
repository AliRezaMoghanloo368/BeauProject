using BeauProject.Shared.Application.Features.FilesType.Request.Query;
using BeauProject.Shared.Domain.Interfaces;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace BeauProject.Shared.Application.Features.FilesType.Handler.Query
{
    public class GetFilesHandler : IRequestHandler<GetFilesRequest, Result<string>>
    {
        private readonly IFilesRepository _filesRepository;
        private readonly IConfiguration _configuration;
        public GetFilesHandler(IFilesRepository filesRepository, IConfiguration configuration)
        {
            _filesRepository = filesRepository;
            _configuration = configuration;
        }

        public async Task<Result<string>> Handle(GetFilesRequest request, CancellationToken cancellationToken)
        {
            //var files = await _filesRepository.GetWithFilesName(request.FilesDto.FilesName);
            //if (files == null)
            //{
            //    return Result<string>.ErrorResult("Error");
            //}

            //var filesPassword = request.FilesDto.Password.HashPassword(files.Salt, _encrypter);
            //if (!files.Password.Equals(filesPassword))
            //{
            //    return Result<string>.ErrorResult("Error");
            //}

            //var token = _jwtHandler.CreateToken(files);
            return Result<string>.SuccessResult("");
        }
    }
}
