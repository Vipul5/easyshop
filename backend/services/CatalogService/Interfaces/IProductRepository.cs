using CatalogService.Models;

namespace CatalogService.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<Product> AddAsync(Product product);
    Task<List<Product>> GetProductsBySearchAsync(string query);
    Task<List<Product>>  GetByCategory(int categoryId);
    Task<Product> GetById(int id);

}