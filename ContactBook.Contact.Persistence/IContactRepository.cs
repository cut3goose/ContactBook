using System.Collections.Generic;
using System.Threading.Tasks;
using EntityContact = ContactBook.Contact.Persistence.Entities.Contact;

namespace ContactBook.Contact.Persistence
{
    public interface IContactRepository
    {
        Task AddContact(EntityContact contact);
        Task<EntityContact> GetContact(int contactId);
        Task<IEnumerable<EntityContact>> GetAllContacts();
    }
}