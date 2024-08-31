namespace ContactManager.Models
{
    public class ContactUpdateResult : ContactResult
    {
        public ContactUpdateResult(ContactServiceResultType statusCode = ContactServiceResultType.Success)
            : base(statusCode)
        { }

        public int Id { get; set; }
    }
}