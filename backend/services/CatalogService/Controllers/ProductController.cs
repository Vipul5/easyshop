using Microsoft.AspNetCore.Mvc;
using CatalogService.Interfaces;
using CatalogService.Models;

namespace CatalogService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var products = await _service.GetProductsAsync();
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        var created = await _service.CreateProductAsync(product);
        return Ok(created);
    }
}