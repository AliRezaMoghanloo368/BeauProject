using BeauProject.Shared.Application.DTOs.Files;
using BeauProject.Shared.Application.Features.FilesType.Request.Command;
using BeauProject.Shared.Application.Features.FilesType.Request.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeauProject.Shared.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class FilesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FilesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(CreateFilesDto createFilesDto)
        {
            var result = await _mediator.Send(new SetFilesRequest() { CreateFilesDto = createFilesDto });
            return Ok(result);
        }

        [HttpPost("load")]
        public async Task<IActionResult> Load(FilesDto filesDto)
        {
            var result = await _mediator.Send(new GetFilesRequest() { FilesDto = filesDto });
            return Ok(result);
        }
    }
}
