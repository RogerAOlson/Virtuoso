namespace ContactManager.Models
{
    public class ContactAddResult
    {
        public ContactAddResult(ContactServiceResultType type = ContactServiceResultType.Success)
        {
            ResultType = type;
        }

        public ContactServiceResultType ResultType { get; set; }

        public int Id { get; set; }
    }
}