using Microsoft.EntityFrameworkCore;

namespace DotNetShop.Data;

class CartRepository : ICartRepository
{
    readonly DataContext _context;

    required public string CartId { get; set; }

    public CartRepository(DataContext context, IHttpContextAccessor httpContextAccessor)
    {
        var session = httpContextAccessor.HttpContext?.Session ?? throw new NullReferenceException("Missing Session");

        var key = "CartId";
        string cartId = CartId = session?.GetString(key) ?? Guid.NewGuid().ToString();
        session?.SetString(key, cartId);

        _context = context;
    }

    public async Task Add(Product product)
    {
        var item = await GetCartItem(product);
        if (item == null)
        {
            item = new()
            {
                CartId = CartId,
                Product = product,
                Quantity = 1
            };

            _context.CartItems.Add(item);
        }
        else
        {
            item.Quantity++;
        }

        await _context.SaveChangesAsync();
    }

    public async Task<int> Remove(Product product)
    {
        var item = await GetCartItem(product);
        if (item == null) return 0;

        item.Quantity--;
        var quantity = item.Quantity;

        if (item.Quantity <= 0) _context.CartItems.Remove(item);
        
        await _context.SaveChangesAsync();

        return quantity;
    }

    public async Task Clear()
    {
        var items = await _context.CartItems.Where(c => c.CartId == CartId).ToListAsync();
        _context.CartItems.RemoveRange(items);
        await _context.SaveChangesAsync();
    }

    public async Task<IList<CartItem>> GetItems()
    {
        return await _context.CartItems.Where(c => c.CartId == CartId).Include(p => p.Product).ToListAsync();
    }

    public async Task<decimal> GetTotal()
    {
        var rowTotals = await _context.CartItems
            .Where(c => c.CartId == CartId).Include(p => p.Product)
            .Select(c => c.Product.Price * c.Quantity)
            .ToListAsync();
        
        return rowTotals.Sum();
    }

    Task<CartItem?> GetCartItem(Product product)
    {
        ArgumentNullException.ThrowIfNull(product);

        return _context.CartItems.FirstOrDefaultAsync(p => p.CartId == CartId && p.Product.Id == product.Id);
    }
}
