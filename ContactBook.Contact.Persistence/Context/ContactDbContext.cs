using Microsoft.EntityFrameworkCore;

namespace ContactBook.Contact.Persistence
{
    public class ContactDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Contacts;Integrated Security=True;");
        }

        public DbSet<Entities.Contact> Contacts { get; set; }
    }
}