using ContactManager.Models;
using MarketingWeb.ViewModelProviders;
using MarketingWeb.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MarketingWeb.Tests.ViewModelProviders
{
    [TestClass]
    public class ContactViewModelProviderTests
    {
        [TestMethod]
        public void ConvertToActionResultReturns200ForSuccess()
        {
            var input = new ContactSelectResult(ContactServiceResultType.Success);

            var fixture = new ContactViewModelProvider();

            var result = fixture.ToActionResult(input);

            Assert.IsInstanceOfType(result, typeof(Ok));
        }

        [DataTestMethod]
        [DataRow(ContactServiceResultType.UnknownError)]
        [DataRow(ContactServiceResultType.IdIsInvalid)]
        [DataRow(ContactServiceResultType.IdIsRequired)]
        [DataRow(ContactServiceResultType.FirstNameIsInvalid)]
        [DataRow(ContactServiceResultType.FirstNameIsRequired)]
        [DataRow(ContactServiceResultType.LastNameIsInvalid)]
        [DataRow(ContactServiceResultType.LastNameIsRequired)]
        [DataRow(ContactServiceResultType.EmailIsInvalid)]
        [DataRow(ContactServiceResultType.EmailIsRequired)]
        [DataRow(ContactServiceResultType.PhoneNumberIsInvalid)]
        [DataRow(ContactServiceResultType.PhoneNumberIsRequired)]
        public void ConvertToActionResultReturns400ForFailure(ContactServiceResultType errorCode)
        {
            var input = new ContactSelectResult(errorCode);

            var fixture = new ContactViewModelProvider();

            var result = fixture.ToActionResult(input);

            Assert.IsInstanceOfType(result, typeof(BadRequest<ErrorViewModel>));
        }

        [TestMethod]
        public void ConvertToActionResultReturns407Conflict()
        {
            var input = new ContactSelectResult(ContactServiceResultType.ContactAlreadyExists);

            var fixture = new ContactViewModelProvider();

            var result = fixture.ToActionResult(input);

            Assert.IsInstanceOfType(result, typeof(Conflict<ErrorViewModel>));
        }

        [TestMethod]
        public void ConvertToActionResultReturns404ForNotFound()
        {
            var input = new ContactSelectResult(ContactServiceResultType.ContactNotFound);

            var fixture = new ContactViewModelProvider();

            var result = fixture.ToActionResult(input);

            Assert.IsInstanceOfType(result, typeof(NotFound<ErrorViewModel>));
        }
    }
}
