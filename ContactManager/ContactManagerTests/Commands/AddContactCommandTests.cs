using ContactManager.Commands;
using ContactManager.Models;
using ContactManager.Repository.ContactManager;
using Microsoft.Extensions.Logging;

namespace ContactManagerTests.Commands
{
    [TestClass]
    public class AddContactCommandTests
    {
        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        public async void AddContactCommandReturnsErrorWhenFirstNameIsMissing(string firstName)
        {
            var model = new ContactAdd()
            {
                FirstName = firstName
            };

            var logger = NSubstitute.Substitute.For<ILogger>();
            var repository = NSubstitute.Substitute.For<IContactManangerRepositoryContactAdd>();

            var fixture = new ContactAddService(repository);
            var result = await fixture.ExecuteAsync(model, logger);

            Assert.AreEqual(result.ResultType, ContactServiceResultType.FirstNameIsRequired);
        }

        [TestMethod]
        public async void AddContactCommandReturnsErrorWhenFirstNameIsInvalid()
        {
            var model = new ContactAdd()
            {
                FirstName = "123"
            };

            var logger = NSubstitute.Substitute.For<ILogger>();
            var repository = NSubstitute.Substitute.For<IContactManangerRepositoryContactAdd>();

            var fixture = new ContactAddService(repository);
            var result = await fixture.ExecuteAsync(model, logger);

            Assert.AreEqual(result.ResultType, ContactServiceResultType.FirstNameIsInvalid);
        }
    }
}
