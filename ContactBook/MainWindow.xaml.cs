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
        }
    }
}