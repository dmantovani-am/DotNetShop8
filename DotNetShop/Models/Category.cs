namespace DotNetShop.Models;

public record Category : IHasId
{
    public Category()
    {
        Products = new List<Product>();
    }

    public int Id { get; set; }

    required public string Name { get; set; }

    public ICollection<Product> Products { get; set; }
}