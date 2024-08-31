using ContactManager.Models;
using Repository.Models;
using Microsoft.Extensions.Logging;
using ContactManager.Repositories;

namespace ContactManagerRepository
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
