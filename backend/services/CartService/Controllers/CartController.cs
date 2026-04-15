using Microsoft.AspNetCore.Mvc;
using CartService.Data;
using CartService.Models;

namespace CartService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly AppDbContext _context;

    public CartController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AddToCart(CartItem item)
    {
        _context.CartItems.Add(item);
        _context.SaveChanges();
        return Ok(item);
    }

    [HttpGet("{userId}")]
    public IActionResult GetCart(int userId)
    {
        var items = _context.CartItems
            .Where(x => x.UserId == userId)
            .ToList();

        return Ok(items);
    }

    [HttpDelete("{id}")]
    public IActionResult Remove(int id)
    {
        var item = _context.CartItems.Find(id);
        if (item == null) return NotFound();

        _context.CartItems.Remove(item);
        _context.SaveChanges();

        return Ok();
    }
}