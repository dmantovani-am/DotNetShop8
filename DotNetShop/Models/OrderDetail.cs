namespace DotNetShop.Models;

public record OrderDetail
{
    public int Id { get; set; }
    
    public Order Order { get; set; }

    required public Product Product { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }
}
