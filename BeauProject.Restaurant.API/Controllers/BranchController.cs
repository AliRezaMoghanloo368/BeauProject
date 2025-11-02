using BeauProject.Restaurant.Application.Features.BranchType.Request.Command;
using BeauProject.Restaurant.Application.Features.BranchType.Request.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeauProject.Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BranchController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBranchCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new { Id = id });
        }

        [HttpGet("restaurant/{restaurantId:long}")]
        public async Task<IActionResult> GetByRestaurant(long restaurantId)
        {
            var result = await _mediator.Send(new GetBranchesByRestaurantQuery(restaurantId));
            return Ok(result);
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateBranchCommand command)
        {
            if (id != command.Id)
                return BadRequest("شناسه ارسالی با بدنه درخواست مطابقت ندارد.");

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _mediator.Send(new DeleteBranchCommand(id));
            if (!result.Success) return BadRequest(new { error = result.Error });
            return NoContent();
        }
    }
}

//{
//        "id": 1,
//        "restaurantId": 1,
//        "code": "T001",
//        "name": "Tehran Branch",
//        "locale": "fa-IR",
//        "address": "تهران، خیابان آزادی",
//        "phoneNumber": "0211234567",
//        "city": "1",
//        "isMainBranch": false
//}