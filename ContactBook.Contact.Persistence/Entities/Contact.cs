namespace ContactBook.Contact.Persistence.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? CompanyName { get; set; }
        public string? PhoneNumber { get; set; }
    }
}