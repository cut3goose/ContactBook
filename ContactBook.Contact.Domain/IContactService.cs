using System.Collections.Generic;
using System.Threading.Tasks;
using ContactBook.Contracts.Contact;
using DomainContact = ContactBook.Contact.Domain.Models.Contact;

namespace ContactBook.Contact.Domain
{
    public interface IContactService
    {
        Task? AddContact(ContactCreateModel contact);
        Task<DomainContact> GetContact(int contactId);
        Task<IEnumerable<DomainContact>> GetSearchResult(string searchString);
        Task<IEnumerable<DomainContact>> GetContactsByName(string name);
        Task<IEnumerable<DomainContact>> GetContactsByPhoneNumber(string phoneNumber);
        Task<IEnumerable<DomainContact>> GetAllContacts();
    }
}