using ContactManager.Models;
using ContactManager.Repository.ContactManager;
using ContactManager.Repository.Exceptions;
using Microsoft.Extensions.Logging;

namespace ContactManagerRepository.Repository.ContactManager
{
    public partial class Repository : IContactManangerRepositoryContactUpdate
    {
        public Task ContactUpdateAsync(ContactUpdate model, ILogger logger)
        {
            if (!Table.ContainsKey(model.Id))
            {
                logger.Log(LogLevel.Error, $"Contact Id {model.Id} not found");
                throw new RecordNotFoundException();
            }

            Table[model.Id].FirstName = model.FirstName;
            Table[model.Id].LastName = model.LastName;
            Table[model.Id].Email = model.Email;
            Table[model.Id].PhoneNumber = model.PhoneNumber;

            return Task.CompletedTask;
        }
    }
}
