using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    public class AllPicturesController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly AppDbcontext _context;

        public AllPicturesController(IWebHostEnvironment env, AppDbcontext context)
        {
            _env = env;
            _context = context;
        }

        [HttpGet]
        [Route("api/images")]
        public IActionResult GetAllImages()
        {
            var webRoot = _env.WebRootPath;
            var imagesFolder = Path.Combine(webRoot, "images");
            var baseUrl = "https://localhost:7196/";
            var imageUrls = Directory.EnumerateFiles(imagesFolder, "*", SearchOption.AllDirectories)
                .Where(fileName => fileName.EndsWith(".jpeg") || fileName.EndsWith(".png") || fileName.EndsWith(".gif") || fileName.EndsWith(".jpg"))
                .Select(fileName => Path.GetRelativePath(webRoot, fileName))
                .Select(fileName => Path.Combine(baseUrl, fileName))
                .Select(fileName => fileName.Replace("\\", "/"));
            //the new task
            foreach (var imageUrl in imageUrls)
            {
                var imageName = Path.GetFileName(imageUrl);
                var imagePath = imageUrl;
                var image = new Image { Name = imageName, Path = imagePath };
                _context.Images.Add(image);
            }
            /*await*/
            _context.SaveChangesAsync();
            // End of the task

            return new JsonResult(imageUrls);

        }
    }
}
