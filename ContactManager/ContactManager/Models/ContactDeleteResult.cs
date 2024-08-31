namespace ContactManager.Models
{
    public class ContactDeleteResult : ContactResult
    {
        public ContactDeleteResult(ContactServiceResultType statusCode = ContactServiceResultType.Success)
            : base(statusCode)
        { }
    }
}