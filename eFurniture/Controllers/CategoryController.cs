using eFurniture.Data;
using Microsoft.AspNetCore.Mvc;

namespace eFurniture.Controllers
{
    public class CategoryController : Controller
    {
        private readonly EFurnitureDbContext _context;

        public CategoryController(EFurnitureDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // List of category names that represent rooms
            List<string> roomCategoryNames = new List<string>
            {
                "Living Room",
                "Bedroom",
                "Dining Room",
                "Office"
            };

            // Fetch categories that are not in the list of room category names
            var nonRoomCategories = _context.Categories
                .ToList() 
                .Where(category => !roomCategoryNames.Contains(category.Name)) 
                .ToList();

            return View(nonRoomCategories);

          
        }
    }
}