using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _env;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Task()
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}