using ContactManager.Models;
using ContactManagerRepositoryDict.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace ContactManagerRepositoryDB.Integration.Commands
{
    [TestClass]
    public class ContactAddTests
    {
        public ContactManagerConfiguration CreateContactManagerConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var appsettings = builder.Build();

            var configuration = new ContactManagerConfiguration();
            configuration.ConnectionString = appsettings["ContactManagerRepositoryDB:ConnectionString"];
            return configuration;
        }


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
            var configuration = CreateContactManagerConfiguration();

            var fixture = new Repository(configuration);

            var id = await fixture.ContactAddAsync(model, logger).ConfigureAwait(false);
            Assert.IsTrue(id > 0);

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
