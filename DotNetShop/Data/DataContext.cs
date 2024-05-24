namespace DotNetShop.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
    : base(options)
    { }

    public DbSet<Product> Products => Set<Product>();

    public DbSet<Category> Categories => Set<Category>();

    public DbSet<CartItem> CartItems => Set<CartItem>();

    public DbSet<Order> Orders => Set<Order>();

    public DbSet<Contact> Contacts => Set<Contact>();
}