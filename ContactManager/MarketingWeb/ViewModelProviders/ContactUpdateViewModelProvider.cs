using ContactManager.Models;
using ContactManager.Services;
using MarketingWeb.ViewModels;

namespace MarketingWeb.ViewModelProviders
{
    public class ContactUpdateViewModelProvider : ContactViewModelProvider, IContactUpdateViewModelProvider
    {
        public ContactUpdateViewModelProvider(IContactUpdateService contactUpdateService)
        {
            ContactUpdateService = contactUpdateService;
        }

        private IContactUpdateService ContactUpdateService { get; }

        public async Task<IResult> ExecuteAsync(
            ContactUpdateViewModel UpdateContactViewModel,
            ILogger logger)
        {
            var model = new ContactUpdate
            {
                Id = UpdateContactViewModel?.Id ?? 0,
                FirstName = UpdateContactViewModel?.FirstName,
                LastName = UpdateContactViewModel?.LastName,
                Email = UpdateContactViewModel?.Email,
                PhoneNumber = UpdateContactViewModel?.PhoneNumber,
            };

            var result = await ContactUpdateService.ExecuteAsync(model, logger);
            return ToActionResult(result);
        }
    }
}
