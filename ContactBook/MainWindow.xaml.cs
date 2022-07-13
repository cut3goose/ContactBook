using System;
using System.Linq;
using System.Windows;
using ContactBook.Contact.Domain;
using ContactBook.Contracts.Contact;

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
            Test();
        }

        private async void Test()
        {
            var contact = await _contactService.GetContactsByName("Rod");
            Console.WriteLine(contact.First().Name);
        }
    }
}