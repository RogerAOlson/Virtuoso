using ContactManager.Models;
using ContactManager.Repository.ContactManager;
using ContactManagerRepository.Models;
using Microsoft.Extensions.Logging;

namespace ContactManagerRepository.Repository.ContactManager
{
    public partial class Repository : IContactManangerRepositoryContactAdd
    {
        public Task<int> ContactAddAsync(ContactAdd model, ILogger logger)
        {
            lock(Table)
            {
                var contactTuple = new ContactTuple()
                {
                    Id = NextId++,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                };

                Table.Add(contactTuple.Id, contactTuple);

                return Task.FromResult<int>(contactTuple.Id);
            }
        }
    }
}
