﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eFurniture.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }

  
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }

   
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PriceAtPurchase { get; set; }
    }
}