using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eFurniture.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        // Navigation property
        public ICollection<CartItem> CartItems { get; set; }
    }
}