using ContactManager.Models;
using ContactManagerRepositoryDict.Models;
using Microsoft.Extensions.Logging;
using ContactManager.Repositories;

namespace ContactManagerRepositoryDict
{
    public partial class Repository : IContactManagerRepositoryContactAdd
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
