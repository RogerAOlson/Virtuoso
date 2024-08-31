using ContactManager.Models;

namespace ContactManager.Services
{
    public class ContactResult<T>
    {
        public ContactResult(ContactServiceResultType statusCode)
        {
            StatusCode = statusCode;
        }

        public ContactServiceResultType StatusCode { get; set; }

        public string ErrorMessage { get; set; }

        public T Record { get; set; }
    }

    public class ContactSelectResult : ContactResult<ContactSelectResult.ContactSelectResultRecord>
    {
        public ContactSelectResult(ContactServiceResultType statusCode = ContactServiceResultType.Success)
            : base(statusCode)
        { }

        public class ContactSelectResultRecord
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
        }
    }
}