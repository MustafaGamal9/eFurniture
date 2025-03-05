using eFurniture.Models;
using Microsoft.EntityFrameworkCore;
// EFurnitureDbContext.cs
namespace eFurniture.Data
{
    public class EFurnitureDbContext : DbContext
    {
        public EFurnitureDbContext(DbContextOptions<EFurnitureDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<User>()
                .HasOne(u => u.Cart)
                .WithOne(c => c.User)
                .HasForeignKey<Cart>(c => c.UserId);

           modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId);

           
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Living Room", CategoryImage = "livingroom.jpg" },
                new Category { CategoryId = 2, Name = "Bedroom", CategoryImage = "bedroom.jpg" },
                new Category { CategoryId = 3, Name = "Dining Room", CategoryImage = "diningroom.jpg" },
                new Category { CategoryId = 4, Name = "Office", CategoryImage = "office.jpg" },
                new Category { CategoryId = 5, Name = "Sofas", CategoryImage = "sofas.jpg" },
                new Category { CategoryId = 6, Name = "Desks & Chairs", CategoryImage = "desks_chairs.jpg" },
                new Category { CategoryId = 7, Name = "Decoration", CategoryImage = "decoration.jpg" },
                new Category { CategoryId = 8, Name = "Home Electronics", CategoryImage = "electronics.jpg" }
            );

            modelBuilder.Entity<Product>().HasData(
                // Living Room Products 
                new Product { ProductId = 1, CategoryId = 1, Name = "Modern Sofa", Description = "Comfortable modern sofa for living rooms.", Price = 599.99m, Image = "livingroom_sofa1.jpg", Availability = "In Stock" },
                new Product { ProductId = 2, CategoryId = 1, Name = "Coffee Table", Description = "Stylish coffee table to complement your living room.", Price = 149.50m, Image = "livingroom_table1.jpg", Availability = "In Stock" },
                new Product { ProductId = 3, CategoryId = 1, Name = "TV Stand", Description = "Elegant TV stand with storage.", Price = 299.00m, Image = "livingroom_tvstand1.jpg", Availability = "In Stock" },

                // Bedroom Products 
                new Product { ProductId = 4, CategoryId = 2, Name = "King Bed", Description = "Luxurious king-size bed for a master bedroom.", Price = 899.00m, Image = "bedroom_bed1.jpg", Availability = "In Stock" },
                new Product { ProductId = 5, CategoryId = 2, Name = "Nightstand", Description = "Modern nightstand with drawer.", Price = 129.99m, Image = "bedroom_nightstand1.jpg", Availability = "In Stock" },
                new Product { ProductId = 6, CategoryId = 2, Name = "Dresser", Description = "Spacious dresser with multiple drawers.", Price = 349.50m, Image = "bedroom_dresser1.jpg", Availability = "In Stock" },

                // Dining Room Products
                new Product { ProductId = 7, CategoryId = 3, Name = "Dining Table Set", Description = "Elegant dining table with 4 chairs.", Price = 749.50m, Image = "diningroom_table1.jpg", Availability = "Limited Stock" },
                new Product { ProductId = 8, CategoryId = 3, Name = "Dining Chair (Single)", Description = "Comfortable dining chair, sold individually.", Price = 120.00m, Image = "diningroom_chair1.jpg", Availability = "In Stock" },
                new Product { ProductId = 9, CategoryId = 3, Name = "Sideboard", Description = "Stylish sideboard for dining room storage.", Price = 499.00m, Image = "diningroom_sideboard1.jpg", Availability = "In Stock" },

                // Office Products 
                new Product { ProductId = 10, CategoryId = 4, Name = "Office Desk", Description = "Spacious office desk with a minimalist design.", Price = 299.00m, Image = "office_desk1.jpg", Availability = "Out of Stock" },
                new Product { ProductId = 11, CategoryId = 4, Name = "Ergonomic Chair", Description = "Adjustable ergonomic office chair for comfort.", Price = 250.00m, Image = "office_chair1.jpg", Availability = "In Stock" },
                new Product { ProductId = 12, CategoryId = 4, Name = "Bookcase", Description = "Modern bookcase with multiple shelves.", Price = 199.99m, Image = "office_bookcase1.jpg", Availability = "In Stock" },

                // Sofas Products
                new Product { ProductId = 13, CategoryId = 5, Name = "Leather Recliner", Description = "Comfortable leather recliner sofa for relaxation.", Price = 450.00m, Image = "sofas_recliner1.jpg", Availability = "In Stock" },
                new Product { ProductId = 14, CategoryId = 5, Name = "Sectional Sofa", Description = "Large sectional sofa for family gatherings.", Price = 1299.99m, Image = "sofas_sectional1.jpg", Availability = "In Stock" },
                new Product { ProductId = 15, CategoryId = 5, Name = "Velvet Sofa", Description = "Luxurious velvet sofa for a touch of elegance.", Price = 899.50m, Image = "sofas_velvet1.jpg", Availability = "In Stock" },

                // Desks & Chairs Products 
                new Product { ProductId = 16, CategoryId = 6, Name = "Executive Desk", Description = "Large executive desk for a professional office.", Price = 599.00m, Image = "desks_chairs_desk1.jpg", Availability = "In Stock" },
                new Product { ProductId = 17, CategoryId = 6, Name = "Office Chair", Description = "Standard office chair with adjustable height.", Price = 150.00m, Image = "desks_chairs_chair1.jpg", Availability = "In Stock" },
                new Product { ProductId = 18, CategoryId = 6, Name = "Drafting Chair", Description = "Tall drafting chair with footrest, ideal for standing desks.", Price = 220.00m, Image = "desks_chairs_draftingchair1.jpg", Availability = "In Stock" },

                // Decoration Products 
                new Product { ProductId = 19, CategoryId = 7, Name = "Vase Set", Description = "Set of decorative vases for home decor.", Price = 50.00m, Image = "decoration_vase1.jpg", Availability = "In Stock" },
                new Product { ProductId = 20, CategoryId = 7, Name = "Wall Art", Description = "Modern abstract wall art piece.", Price = 75.00m, Image = "decoration_wallart1.jpg", Availability = "In Stock" },
                new Product { ProductId = 21, CategoryId = 7, Name = "Decorative Bowls", Description = "Set of decorative bowls in varying sizes.", Price = 40.00m, Image = "decoration_bowls1.jpg", Availability = "In Stock" },

                // Home Electronics Products 
                new Product { ProductId = 22, CategoryId = 8, Name = "Smart TV", Description = "55-inch 4K Smart TV with HDR.", Price = 800.00m, Image = "electronics_tv1.jpg", Availability = "In Stock" },
                new Product { ProductId = 23, CategoryId = 8, Name = "Soundbar System", Description = "Home theater soundbar system with subwoofer.", Price = 350.00m, Image = "electronics_soundbar1.jpg", Availability = "In Stock" },
                new Product { ProductId = 24, CategoryId = 8, Name = "Wireless Headphones", Description = "Noise-cancelling wireless headphones.", Price = 200.00m, Image = "electronics_headphones1.jpg", Availability = "In Stock" }
            );
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}