
using Microsoft.EntityFrameworkCore;
using CartService.Models;

namespace CartService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<CartItem> CartItems { get; set; }
}