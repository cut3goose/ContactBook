using System.Windows;
using System.Windows.Controls;
using ContactBook.Contact.Domain;
using ContactBook.Contracts.Contact;

namespace ContactBook
{
    public partial class AddContactPage : Page
    {
        private readonly IContactService _contactService;

        public AddContactPage(IContactService contactService)
        {
            InitializeComponent();
            _contactService = contactService;

            SaveContactButton.Click += SaveContactButtonOnClick;
        }

        private void SaveContactButtonOnClick(object s, RoutedEventArgs e)
        {
            var contactCreateModel = new ContactCreateModel
            {
                Name = Name.Text,
                Surname = Surname.Text,
                CompanyName = CompanyName.Text,
                PhoneNumber = PhoneNumber.Text
            };

            _contactService.AddContact(contactCreateModel);
            ClearFields();
        }

        private void ClearFields()
        {
            Name.Text = "";
            Surname.Text = "";
            CompanyName.Text = "";
            PhoneNumber.Text = "";
        }
    }
}