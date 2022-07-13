using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ContactBook.Contact.Persistence
{
    public class ContactRepository : IContactRepository
    {
        private ContactDbContext _dbContext;
        
        public ContactRepository()
        {
            _dbContext = new ContactDbContext();
        }
        
        public async Task AddContact(Entities.Contact contact)
        {
            await _dbContext.Contacts.AddAsync(contact);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Entities.Contact> GetContact(int contactId)
        {
            var foundContact = await _dbContext.Contacts.FirstOrDefaultAsync(c => c.Id == contactId);
            return foundContact;
        }

        public async Task<IEnumerable<Entities.Contact>> GetAllContacts()
        {
            var contactsAmount = await _dbContext.Contacts.CountAsync() - 1;
            var contacts = await _dbContext.Contacts.Take(contactsAmount).ToListAsync();
            
            return contacts;
        }
    }
}