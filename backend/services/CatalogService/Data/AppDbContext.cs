using Microsoft.EntityFrameworkCore;
using CatalogService.Models;

namespace CatalogService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Categories
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Electronics" },
            new Category { Id = 2, Name = "Apparel" }
        );

        // Products
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Mobile", Price = 15000, Image = "https://res.cloudinary.com/dcndo0hkp/image/upload/v1776148244/399694-smartphones-apple-iphone-11-10008711_nufuwo.png", CategoryId = 1 , Description = "Smartphone with latest features"},
            new Product { Id = 2, Name = "Laptop", Price = 60000, Image = "https://res.cloudinary.com/dcndo0hkp/image/upload/v1776148760/36809cf3-480b-47a5-94f0-e1d5e70c58c0_3.fcc0d6494b0e279a13c32c80c28abfa3_ahnzgk.jpg", CategoryId = 1 , Description = "High performance laptop for work and gaming" },
            new Product { Id = 3, Name = "TV", Price = 40000, Image = "https://res.cloudinary.com/dcndo0hkp/image/upload/v1776148256/amazon-fire-tv-4-series-50-inch_dj74.1920_dzqyeb.jpg", CategoryId = 1 , Description = "Smart LED TV with 4K resolution" },
            new Product { Id = 4, Name = "AC", Price = 35000, Image = "https://res.cloudinary.com/dcndo0hkp/image/upload/v1776148778/815QEibJCwL._SL1500_gxk7pv.jpg", CategoryId = 1 , Description = "Energy efficient air conditioner" },
            new Product { Id = 5, Name = "Fridge", Price = 25000, Image = "https://res.cloudinary.com/dcndo0hkp/image/upload/v1776148804/Fridge_Thumbnail__0016_DFF180E2SSDB_ej0ae6.jpg", CategoryId = 1 , Description = "Double door refrigerator" },
            new Product { Id = 6, Name = "Fan", Price = 3000, Image = "https://res.cloudinary.com/dcndo0hkp/image/upload/v1776148817/hampton-bay-personal-fans-tx-1204d-64_1000_qy4gdp.jpg", CategoryId = 1 , Description = "Table fan with high speed motor" },
            new Product { Id = 7, Name = "Headphone", Price = 8000, Image = "https://res.cloudinary.com/dcndo0hkp/image/upload/v1776148913/1_6122ca29-5373-4c4f-97c2-0728ea368fc1_oacnsy.jpg", CategoryId = 1, Description = "headphone with noise control" },
            new Product { Id = 8, Name = "Chimney", Price = 12000, Image = "https://res.cloudinary.com/dcndo0hkp/image/upload/v1776148936/Tune-C-_uy8cec.png", CategoryId = 1 , Description = "Kitchen chimney for smoke control" },
            new Product { Id = 9, Name = "Induction ", Price = 4000, Image = "https://res.cloudinary.com/dcndo0hkp/image/upload/v1776148953/8901365419587-8_cgru8f.jpg", CategoryId = 1 , Description = "Portable induction cooktop" },

            new Product { Id = 10, Name = "T-Shirt", Price = 800, Image = "https://res.cloudinary.com/dcndo0hkp/image/upload/v1776148371/Heavy-Boxy-Tshirt-Back-1-1-Product_m8t1lx.jpg", CategoryId = 2 , Description = "Comfortable cotton t-shirt" },
            new Product { Id = 11, Name = "Shoe", Price = 2500, Image = "https://res.cloudinary.com/dcndo0hkp/image/upload/v1776148396/DressSneakersInBlackWithWhiteOutsole.rightangle_gagupm.jpg", CategoryId = 2 , Description = "Stylish running shoes" },
            new Product { Id = 12, Name = "Pant", Price = 1500, Image = "https://res.cloudinary.com/dcndo0hkp/image/upload/v1776148973/JM7144_BLK_F_2_1000x_yqsniz.jpg", CategoryId = 2 , Description = "Casual wear pants" },
            new Product { Id = 13, Name = "Track Pant", Price = 1200, Image = "https://res.cloudinary.com/dcndo0hkp/image/upload/v1776148997/s-l1200_i1jzxw.jpg", CategoryId = 2 , Description = "Comfortable track pants for workouts" },
            new Product { Id = 14, Name = "Cap", Price = 300, Image = "https://res.cloudinary.com/dcndo0hkp/image/upload/v1776148384/R1370284-01_melfta.jpg", CategoryId = 2 , Description = "Casual wear cap" }
        );
    }
}