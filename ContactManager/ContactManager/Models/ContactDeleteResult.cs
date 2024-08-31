namespace ContactManager.Models
{
    public class ContactDeleteResult
    {
        public ContactDeleteResult(ContactServiceResultType type = ContactServiceResultType.Success)
        {
            ResultType = type;
        }

        public ContactServiceResultType ResultType { get; set; }

        public int Id { get; set; }
    }
}