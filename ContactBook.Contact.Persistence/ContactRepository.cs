using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EntityContact = ContactBook.Contact.Persistence.Entities.Contact;

namespace ContactBook.Contact.Persistence
{
    public class ContactRepository : IContactRepository
    {
        private ContactDbContext _dbContext;
        
        public ContactRepository()
        {
            _dbContext = new ContactDbContext();
        }
        
        public async Task AddContact(EntityContact contact)
        {
            await _dbContext.Contacts.AddAsync(contact);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<EntityContact> GetContact(int contactId)
        {
            var foundContact = await _dbContext.Contacts.FirstOrDefaultAsync(c => c.Id == contactId);
            return foundContact;
        }

        public async Task<IEnumerable<EntityContact>> GetContactsByName(string name)
        {
            var foundContacts = await _dbContext.Contacts
                .Where(c => c.Name.Contains(name) || c.Surname.Contains(name)).ToListAsync();

            return foundContacts;
        }

        public async Task<IEnumerable<EntityContact>> GetContactsByPhoneNumber(string phoneNumber)
        {
            var foundContacts = await _dbContext.Contacts
                .Where(c => c.PhoneNumber.Contains(phoneNumber)).ToListAsync();

            return foundContacts;
        }
    }
}