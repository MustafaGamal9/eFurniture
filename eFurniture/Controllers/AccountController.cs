using eFurniture.Data;
using eFurniture.Models;
using eFurniture.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication; 
using Microsoft.AspNetCore.Authentication.Cookies; 
using System.Security.Claims; 

namespace eFurniture.Controllers
{
    public class AccountController : Controller
    {
        private readonly EFurnitureDbContext _context;

        public AccountController(EFurnitureDbContext context)
        {
            _context = context;
        }

        // Account/Register - GET
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Account/ Register - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (existingUser != null)
                {
                    ViewBag.ErrorMessage = "Email already registered.";
                    return View(model);
                }

                var user = new User
                {
                    Name = model.Name,
                    Email = model.Email,
                    Password = model.Password // Not safe to use this method in a real app
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                
                await SignInUser(user.Email, isPersistent: false); 

                return RedirectToAction("Index", "Home"); 
            }
            return View(model);
        }

        // Account/Login - GET
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Account/Login - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid) 
            {
                
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);

                if (user != null)
                {
                    // **Custom Authentication - Sign in user on successful login**
                    await SignInUser(user.Email, model.RememberMe); // Use email as username
                    return RedirectToAction("Index", "Home"); // Redirect to homepage after login
                }

                ViewBag.ErrorMessage = "Invalid login attempt.";
                return View(model);
            }
            return View(model);
        }

        // Account/Logout - POST 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        private async Task SignInUser(string email, bool isPersistent)
        {
            // Cookie-Based Authentication**
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, email),
                new Claim(ClaimTypes.Email, email),
               
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = isPersistent, // "Remember Me" 
                
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }
    }
}