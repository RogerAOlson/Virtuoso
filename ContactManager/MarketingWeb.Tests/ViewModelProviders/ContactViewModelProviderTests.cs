using ContactManager.Models;
using MarketingWeb.ViewModelProviders;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MarketingWeb.Tests.ViewModelProviders
{
    [TestClass]
    public class ContactViewModelProviderTests
    {
        [TestMethod]
        public void ConvertToActionResultReturns200ForSuccess()
        {
            var input = new ContactSelectResult(ContactServiceResultType.Success)
            {
                Record = new ContactSelectResult.ContactSelectResultRecord()
                {
                    Id = 12345
                }
            };

            var fixture = new ContactViewModelProvider();

            var result = fixture.ConvertToActionResult(input) as Ok<ContactSelectResult.ContactSelectResultRecord>;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(12345, result.Value?.Id);
        }

        [TestMethod]
        public void ConvertToActionResultReturns404ForContactNotFound()
        {
            var input = new ContactSelectResult(ContactServiceResultType.ContactNotFound);

            var fixture = new ContactViewModelProvider();

            var result = fixture.ConvertToActionResult(input) as NotFound<ContactSelectResult>;

            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);
        }
    }
}
