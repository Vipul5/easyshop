using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CatalogService.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductsAndCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Apparel" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Smartphone with latest features", "https://res.cloudinary.com/dcndo0hkp/image/upload/v1776148244/399694-smartphones-apple-iphone-11-10008711_nufuwo.png", "Mobile", 15000m },
                    { 2, 1, "High performance laptop for work and gaming", "https://res.cloudinary.com/dcndo0hkp/image/upload/v1776148760/36809cf3-480b-47a5-94f0-e1d5e70c58c0_3.fcc0d6494b0e279a13c32c80c28abfa3_ahnzgk.jpg", "Laptop", 60000m },
                    { 3, 1, "Smart LED TV with 4K resolution", "https://res.cloudinary.com/dcndo0hkp/image/upload/v1776148371/Heavy-Boxy-Tshirt-Back-1-1-Product_m8t1lx.jpg", "TV", 40000m },
                    { 4, 1, "Energy efficient air conditioner", "https://res.cloudinary.com/dcndo0hkp/image/upload/v1776148778/815QEibJCwL._SL1500_gxk7pv.jpg", "AC", 35000m },
                    { 5, 1, "Double door refrigerator", "https://res.cloudinary.com/dcndo0hkp/image/upload/v1776148804/Fridge_Thumbnail__0016_DFF180E2SSDB_ej0ae6.jpg", "Fridge", 25000m },
                    { 6, 1, "Table fan with high speed motor", "https://res.cloudinary.com/dcndo0hkp/image/upload/v1776148817/hampton-bay-personal-fans-tx-1204d-64_1000_qy4gdp.jpg", "Fan", 3000m },
                    { 7, 1, "headphone with noise control", "https://res.cloudinary.com/dcndo0hkp/image/upload/v1776148913/1_6122ca29-5373-4c4f-97c2-0728ea368fc1_oacnsy.jpg", "Headphone", 8000m },
                    { 8, 1, "Kitchen chimney for smoke control", "https://res.cloudinary.com/dcndo0hkp/image/upload/v1776148936/Tune-C-_uy8cec.png", "Chimney", 12000m },
                    { 9, 1, "Portable induction cooktop", "https://res.cloudinary.com/dcndo0hkp/image/upload/v1776148953/8901365419587-8_cgru8f.jpg", "Induction ", 4000m },
                    { 10, 2, "Comfortable cotton t-shirt", "https://res.cloudinary.com/dcndo0hkp/image/upload/v1776148371/Heavy-Boxy-Tshirt-Back-1-1-Product_m8t1lx.jpg", "T-Shirt", 800m },
                    { 11, 2, "Stylish running shoes", "https://res.cloudinary.com/dcndo0hkp/image/upload/v1776148396/DressSneakersInBlackWithWhiteOutsole.rightangle_gagupm.jpg", "Shoes", 2500m },
                    { 12, 2, "Casual wear pants", "https://res.cloudinary.com/dcndo0hkp/image/upload/v1776148973/JM7144_BLK_F_2_1000x_yqsniz.jpg", "Pant", 1500m },
                    { 13, 2, "Comfortable track pants for workouts", "https://res.cloudinary.com/dcndo0hkp/image/upload/v1776148997/s-l1200_i1jzxw.jpg", "Track Pant", 1200m },
                    { 14, 2, "Casual wear cap", "https://res.cloudinary.com/dcndo0hkp/image/upload/v1776148384/R1370284-01_melfta.jpg", "Cap", 300m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
