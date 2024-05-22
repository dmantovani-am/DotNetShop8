using Microsoft.EntityFrameworkCore;

namespace DotNetShop.Data;

public class ProductRepository(DataContext context) : IProductRepository
{
    readonly DataContext _context = context;

    public async Task<IEnumerable<Product>> GetTopProducts(int n = 6)
    {
        return await _context.Products
                .Take(n)
                .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> Get(int id)
    {
        return await _context.Products.FindAsync(id);
    }
}
