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
        
        public ContactsListPage(IContactService contactService)
        {
            InitializeComponent();
            _contactService = contactService;

            DisplayAllContacts();
            ContactSearchField.TextChanged += (sender, args) => { DisplaySearchResults(ContactSearchField.Text);};
        }

        private async void DisplayAllContacts()
        {
            var contacts = await _contactService.GetAllContacts();
            ContactsList.ItemsSource = contacts.ToList();
        }

        private async void DisplaySearchResults(string searchString)
        {
            var searchResult = await _contactService.GetSearchResult(searchString);
            ContactsList.ItemsSource = searchResult.ToList();
        }
    }
}