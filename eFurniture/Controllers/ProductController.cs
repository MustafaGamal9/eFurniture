using eFurniture.Data;
using eFurniture.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace eFurniture.Controllers
{
    public class ProductController : Controller
    {
        private readonly EFurnitureDbContext _context;

        public ProductController(EFurnitureDbContext context)
        {
            _context = context;
        }

        // GET - /Product/Index or /Product/Index?categoryId=
        public IActionResult Index(int? categoryId)
        {
            IQueryable<Product> products = _context.Products.Include(p => p.Category);

            if (categoryId.HasValue)
            {
                products = products.Where(p => p.CategoryId == categoryId.Value);
            }

            return View(products.ToList());
        }
    }
}