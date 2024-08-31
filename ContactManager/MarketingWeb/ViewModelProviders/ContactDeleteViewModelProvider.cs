using ContactManager.Services;

namespace MarketingWeb.ViewModelProviders
{
    public class ContactDeleteViewModelProvider : ContactViewModelProvider, IContactDeleteViewModelProvider
    {
        public ContactDeleteViewModelProvider(IContactDeleteService contactDeleteService)
        {
            ContactDeleteService = contactDeleteService;
        }

        private IContactDeleteService ContactDeleteService { get; }

        public async Task<IResult> ExecuteAsync(
            int contactId,
            ILogger logger)
        {
            var result = await ContactDeleteService.ExecuteAsync(contactId, logger);
            return ConvertToActionResult(result);
        }
    }
}
