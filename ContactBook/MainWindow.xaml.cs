using System.Windows;
using ContactBook.Contact.Domain;

namespace ContactBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IContactService _contactService;
        
        public MainWindow()
        {
            InitializeComponent();
            _contactService = new ContactService();

            AddContactButton.Click += AddContactButtonOnClick;
            ContactsButton.Click += ContactsButtonOnClick;
            
            WindowContent.Content = new ContactsListPage(_contactService);
        }

        private void AddContactButtonOnClick(object s, RoutedEventArgs e)
        {
            WindowContent.Content = new AddContactPage(_contactService);
        }

        private void ContactsButtonOnClick(object s, RoutedEventArgs e)
        {
            WindowContent.Content = new ContactsListPage(_contactService);
        }
    }
}