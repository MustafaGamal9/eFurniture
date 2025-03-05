using System.ComponentModel.DataAnnotations;

namespace eFurniture.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; } // Dont use this method in a real app

        // Navigation property 
        public Cart Cart { get; set; } 

        public ICollection<Order> Orders { get; set; }
    }
}