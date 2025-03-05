using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eFurniture.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

    
        [ForeignKey("User")]
        public int UserId { get; set; } 
        public User User { get; set; }

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; }

        public string ShippingAddress { get; set; }

        public string PaymentStatus { get; set; }

        // Navigation property
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}