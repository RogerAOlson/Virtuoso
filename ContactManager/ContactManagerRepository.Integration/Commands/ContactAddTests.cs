using ContactManager.Models;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace ContactManagerRepositoryDict.Integration.Commands
{
    [TestClass]
    public class ContactAddTests
    {
        [TestMethod]
        public async Task ContactAddInsertsRecordsIntoTheContactsTableAsync()
        {
            var model = new ContactAdd
            {
                FirstName = "first",
                LastName = "last",
                Email = "Email",
                PhoneNumber = "1234567890",
            };

            var logger = Substitute.For<ILogger>();

            var fixture = new Repository();

            var id = await fixture.ContactAddAsync(model, logger).ConfigureAwait(false);
            Assert.IsTrue(id > 100);

            var record = await fixture.ContactSelectAsync(id, logger).ConfigureAwait(false);
            Assert.IsNotNull(record);
            Assert.AreEqual(id, record.Id);
            Assert.AreEqual(model.FirstName, record.FirstName);
            Assert.AreEqual(model.LastName, record.LastName);
            Assert.AreEqual(model.Email, record.Email);
            Assert.AreEqual(model.PhoneNumber, record.PhoneNumber);
        }
    }
}
