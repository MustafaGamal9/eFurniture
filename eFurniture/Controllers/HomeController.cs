using eFurniture.Data;
using eFurniture.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eFurniture.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EFurnitureDbContext _context;

        public HomeController(ILogger<HomeController> logger, EFurnitureDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // Fetch Featured Products 
            var featuredProducts = _context.Products
                .Take(4) // Get the first 4
                .ToList();

            // Fetch "Shop by Room" Categories
            var roomCategories = _context.Categories
                .Where(c => c.Name == "Living Room" || c.Name == "Bedroom" || c.Name == "Dining Room" || c.Name == "Office") // Example filter
                .ToList();

            var homeViewModel = new HomeViewModel 
            {
                FeaturedProducts = featuredProducts,
                RoomCategories = roomCategories
            };

            return View(homeViewModel); 
        }

        public IActionResult ContactUs()
        {
            return View();
        }


    }
}
