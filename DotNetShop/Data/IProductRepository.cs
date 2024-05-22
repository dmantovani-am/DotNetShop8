namespace DotNetShop.Data;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetTopProducts(int n = 6);

    Task<IEnumerable<Product>> GetAll();

    Task<Product?> Get(int id);
}