using BeauProject.Shared.Classes;
using Microsoft.AspNetCore.Mvc;

namespace MyAssistant.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadController : ControllerBase
    {
        public readonly IWebHostEnvironment env;

        public UploadController(IWebHostEnvironment env)
        {
            this.env = env;
        }

        [HttpPost]
        public async Task Post([FromBody] ImageFile[] files)
        {
            foreach (var file in files)
            {
                var buf = Convert.FromBase64String(file.base64data);
                await System.IO.File.WriteAllBytesAsync(env.ContentRootPath + System.IO.Path.DirectorySeparatorChar + Guid.NewGuid().ToString("N") + "-" + file.fileName, buf);
            }
        }
    }
}
