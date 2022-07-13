namespace ContactBook.Contracts.Contact
{
    public class ContactCreateModel
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? CompanyName { get; set; }
        public string? PhoneNumber { get; set; }
    }
}