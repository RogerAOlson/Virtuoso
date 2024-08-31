using ContactManager.Models;
using ContactManager.Services;
using MarketingWeb.ViewModels;

namespace MarketingWeb.ViewModelProviders
{
    public class ContactAddViewModelProvider : ContactViewModelProvider, IContactAddViewModelProvider
    {
        public ContactAddViewModelProvider(IContactAddService ContactAddService)
        {
            this.ContactAddService = ContactAddService;
        }

        private IContactAddService ContactAddService { get; }

        public async Task<IResult> ExecuteAsync(
            ContactAddViewModel? contactAddViewModel,
            ILogger logger)
        {
            logger.LogDebug("Adding contact {FirstName} {LastName}", contactAddViewModel?.FirstName, contactAddViewModel?.LastName);

            var model = new ContactAdd
            {
                FirstName = contactAddViewModel?.FirstName,
                LastName = contactAddViewModel?.LastName,
                Email = contactAddViewModel?.Email,
                PhoneNumber = contactAddViewModel?.PhoneNumber,
            };

            var result = await ContactAddService.ExecuteAsync(model, logger).ConfigureAwait(false);
            return ToActionResult(result);
        }

        public IResult ToActionResult(ContactAddResult result)
        {
            if (result.StatusCode == ContactServiceResultType.Success)
                return Results.Ok(new { result.Id });

            return base.ToActionResult(result);
        }
    }
}