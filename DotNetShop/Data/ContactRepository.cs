namespace DotNetShop.Data;

public class ContactRepository : IContactRepository
{
    readonly DataContext _context;

    public ContactRepository(DataContext context)
    {
        _context = context;
    }

    public async Task AddContact(Contact contact)
    {
        await _context.Contacts.AddAsync(contact);
        await _context.SaveChangesAsync();
    }
}
