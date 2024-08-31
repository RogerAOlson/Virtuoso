using ContactManager.Models;
using ContactManager.Services;
using MarketingWeb.ViewModelProviders;
using MarketingWeb.ViewModels;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace MarketingWeb.Tests.ViewModelProviders
{
    [TestClass]
    public class ContactAddViewModelProviderTests
    {
        [TestMethod]
        public async Task ContactAddViewModelProviderCallsContactAddServiceExecuteAsync()
        {
            var success = new ContactAddResult();
            var addService = Substitute.For<IContactAddService>();
            addService.ExecuteAsync(Arg.Any<ContactAdd>(), Arg.Any<ILogger>()).Returns(success);
            var logger = Substitute.For<ILogger>();

            var fixture = new ContactAddViewModelProvider(addService);
            await fixture.ExecuteAsync(null, logger).ConfigureAwait(false);

            await addService.Received().ExecuteAsync(Arg.Any<ContactAdd>(), Arg.Is(logger)).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task ContactAddViewModelProviderTranscribesViewModelToDomainModelAsync()
        {
            var viewmodel = new ContactAddViewModel
            {
                FirstName = "firstname",
                LastName = "lastname",
                Email = "a@b.c",
                PhoneNumber = "123"
            };
            var success = new ContactAddResult();

            var addService = Substitute.For<IContactAddService>();
            addService.ExecuteAsync(Arg.Any<ContactAdd>(), Arg.Any<ILogger>()).Returns(success);
            var logger = Substitute.For<ILogger>();

            var fixture = new ContactAddViewModelProvider(addService);
            await fixture.ExecuteAsync(viewmodel, logger).ConfigureAwait(false);

            await addService.Received().ExecuteAsync(Arg.Is<ContactAdd>(dom => DomainModelMatchesViewModel(viewmodel, dom)), Arg.Is(logger)).ConfigureAwait(false);
        }

        public bool DomainModelMatchesViewModel(ContactAddViewModel vm, ContactAdd dom)
        {
            return
                string.Equals(vm.FirstName, dom.FirstName) &&
                string.Equals(vm.LastName, dom.LastName) &&
                string.Equals(vm.Email, dom.Email) &&
                string.Equals(vm.PhoneNumber, dom.PhoneNumber);
        }
    }
}