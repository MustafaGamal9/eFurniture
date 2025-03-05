using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eFurniture.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string CategoryImage { get; set; } 

        // Navigation property 
        public ICollection<Product> Products { get; set; }
    }
}