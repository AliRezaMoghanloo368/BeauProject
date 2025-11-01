using BeauProject.Restaurant.Application.Features.FoodItemsType.Request.Command;
using BeauProject.Restaurant.Application.Features.FoodItemsType.Request.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeauProject.Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodItemController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FoodItemController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFoodItemRequest request)
        {
            var id = await _mediator.Send(request);
            return Ok(new { Id = id });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _mediator.Send(new GetAllFoodItemRequest());
            return Ok(items);
        }

        [HttpGet("foodItem/{id:long}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            var result = await _mediator.Send(new GetFoodItemRequest(id));
            return Ok(result);
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateFoodItemRequest request)
        {
            if (id != request.UpdateFoodItemDto.Id)
                return BadRequest("شناسه ارسالی با بدنه درخواست مطابقت ندارد.");

            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _mediator.Send(new DeleteFoodItemRequest(id));
            if (!result.Success) return BadRequest(new { error = result.Error });
            return NoContent();
        }
    }
}

//{
//    "CreateFoodItemDto": {
//        "id": 1,
//        "categoryId": 1,
//        "restaurantId": 1,
//        "name": "Test Pizza",
//        "description": "Delicious test pizza",
//        "price": 100000,
//        "currency": "IRR",
//        "isAvailable": true,
//        "calories": 500
//    }
//}