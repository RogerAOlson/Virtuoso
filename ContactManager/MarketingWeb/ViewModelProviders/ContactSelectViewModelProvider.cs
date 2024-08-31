using ContactManager.Models;
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
            logger.LogDebug("Select contact {ContactId}", contactId);

            var result = await ContactSelectService.ExecuteAsync(contactId, logger).ConfigureAwait(false);
            return ToActionResult(result);
        }

        public IResult ToActionResult(ContactSelectResult result)
        {
            if (result.StatusCode == ContactServiceResultType.Success)
                return Results.Ok(result.Record);

            return base.ToActionResult(result);
        }
    }
}
