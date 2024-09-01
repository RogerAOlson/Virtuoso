using ContactManager.Repositories;
using ContactManagerRepositoryDict.Models;
using Microsoft.Extensions.Logging;

namespace ContactManagerRepositoryDict
{
    public partial class Repository : IContactManangerRepositoryContactSelect
    {
        public Task<IContactSelectRepositoryResult> ContactSelectAsync(int contactId, ILogger logger)
        {
            lock(Table)
            {
                if (!Table.ContainsKey(contactId))
                {
                    logger.Log(LogLevel.Error, $"Contact Id {contactId} not found");
                    return Task.FromResult<IContactSelectRepositoryResult>(null);
                }

                var tuple = Table[contactId];

                var result = (IContactSelectRepositoryResult)new ContactSelectRepositoryResult
                {
                    Id = tuple.Id,
                    FirstName = tuple.FirstName,
                    LastName = tuple.LastName,
                    Email = tuple.Email,
                    PhoneNumber = tuple.PhoneNumber,
                };

                return Task.FromResult(result);
            }
        }
    }
}