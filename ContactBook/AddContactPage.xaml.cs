using System.Windows.Controls;
using ContactBook.Contact.Domain;

namespace ContactBook
{
    public partial class AddContactPage : Page
    {
        private readonly IContactService _contactService;

        public AddContactPage(IContactService contactService)
        {
            InitializeComponent();
            _contactService = contactService;
        }
    }
}