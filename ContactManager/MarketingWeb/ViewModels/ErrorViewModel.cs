using ContactManager.Models;

namespace MarketingWeb.ViewModels
{
    public class ErrorViewModel
    {
        public ErrorViewModel(ContactServiceResultType errorCode, string errorMessage)
        {
            ErrorCode = (int)errorCode;
            ErrorMessage = errorMessage;
        }

        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}