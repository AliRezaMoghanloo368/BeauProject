using BeauProject.Restaurant.Application.Features.ModifierItemType.Request.Command;
using BeauProject.Restaurant.Application.Features.ModifierItemType.Request.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeauProject.Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModifierItemController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ModifierItemController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateModifierItemRequest request)
        {
            var id = await _mediator.Send(request);
            return Ok(new { Id = id });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _mediator.Send(new GetAllModifierItemRequest());
            return Ok(items);
        }

        [HttpGet("ModifierItem/{id:long}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            var result = await _mediator.Send(new GetModifierItemRequest(id));
            return Ok(result);
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateModifierItemRequest request)
        {
            if (id != request.UpdateModifierItemDto.Id)
                return BadRequest("شناسه ارسالی با بدنه درخواست مطابقت ندارد.");

            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _mediator.Send(new DeleteModifierItemRequest(id));
            if (!result.Success) return BadRequest(new { error = result.Error });
            return NoContent();
        }
    }
}