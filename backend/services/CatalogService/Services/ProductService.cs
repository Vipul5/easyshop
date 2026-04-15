using CatalogService.Interfaces;
using CatalogService.Models;

namespace CatalogService.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
        return await _repository.AddAsync(product);
    }

     public async Task<List<Product>> GetProductsBySearchAsync(string query)
    {
        return await _repository.GetProductsBySearchAsync(query);
    }

    public async Task<List<Product>> GetByCategory(int categoryId)
    {
        return await _repository.GetByCategory(categoryId);
    }
    
    public async Task<Product> GetById(int id)
    {
          return await _repository.GetById(id);
    }
}