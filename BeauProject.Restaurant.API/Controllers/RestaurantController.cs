using BeauProject.Restaurant.Application.Features.RestaurantType.Request.Command;
using BeauProject.Restaurant.Application.Features.RestaurantType.Request.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeauProject.Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RestaurantController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRestaurantCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.Success) return BadRequest(new { error = result.Error });
            // Return 201 + location header
            //var dto = result.Data!;
            //return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
            return Ok(result);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _mediator.Send(new GetRestaurantRequest { Id = id });
            if (!result.Success) return NotFound(new { error = result.Error });
            return Ok(result.Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetRestaurantsRequest());
            return Ok(result.Data);
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateRestaurantCommand command)
        {
            if (id != command.Id) return BadRequest();
            var result = await _mediator.Send(command);
            if (!result.Success) return BadRequest(new { error = result.Error });
            return NoContent();
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _mediator.Send(new DeleteRestaurantCommand(id));
            if (!result.Success) return BadRequest(new { error = result.Error });
            return NoContent();
        }
    }
}

//{
//        "id": 1,
//        "code": "R001",
//        "name": "BeauRestaurant",
//        "defaultCurrency": "IRR",
//        "timeZone": "Asia/Tehran"
//}