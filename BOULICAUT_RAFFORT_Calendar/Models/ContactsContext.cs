using Microsoft.EntityFrameworkCore;

namespace BOULICAUT_RAFFORT_Calendar.Models;

public class ContactsContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }

    public ContactsContext(DbContextOptions<ContactsContext> options)
        : base(options) { }
}