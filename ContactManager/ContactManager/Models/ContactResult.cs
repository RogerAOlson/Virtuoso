namespace ContactManager.Models
{
    public class ContactResult
    {
        public ContactResult(ContactServiceResultType statusCode)
        {
            StatusCode = statusCode;
        }

        public ContactServiceResultType StatusCode { get; set; }

        public string? ErrorMessage { get; set; }
    }
}