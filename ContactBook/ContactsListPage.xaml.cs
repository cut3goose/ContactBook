using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using ContactBook.Contact.Domain;
using DomainContact = ContactBook.Contact.Domain.Models.Contact;

namespace ContactBook
{
    public partial class ContactsListPage : Page
    {
        private readonly IContactService _contactService;
        
        public ContactsListPage()
        {
            InitializeComponent();
            _contactService = new ContactService();
            
            DisplayContacts();
        }

        private async void DisplayContacts()
        {
            var contacts = await _contactService.GetAllContacts();
            ContactsList.ItemsSource = contacts.ToList();
        }
    }
}