﻿using ContactManager.Models;
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
            ContactAddViewModel? ContactAddViewModel,
            ILogger logger)
        {
            var model = new ContactAdd
            {
                FirstName = ContactAddViewModel?.FirstName,
                LastName = ContactAddViewModel?.LastName,
                Email = ContactAddViewModel?.Email,
                PhoneNumber = ContactAddViewModel?.PhoneNumber,
            };

            var result = await ContactAddService.ExecuteAsync(model, logger);
            return ConvertToActionResult(result);
        }
    }
}