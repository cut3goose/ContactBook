using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Documents;
using AutoMapper;
using ContactBook.Contact.Persistence;
using ContactBook.Contracts.Contact;
using DomainContact = ContactBook.Contact.Domain.Models.Contact;
using EntityContact = ContactBook.Contact.Persistence.Entities.Contact;

namespace ContactBook.Contact.Domain
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        
        public ContactService()
        {
            _contactRepository = new ContactRepository();
            
            var config = new MapperConfiguration(cfg => 
                cfg.AddMaps(Assembly.GetExecutingAssembly()));
            _mapper = new Mapper(config);
        }
        
        public Task? AddContact(ContactCreateModel contact)
        {
            if (string.IsNullOrWhiteSpace(contact.Name) || string.IsNullOrWhiteSpace(contact.PhoneNumber)) return null;

            var mappedEntityContact = _mapper.Map<EntityContact>(contact);
            return _contactRepository.AddContact(mappedEntityContact);
        }

        public async Task<DomainContact> GetContact(int contactId)
        {
            var entityContact = await _contactRepository.GetContact(contactId);
            var mappedContact = _mapper.Map<DomainContact>(entityContact);
            
            return mappedContact;
        }

        public async Task<IEnumerable<DomainContact>> GetSearchResult(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
            {
                return await GetAllContacts();
            }

            var foundByName = await GetContactsByName(searchString);
            var foundByNumber = await GetContactsByPhoneNumber(searchString);
                
            var result = new List<DomainContact>();
            result.AddRange(foundByName);
            result.AddRange(foundByNumber);

            return result;
        }

        public async Task<IEnumerable<DomainContact>> GetContactsByName(string name)
        {
            var entityContacts = await _contactRepository.GetContactsByName(name);
            var mappedContacts = _mapper.Map<IEnumerable<DomainContact>>(entityContacts);

            return mappedContacts;
        }

        public async Task<IEnumerable<DomainContact>> GetContactsByPhoneNumber(string phoneNumber)
        {
            var entityContacts = await _contactRepository.GetContactsByPhoneNumber(phoneNumber);
            var mappedContacts = _mapper.Map<IEnumerable<DomainContact>>(entityContacts);

            return mappedContacts;
        }

        public async Task<IEnumerable<DomainContact>> GetAllContacts()
        {
            var entityContacts = await _contactRepository.GetAllContacts();
            var mappedContacts = _mapper.Map<IEnumerable<DomainContact>>(entityContacts);

            return mappedContacts;
        }
    }
}