using eFurniture.Data;
using eFurniture.ViewModels.Profile; 
using Microsoft.AspNetCore.Authorization; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// Not Fully implemented
namespace eFurniture.Controllers
{
    [Authorize] // Require user to be logged in to access profile actions
    public class ProfileController : Controller
    {
        private readonly EFurnitureDbContext _context;
        private readonly ILogger<ProfileController> _logger; 

        
        public ProfileController(EFurnitureDbContext context, ILogger<ProfileController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET - Profile/Index 
        public async Task<IActionResult> Index()
        {
            
            string userEmail = User.Identity?.Name;

            if (string.IsNullOrEmpty(userEmail))
            {
                _logger.LogWarning("ProfileController.Index - UserEmail is null or empty. User not authenticated.");
                return RedirectToAction("Login", "Account");
            }

           
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userEmail);

            if (user == null)
            {
                _logger.LogError($"ProfileController.Index - User not found in database for Email: {userEmail}");
                return NotFound(); 
            }

            var profileViewModel = new ProfileViewModel
            {
                Name = user.Name,
                Email = user.Email,
            };

            return View(profileViewModel);
        }

    }
}