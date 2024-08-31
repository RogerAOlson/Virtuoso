using ContactManager.Services;

namespace MarketingWeb.ViewModelProviders
{
    public class ContactSelectViewModelProvider : ContactViewModelProvider, IContactSelectViewModelProvider
    {
        public ContactSelectViewModelProvider(IContactSelectService contactSelectService)
        {
            ContactSelectService = contactSelectService;
        }

        private IContactSelectService ContactSelectService { get; }

        public async Task<IResult> ExecuteAsync(
            int contactId,
            ILogger logger)
        {
            var result = await ContactSelectService.ExecuteAsync(contactId, logger);
            return ConvertToActionResult(result);
        }
    }
}
