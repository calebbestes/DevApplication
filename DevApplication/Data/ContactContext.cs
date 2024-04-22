using DevApplication.Data;
using Microsoft.EntityFrameworkCore;

namespace DevApplication.Models;

public class ContactContext:DbContext
{
    
    public ContactContext(DbContextOptions<ContactContext> options) : base(options)
    {
    }
    
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Category> Categories { get; set; }

}