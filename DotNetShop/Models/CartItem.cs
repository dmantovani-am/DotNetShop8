namespace DotNetShop.Models;

public record CartItem
{
    public int Id { get; set; }

    required public Product Product { get; set; }

    public int Quantity { get; set; }

    required public string CartId { get; set; }
}
