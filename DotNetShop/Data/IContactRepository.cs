namespace DotNetShop.Data;

public interface IContactRepository
{
    Task AddContact(Contact contact);
}
