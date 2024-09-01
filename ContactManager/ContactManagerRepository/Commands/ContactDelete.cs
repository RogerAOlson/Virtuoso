using ContactManager.Models;
using ContactManager.Repositories;
using Microsoft.Extensions.Logging;

namespace ContactManagerRepositoryDict
{
    public partial class Repository : IContactManangerRepositoryContactDelete
    {
        public Task ContactDeleteAsync(int contactId, ILogger logger)
        {
            lock(Table)
            {
                if (!Table.ContainsKey(contactId))
                {
                    logger.Log(LogLevel.Error, $"Contact Id {contactId} not found");
                    throw new RecordNotFoundException();
                }

                Table.Remove(contactId);
            }

            return Task.CompletedTask;
        }
    }
}
