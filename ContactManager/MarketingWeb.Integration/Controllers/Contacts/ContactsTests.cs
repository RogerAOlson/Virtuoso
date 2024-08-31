using ContactManager.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Text;
using static ContactManager.Models.ContactSelectResult;

namespace MarketingWeb.Integration.Controllers.Contacts
{
    [TestClass]
    public class ContactsTests
    {
        [TestMethod]
        public async Task GetContact()
        {
            var id = 100;

            var webApplicationFactory = new WebApplicationFactory<Program>();
            var httpClient = webApplicationFactory.CreateDefaultClient();
            var response = await httpClient.GetAsync($"/v1/contact/{id}").ConfigureAwait(false);

            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var contactSelectResultRecord = JsonConvert.DeserializeObject<ContactSelectResult.ContactSelectResultRecord>(json);

            Assert.IsNotNull(contactSelectResultRecord);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

            Assert.IsTrue(ContactManagerRepository.Repository.Table.ContainsKey(id));
            var tuple = ContactManagerRepository.Repository.Table[id];
            Assert.AreEqual(contactSelectResultRecord.FirstName, tuple.FirstName);
            Assert.AreEqual(contactSelectResultRecord.LastName, tuple.LastName);
            Assert.AreEqual(contactSelectResultRecord.Email, tuple.Email);
            Assert.AreEqual(contactSelectResultRecord.PhoneNumber, tuple.PhoneNumber);
        }

        [TestMethod]
        public async Task GetNonExistantContactReturnsNotFoundAsync()
        {
            var webApplicationFactory = new WebApplicationFactory<Program>();
            var httpClient = webApplicationFactory.CreateDefaultClient();
            var response = await httpClient.GetAsync("/v1/contact/-1").ConfigureAwait(false);

            Assert.AreEqual(System.Net.HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public async Task CreateContact()
        {
            var model = new ContactAdd
            {
                FirstName = "first",
                LastName = "last",
                Email = "a@b.c",
                PhoneNumber = "1234567890"
            };  
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var webApplicationFactory = new WebApplicationFactory<Program>();
            var httpClient = webApplicationFactory.CreateDefaultClient();

            await AddContactTestAsync(model, httpClient).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task CreateThenUpdateContact()
        {
            var model = new ContactAdd
            {
                FirstName = "first",
                LastName = "last",
                Email = "a@b.c",
                PhoneNumber = "1234567890"
            };
            var webApplicationFactory = new WebApplicationFactory<Program>();
            var httpClient = webApplicationFactory.CreateDefaultClient();

            var id = await AddContactTestAsync(model, httpClient).ConfigureAwait(false);

            var update = new ContactUpdate()
            {
                Id = id,
                FirstName = model.FirstName + "X",
                LastName = model.LastName + "X",
                Email = model.Email + "X",
                PhoneNumber = model.PhoneNumber + "X"
            };

            var content = new StringContent(JsonConvert.SerializeObject(update), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync("/v1/contact", content).ConfigureAwait(false);

            Assert.IsTrue(ContactManagerRepository.Repository.Table.ContainsKey(update.Id));
            var tuple = ContactManagerRepository.Repository.Table[update.Id];
            Assert.AreEqual(update.FirstName, tuple.FirstName);
            Assert.AreEqual(update.LastName, tuple.LastName);
            Assert.AreEqual(update.Email, tuple.Email);
            Assert.AreEqual(update.PhoneNumber, tuple.PhoneNumber);
        }
 
        [TestMethod]
        public async Task CreateThenDeleteContact()
        {
            var model = new ContactAdd
            {
                FirstName = "first",
                LastName = "last",
                Email = "a@b.c",
                PhoneNumber = "1234567890"
            };
            var webApplicationFactory = new WebApplicationFactory<Program>();
            var httpClient = webApplicationFactory.CreateDefaultClient();

            var id = await AddContactTestAsync(model, httpClient).ConfigureAwait(false);

            var response = await httpClient.DeleteAsync($"/v1/contact/{id}").ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
            Assert.IsFalse(ContactManagerRepository.Repository.Table.ContainsKey(id));
        }

        public async Task<int> AddContactTestAsync(ContactAdd model, HttpClient httpClient)
        {
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("/v1/contact", content).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var contactAddResult = JsonConvert.DeserializeObject<ContactAddResult>(json);

            Assert.IsNotNull(contactAddResult);
            var id = contactAddResult.Id;

            Assert.IsTrue(ContactManagerRepository.Repository.Table.ContainsKey(id));
            var tuple = ContactManagerRepository.Repository.Table[id];
            Assert.AreEqual(model.FirstName, tuple.FirstName);
            Assert.AreEqual(model.LastName, tuple.LastName);
            Assert.AreEqual(model.Email, tuple.Email);
            Assert.AreEqual(model.PhoneNumber, tuple.PhoneNumber);

            return id;
        }
    }
}
