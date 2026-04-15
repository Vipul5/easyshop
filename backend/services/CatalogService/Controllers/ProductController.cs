using Microsoft.AspNetCore.Mvc;
using CatalogService.Interfaces;
using CatalogService.Models;
using Microsoft.AspNetCore.Authorization;

namespace CatalogService.Controllers
{

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

        [HttpGet("search")]
        public async Task<IActionResult> Search(string query= "")
        {
            var products = await _service.GetProductsBySearchAsync(query);
            return Ok(products);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> Search(int categoryId)
        {
           var products = await _service.GetByCategory(categoryId);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetById(id);
            if (product == null) return NotFound();

            return Ok(product);
        }
    }
}

//Test Change4