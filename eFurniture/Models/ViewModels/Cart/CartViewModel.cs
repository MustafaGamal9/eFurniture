using eFurniture.Models;

namespace eFurniture.ViewModels.Cart
{
    public class CartViewModel
    {
        public List<CartItem> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}