using System.Collections.Generic;
using AutoMapper;
using ContactBook.Contracts.Contact;
using DomainContact = ContactBook.Contact.Domain.Models.Contact;
using EntityContact = ContactBook.Contact.Persistence.Entities.Contact;

namespace ContactBook.Contact.Domain.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ContactCreateModel, EntityContact>();
            CreateMap<EntityContact, DomainContact>();
            CreateMap<IEnumerable<EntityContact>, List<DomainContact>>();
        }
    }
}