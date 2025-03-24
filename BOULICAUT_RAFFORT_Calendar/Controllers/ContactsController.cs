using BOULICAUT_RAFFORT_Calendar.Models;
using Microsoft.EntityFrameworkCore;

namespace BOULICAUT_RAFFORT_Calendar.Controllers;

public class ContactsController
{
    private readonly ContactsContext _context;

    public ContactsController(ContactsContext context)
    {
        _context = context;
    }
    
    public async Task<List<BOULICAUT_RAFFORT_Calendar.Models.Contact>> GetAllContactsAsync()
    {
        return await _context.Contacts.ToListAsync();
    }
}