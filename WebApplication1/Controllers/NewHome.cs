using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;

namespace WebApplication1.Controllers
{
    public class NewHomeController : Controller
    {
        private readonly ILogger<NewHomeController> _logger;
        private readonly IWebHostEnvironment _env;

        // Use dependency injection to get both the logger and the environment
        public NewHomeController(ILogger<NewHomeController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public IActionResult Index()
        {
            // Get the physical path of the wwwroot/images folder
            var imagesPath = Path.Combine(_env.WebRootPath, "images");

            // Get all the files in the folder and their relative paths
            var images = Directory.GetFiles(imagesPath)
                .Select(file => Path.GetRelativePath(_env.WebRootPath, file))
                .ToList();

            // Pass the list of image paths to a view bag
            ViewBag.Images = images;

            // Return the view with the imagesPath as the model
            return View();
        }
    }
}