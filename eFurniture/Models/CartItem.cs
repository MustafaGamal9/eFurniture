using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eFurniture.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }

   
        [ForeignKey("Cart")]
        public int CartId { get; set; }
        public Cart Cart { get; set; }

  
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        [Range(1, int.MaxValue)] 
        public int Quantity { get; set; } = 1; 
    }
}