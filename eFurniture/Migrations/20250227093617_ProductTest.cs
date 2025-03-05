using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eFurniture.Migrations
{
    /// <inheritdoc />
    public partial class ProductTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "Description", "Image" },
                values: new object[] { "Comfortable modern sofa for living rooms.", "livingroom_sofa1.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "Image", "Name", "Price" },
                values: new object[] { 1, "Stylish coffee table to complement your living room.", "livingroom_table1.jpg", "Coffee Table", 149.50m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "Availability", "CategoryId", "Description", "Image", "Name", "Price" },
                values: new object[] { "In Stock", 1, "Elegant TV stand with storage.", "livingroom_tvstand1.jpg", "TV Stand", 299.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "Availability", "CategoryId", "Description", "Image", "Name", "Price" },
                values: new object[] { "In Stock", 2, "Luxurious king-size bed for a master bedroom.", "bedroom_bed1.jpg", "King Bed", 899.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "CategoryId", "Description", "Image", "Name", "Price" },
                values: new object[] { 2, "Modern nightstand with drawer.", "bedroom_nightstand1.jpg", "Nightstand", 129.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "CategoryId", "Description", "Image", "Name", "Price" },
                values: new object[] { 2, "Spacious dresser with multiple drawers.", "bedroom_dresser1.jpg", "Dresser", 349.50m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7,
                columns: new[] { "Availability", "CategoryId", "Description", "Image", "Name", "Price" },
                values: new object[] { "Limited Stock", 3, "Elegant dining table with 4 chairs.", "diningroom_table1.jpg", "Dining Table Set", 749.50m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8,
                columns: new[] { "CategoryId", "Description", "Image", "Name", "Price" },
                values: new object[] { 3, "Comfortable dining chair, sold individually.", "diningroom_chair1.jpg", "Dining Chair (Single)", 120.00m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Availability", "CategoryId", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 9, "In Stock", 3, "Stylish sideboard for dining room storage.", "diningroom_sideboard1.jpg", "Sideboard", 499.00m },
                    { 10, "Out of Stock", 4, "Spacious office desk with a minimalist design.", "office_desk1.jpg", "Office Desk", 299.00m },
                    { 11, "In Stock", 4, "Adjustable ergonomic office chair for comfort.", "office_chair1.jpg", "Ergonomic Chair", 250.00m },
                    { 12, "In Stock", 4, "Modern bookcase with multiple shelves.", "office_bookcase1.jpg", "Bookcase", 199.99m },
                    { 13, "In Stock", 5, "Comfortable leather recliner sofa for relaxation.", "sofas_recliner1.jpg", "Leather Recliner", 450.00m },
                    { 14, "In Stock", 5, "Large sectional sofa for family gatherings.", "sofas_sectional1.jpg", "Sectional Sofa", 1299.99m },
                    { 15, "In Stock", 5, "Luxurious velvet sofa for a touch of elegance.", "sofas_velvet1.jpg", "Velvet Sofa", 899.50m },
                    { 16, "In Stock", 6, "Large executive desk for a professional office.", "desks_chairs_desk1.jpg", "Executive Desk", 599.00m },
                    { 17, "In Stock", 6, "Standard office chair with adjustable height.", "desks_chairs_chair1.jpg", "Office Chair", 150.00m },
                    { 18, "In Stock", 6, "Tall drafting chair with footrest, ideal for standing desks.", "desks_chairs_draftingchair1.jpg", "Drafting Chair", 220.00m },
                    { 19, "In Stock", 7, "Set of decorative vases for home decor.", "decoration_vase1.jpg", "Vase Set", 50.00m },
                    { 20, "In Stock", 7, "Modern abstract wall art piece.", "decoration_wallart1.jpg", "Wall Art", 75.00m },
                    { 21, "In Stock", 7, "Set of decorative bowls in varying sizes.", "decoration_bowls1.jpg", "Decorative Bowls", 40.00m },
                    { 22, "In Stock", 8, "55-inch 4K Smart TV with HDR.", "electronics_tv1.jpg", "Smart TV", 800.00m },
                    { 23, "In Stock", 8, "Home theater soundbar system with subwoofer.", "electronics_soundbar1.jpg", "Soundbar System", 350.00m },
                    { 24, "In Stock", 8, "Noise-cancelling wireless headphones.", "electronics_headphones1.jpg", "Wireless Headphones", 200.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 24);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "Description", "Image" },
                values: new object[] { "Comfortable modern sofa.", "sofa1.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "Image", "Name", "Price" },
                values: new object[] { 2, "Luxurious king-size bed.", "bed1.jpg", "King Bed", 899.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "Availability", "CategoryId", "Description", "Image", "Name", "Price" },
                values: new object[] { "Limited Stock", 3, "Elegant dining table with chairs.", "diningtable1.jpg", "Dining Table Set", 749.50m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "Availability", "CategoryId", "Description", "Image", "Name", "Price" },
                values: new object[] { "Out of Stock", 4, "Spacious office desk.", "desk1.jpg", "Office Desk", 299.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "CategoryId", "Description", "Image", "Name", "Price" },
                values: new object[] { 5, "Comfortable leather recliner sofa.", "recliner1.jpg", "Leather Recliner", 450.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "CategoryId", "Description", "Image", "Name", "Price" },
                values: new object[] { 6, "Adjustable ergonomic office chair.", "chair1.jpg", "Ergonomic Chair", 250.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7,
                columns: new[] { "Availability", "CategoryId", "Description", "Image", "Name", "Price" },
                values: new object[] { "In Stock", 7, "Decorative vase set.", "vase1.jpg", "Vase Set", 50.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8,
                columns: new[] { "CategoryId", "Description", "Image", "Name", "Price" },
                values: new object[] { 8, "4K Smart TV.", "tv1.jpg", "Smart TV", 800.00m });
        }
    }
}
