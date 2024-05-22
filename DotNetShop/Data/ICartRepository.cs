namespace DotNetShop.Data;

public interface ICartRepository
{
    Task Add(Product product);

    Task<int> Remove(Product product);

    Task<IList<CartItem>> GetItems();

    Task Clear();

    Task<decimal> GetTotal();
}
