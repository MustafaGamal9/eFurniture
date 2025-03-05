using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eFurniture.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")] 
        public decimal Price { get; set; }

        [StringLength(255)]
        public string Image { get; set; } 

        public string Availability { get; set; } 

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        // Navigation property for related CartItems 
        public ICollection<CartItem> CartItems { get; set; }

        // Navigation property for related OrderItems
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}