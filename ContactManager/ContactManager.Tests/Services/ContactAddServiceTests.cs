using ContactManager.Commands;
using ContactManager.Models;
using ContactManager.Repositories;
using Microsoft.Extensions.Logging;

namespace ContactManager.Tests.Services
{
    [TestClass]
    public class ContactAddServiceTests
    {
        [TestMethod]
        public async Task ContactAddServiceReturnsErrorWhenFirstNameIsInvalid()
        {
            var model = new ContactAdd()
            {
                FirstName = "123"
            };

            var logger = NSubstitute.Substitute.For<ILogger>();
            var repository = NSubstitute.Substitute.For<IContactManangerRepositoryContactAdd>();

            var fixture = new ContactAddService(repository);
            var result = await fixture.ExecuteAsync(model, logger).ConfigureAwait(false);

            Assert.AreEqual(result.StatusCode, ContactServiceResultType.FirstNameIsInvalid);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        public async Task ContactAddServiceReturnsErrorWhenFirstNameIsMissing(string firstName)
        {
            var model = new ContactAdd()
            {
                FirstName = firstName
            };

            var logger = NSubstitute.Substitute.For<ILogger>();
            var repository = NSubstitute.Substitute.For<IContactManangerRepositoryContactAdd>();

            var fixture = new ContactAddService(repository);
            var result = await fixture.ExecuteAsync(model, logger).ConfigureAwait(false);

            Assert.AreEqual(result.StatusCode, ContactServiceResultType.FirstNameIsRequired);
        }
    }
}
