using ContactManager.Models;
using Microsoft.Extensions.Logging;

namespace ContactManager.Repository.ContactManager
{
    public interface IContactManangerRepositoryContactUpdate
    {
        public Task ContactUpdateAsync(ContactUpdate model, ILogger logger);
    }
}
