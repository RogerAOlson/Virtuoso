namespace ContactManager.Models
{
    public class ContactAddResult : ContactResult
    {
        public ContactAddResult(ContactServiceResultType statusCode = ContactServiceResultType.Success)
            : base(statusCode)
        { }

        public int? Id { get; set; }
    }
}