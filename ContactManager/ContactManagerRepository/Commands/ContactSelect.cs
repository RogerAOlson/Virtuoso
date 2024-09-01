using ContactManager.Repositories;
using ContactManagerRepositoryDict.Models;
using Microsoft.Extensions.Logging;

namespace ContactManagerRepositoryDict
{
    public partial class Repository : IContactManagerRepositoryContactSelect
    {
        public Task<IContactManagerRepositoryContactSelectResult?> ContactSelectAsync(int contactId, ILogger logger)
        {
            lock(Table)
            {
                if (!Table.ContainsKey(contactId))
                {
                    logger.Log(LogLevel.Error, $"Contact Id {contactId} not found");
                    return Task.FromResult<IContactManagerRepositoryContactSelectResult?>(null);
                }

                var tuple = Table[contactId];

                var result = (IContactManagerRepositoryContactSelectResult)new ContactManagerRepositoryContactSelectResult
                {
                    Id = tuple.Id,
                    FirstName = tuple.FirstName,
                    LastName = tuple.LastName,
                    Email = tuple.Email,
                    PhoneNumber = tuple.PhoneNumber,
                };

                return Task.FromResult<IContactManagerRepositoryContactSelectResult?>(result);
            }
        }
    }
}