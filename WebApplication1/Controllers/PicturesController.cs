using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public PicturesController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpGet]
        [Route("api/images/{fileName}")]
        public IActionResult GetImage(string fileName)
        {
            var webRoot = _env.WebRootPath;
            var imagePath = Path.Combine(webRoot, "images", fileName);
            return PhysicalFile(imagePath, "image/jpeg");
        }
    }

}
