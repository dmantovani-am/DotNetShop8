namespace DotNetShop.Models;

public record Order
{
    public int Id { get; set; }

    public DateTime Created { get; set; }

    required public string FirstName { get; set; }

    required public string LastName { get; set; }

    required public string Email { get; set; }

    required public string Phone { get; set; }

    required public string Address { get; set; }

    public List<OrderDetail> Details { get; set; } = new();
}