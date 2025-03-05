using eFurniture.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eFurniture.Controllers
{
    public class RoomsController : Controller
    {
        private readonly EFurnitureDbContext _context;

        public RoomsController(EFurnitureDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
           
            var roomCategories = _context.Categories
                .Where(c => c.Name == "Living Room" || c.Name == "Bedroom" || c.Name == "Dining Room" || c.Name == "Office") 
                .ToList();
            return View(roomCategories); 
        }

        public IActionResult Products(string categoryName)
        {
            if (string.IsNullOrEmpty(categoryName))
            {
                return NotFound(); 
            }

            var category = _context.Categories.FirstOrDefault(c => c.Name == categoryName);
            if (category == null) return NotFound();

           var products = _context.Products.Where(p => p.CategoryId == category.CategoryId).Include(p => p.Category).ToList();
            return View("Products", products);
        }
     }
}
