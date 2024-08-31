using ContactManager.Repository.ContactManager;
using ContactManager.Repository.Exceptions;
using Microsoft.Extensions.Logging;

namespace ContactManagerRepository.Repository.ContactManager
{
    public partial class Repository : IContactManangerRepositoryContactDelete
    {
        public Task ContactDeleteAsync(int contactId, ILogger logger)
        {
            if (!Table.ContainsKey(contactId))
            {
                logger.Log(LogLevel.Error, $"Contact Id {contactId} not found");
                throw new RecordNotFoundException();
            }

            Table.Remove(contactId);

            return Task.CompletedTask;
        }
    }
}
