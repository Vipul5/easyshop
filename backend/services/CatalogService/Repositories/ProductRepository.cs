using CatalogService.Data;
using CatalogService.Interfaces;
using CatalogService.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> AddAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<List<Product>> GetProductsBySearchAsync(string query)
    {
        if(!string.IsNullOrWhiteSpace(query))
        {
            return await _context.Products
                    .Where(p => p.Name.ToLower().Contains(query.ToLower())
                    || p.Description.ToLower().Contains(query.ToLower()))
                    .ToListAsync();
        }
        else 
        {
            return await this.GetAllAsync();
        }
    }

    public async Task<List<Product>>  GetByCategory(int categoryId)
    {
        var products = _context.Products
            .Where(p => p.CategoryId == categoryId)
            .ToList();

        return products;
    }

     public async Task<Product> GetById(int id)
    {
        var product = await _context.Products.FindAsync(id);
        return product;
    }
}