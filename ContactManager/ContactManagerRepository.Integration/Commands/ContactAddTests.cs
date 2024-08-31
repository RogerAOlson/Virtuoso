﻿using ContactManager.Models;

namespace ContactManagerRepository.Integration.Commands
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

            var fixture = new Repository();

            var id = await fixture.ContactAddAsync(model, null).ConfigureAwait(false);
            Assert.IsTrue(id > 100);

            var record = await fixture.ContactSelectAsync(id, null).ConfigureAwait(false);
            Assert.IsNotNull(record);
            Assert.AreEqual(id, record.Id);
            Assert.AreEqual(model.FirstName, record.FirstName);
            Assert.AreEqual(model.LastName, record.LastName);
            Assert.AreEqual(model.Email, record.Email);
            Assert.AreEqual(model.PhoneNumber, record.PhoneNumber);
        }
    }
}
