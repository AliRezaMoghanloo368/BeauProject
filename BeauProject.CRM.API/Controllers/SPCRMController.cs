using BeauProject.CRM.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeauProject.CRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SPCRMController : ControllerBase
    {
        private readonly ISPService _service;
        public SPCRMController(ISPService service)
        {
            _service = service;
        }

        [HttpGet("Function")]
        public async Task<IActionResult> Function()
        {
            var result = await _service.Function();
            return Ok(result);
        }
    }
}
