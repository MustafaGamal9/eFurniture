using eFurniture.Data;
using eFurniture.Models;
using eFurniture.ViewModels.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eFurniture.Controllers
{
    [Authorize] //  Authorize attribute to make login required for using cart
    public class CartController : Controller
    {
        private readonly EFurnitureDbContext _context;
        private readonly ILogger<CartController> _logger;

       
        public CartController(EFurnitureDbContext context, ILogger<CartController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            
            string userEmail = User.Identity?.Name; 

            _logger.LogInformation($"CartController.Index - Retrieved UserEmail: {userEmail}");

            User user = null;

            if (!string.IsNullOrEmpty(userEmail))
            {
                
                user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userEmail);

                if (user == null)
                {
                    _logger.LogWarning($"CartController.Index - User not found for Email: {userEmail}");
                }
                else
                {
                    _logger.LogInformation($"CartController.Index - Retrieved user: UserId={user.UserId}, Email={user.Email ?? "null"}");
                }
            }
            else
            {
                _logger.LogWarning("CartController.Index - UserEmail is null or empty (user not logged in?).");
            }


            try
            {
                Cart cart = null;
                if (user != null)
                {
                    cart = await GetOrCreateCartForUser(user);
                }


                var cartItems = await _context.CartItems
                    .Include(item => item.Product)
                    .Where(item => cart != null && item.CartId == cart.CartId)
                    .ToListAsync();

                var cartViewModel = new CartViewModel
                {
                    CartItems = cartItems ?? new List<CartItem>(),
                    CartTotal = CalculateCartTotal(cartItems)
                };

                return View(cartViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"CartController.Index - Exception occurred for user: {(user != null ? user.UserId.ToString() : "null user")}");
                return Problem("An error occurred while processing your cart. Please try again later.");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
        {
            try
            {
                string userEmail = User.Identity?.Name;
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userEmail);


                if (user == null)
                {
                    _logger.LogWarning("CartController.AddToCart - User not authenticated");
                    return Unauthorized();
                }

                var product = await _context.Products.FindAsync(productId);
                if (product == null)
                {
                    _logger.LogWarning($"CartController.AddToCart - Product not found: {productId}");
                    return NotFound();
                }

                var cart = await GetOrCreateCartForUser(user);
                if (cart == null)
                {
                    _logger.LogError($"CartController.AddToCart - Failed to get or create cart for user: {user.UserId}");
                    return Problem("Failed to create or retrieve cart.");
                }

                var cartItem = await _context.CartItems
                    .FirstOrDefaultAsync(item => item.CartId == cart.CartId && item.ProductId == productId);

                if (cartItem == null)
                {
                    cartItem = new CartItem
                    {
                        CartId = cart.CartId,
                        ProductId = productId,
                        Quantity = quantity
                    };
                    _context.CartItems.Add(cartItem);
                }
                else
                {
                    cartItem.Quantity += quantity;
                }

                await _context.SaveChangesAsync();
                _logger.LogInformation($"CartController.AddToCart - Added product {productId} to cart for user {user.UserId}");

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CartController.AddToCart - Exception occurred");
                return Problem("An error occurred while adding to your cart.");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateQuantity(int cartItemId, int quantity)
        {
            try
            {
                var cartItem = await _context.CartItems.FindAsync(cartItemId);
                if (cartItem == null)
                {
                    _logger.LogWarning($"CartController.UpdateQuantity - Cart item not found: {cartItemId}");
                    return NotFound();
                }

                // Verify the cart belongs to the current user (security check)
                var cart = await _context.Carts.FirstOrDefaultAsync(c => c.CartId == cartItem.CartId);
                if (cart == null)
                {
                    _logger.LogWarning($"CartController.UpdateQuantity - Cart not found for cartItem: {cartItemId}");
                    return NotFound(); 
                }

                string userEmail = User.Identity?.Name;
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userEmail);

                if (user == null || cart.UserId != user.UserId)
                {
                    _logger.LogWarning($"CartController.UpdateQuantity - Unauthorized cart access attempted");
                    return Unauthorized();
                }

                if (quantity <= 0)
                {
                    _logger.LogWarning($"CartController.UpdateQuantity - Invalid quantity: {quantity}");
                    return BadRequest("Quantity must be greater than zero.");
                }

                cartItem.Quantity = quantity;
                await _context.SaveChangesAsync();
                _logger.LogInformation($"CartController.UpdateQuantity - Updated cart item {cartItemId} quantity to {quantity}");

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CartController.UpdateQuantity - Exception occurred");
                return Problem("An error occurred while updating your cart.");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveItem(int cartItemId)
        {
            try
            {
                var cartItem = await _context.CartItems.FindAsync(cartItemId);
                if (cartItem == null)
                {
                    _logger.LogWarning($"CartController.RemoveItem - Cart item not found: {cartItemId}");
                    return NotFound();
                }
                var cart = await _context.Carts.FirstOrDefaultAsync(c => c.CartId == cartItem.CartId);
                if (cart == null)
                {
                    _logger.LogWarning($"CartController.RemoveItem - Cart not found for cartItem: {cartItemId}");
                    return NotFound(); // Cart not found
                }

                string userEmail = User.Identity?.Name;
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userEmail);
                if (user == null || cart.UserId != user.UserId)
                {
                    _logger.LogWarning($"CartController.RemoveItem - Unauthorized cart access attempted");
                    return Unauthorized();
                }


                _context.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"CartController.RemoveItem - Removed cart item {cartItemId}");

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CartController.RemoveItem - Exception occurred");
                return Problem("An error occurred while removing the item from your cart.");
            }
        }

        public IActionResult Checkout()
        {
            return View();
        }

        private async Task<Cart> GetOrCreateCartForUser(User user)
        {
            if (user == null)
            {
                _logger.LogError("GetOrCreateCartForUser - User is null");
                return null;
            }

            try
            {
                var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == user.UserId);
                if (cart == null)
                {
                    _logger.LogInformation($"GetOrCreateCartForUser - Creating new cart for user {user.UserId}");
                    cart = new Cart { UserId = user.UserId };
                    _context.Carts.Add(cart);
                    await _context.SaveChangesAsync();
                }
                return cart;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"GetOrCreateCartForUser - Exception for user {user.UserId}");
                return null;
            }
        }


        private decimal CalculateCartTotal(List<CartItem> cartItems)
        {
            if (cartItems == null || !cartItems.Any())
            {
                return 0;
            }

            return cartItems.Sum(item => (item.Product?.Price ?? 0) * item.Quantity);
        }
    }
}