using ContactManager.Models;
using Microsoft.Extensions.Logging;

namespace ContactManager.Repositories
{
    public interface IContactManangerRepositoryContactUpdate
    {
        public Task ContactUpdateAsync(ContactUpdate model, ILogger logger);
    }
}
