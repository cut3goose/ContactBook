using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
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

        public Task<IEnumerable<DomainContact>> GetAllContacts()
        {
            throw new System.NotImplementedException();
        }
    }
}