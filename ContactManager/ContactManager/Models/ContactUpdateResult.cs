namespace ContactManager.Models
{
    public class ContactUpdateResult
    {
        public ContactUpdateResult(ContactServiceResultType type = ContactServiceResultType.Success)
        {
            ResultType = type;
        }

        public ContactServiceResultType ResultType { get; set; }

        public int Id { get; set; }
    }
}