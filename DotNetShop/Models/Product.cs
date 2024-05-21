namespace DotNetShop.Models;

public record Product : IHasId
{
    public Product()
    {
        Categories = new List<Category>();
    }

    public int Id { get; set; }

    required public string Title { get; set; }

    public decimal Price { get; set; }

    public decimal DiscountedPrice { get; set; }

    required public string Description { get; set; }

    required public string Image { get; set; }

    public ICollection<Category> Categories { get; set; }
}