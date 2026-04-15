namespace CartService.Models;

public class CartItem
{
    public int Id { get; set; }
    public int UserId { get; set; }   // from login
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}