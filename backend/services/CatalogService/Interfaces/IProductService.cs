using CatalogService.Models;

namespace CatalogService.Interfaces;

public interface IProductService
{
    Task<List<Product>> GetProductsAsync();
    Task<Product> CreateProductAsync(Product product);
    Task<List<Product>> GetProductsBySearchAsync(string query);
    Task<List<Product>>  GetByCategory(int categoryId);
    Task<Product> GetById(int id);

}
