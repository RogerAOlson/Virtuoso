namespace ContactManager.Models
{
    public class ContactSelectResult : ContactResult
    {
        public ContactSelectResult(ContactServiceResultType statusCode = ContactServiceResultType.Success)
            : base(statusCode)
        { }

        public ContactSelectResultRecord Record { get; set; }

        public class ContactSelectResultRecord
        {
            public int Id { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? Email { get; set; }
            public string? PhoneNumber { get; set; }
        }
    }
}