using ContactManager.Repository.ContactManager;
using Microsoft.Extensions.Logging;

namespace ContactManagerRepository.Repository.ContactManager
{
    public partial class Repository : IContactManangerRepositoryContactSelect
    {
        public Task<ContactSelectRepositoryResult> ContactSelectAsync(int contactId, ILogger logger)
        {
            if (!Table.ContainsKey(contactId))
            {
                logger.Log(LogLevel.Error, $"Contact Id {contactId} not found");
                return Task.FromResult<ContactSelectRepositoryResult>(null);
            }

            var tuple = Table[contactId];

            var result = new ContactSelectRepositoryResult
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