using AutoMapper;
using BeauProject.Shared.Application.Features.FilesType.Request.Command;
using BeauProject.Shared.Domain.Interfaces;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Shared.Application.Features.FilesType.Handler.Command
{
    public class SetFilesHandler : IRequestHandler<SetFilesRequest, Result<bool>>
    {
        private readonly IFilesRepository _filesRepository;
        private readonly IMapper _mapper;
        public SetFilesHandler(IFilesRepository filesRepository, IMapper mapper)
        {
            _filesRepository = filesRepository;
            _mapper = mapper;
        }
        public async Task<Result<bool>> Handle(SetFilesRequest request, CancellationToken cancellationToken)
        {
            //var valid = new CreateFilesDtoValidation(_filesRepository);
            //var filesIsValid = await valid.ValidateAsync(request.CreateFilesDto);
            //if (!filesIsValid.IsValid)
            //{
            //    return Result<bool>.ErrorResult(filesIsValid.Errors.Select(x => x.ErrorMessage).ToList());
            //}

            //var filesEntity = _mapper.Map<Files>(request.CreateFilesDto);
            //filesEntity.Salt = filesEntity.Salt.GenerateSalt(_encrypter);
            //filesEntity.Password = filesEntity.Password.HashPassword(filesEntity.Salt, _encrypter);
            //await _filesRepository.Create(filesEntity);
            return Result<bool>.SuccessResult(true);
        }
    }
}
