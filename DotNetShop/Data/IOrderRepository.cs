namespace DotNetShop.Data;

public interface IOrderRepository
{
    Task Add(Order order);

    Task<List<Order>> GetAll();
}
