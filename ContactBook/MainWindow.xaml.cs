using System;
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
            await _contactService.AddContact(new ContactCreateModel{Name = "Rodion", Surname = "Sergeev", CompanyName = "Crowtouch", 
                PhoneNumber = "+79674617869"})!;

            var contact = await _contactService.GetContact(1);
            Console.WriteLine(contact.Name);
        }
    }
}