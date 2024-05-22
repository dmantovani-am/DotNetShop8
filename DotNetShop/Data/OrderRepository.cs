using Microsoft.EntityFrameworkCore;

namespace DotNetShop.Data;

public class OrderRepository : IOrderRepository
{
    readonly DataContext _context;
    readonly ICartRepository _cartRepository;

    public OrderRepository(DataContext context, ICartRepository cartRepository)
    {
        _context = context;
        _cartRepository = cartRepository;

    }

    public async Task Add(Order order)
    {
        var items = await _cartRepository.GetItems();
        order.Details = items.Select(i => new OrderDetail
        {
            Product = i.Product,
            Quantity = i.Quantity,
            Price = i.Product.Price,
        }).ToList();

        order.Created = DateTime.UtcNow;

        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();

        await _cartRepository.Clear();
    }

    public async Task<List<Order>> GetAll()
    {
        return await _context.Orders.ToListAsync();
    }
}
