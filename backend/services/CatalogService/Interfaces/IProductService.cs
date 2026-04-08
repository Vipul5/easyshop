using CatalogService.Models;

namespace CatalogService.Interfaces;

public interface IProductService
{
    Task<List<Product>> GetProductsAsync();
    Task<Product> CreateProductAsync(Product product);
}