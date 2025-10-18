using BeauProject.CRM.Application.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeauProject.CRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SPCRMController : ControllerBase
    {
        private readonly SPService _sPService;
        public SPCRMController(SPService sPService)
        {
            _sPService = sPService;
        }

        [HttpGet("Function")]
        public async Task<IActionResult> Function()
        {
            var result = await _sPService.Function();
            return Ok(result);
        }
    }
}
