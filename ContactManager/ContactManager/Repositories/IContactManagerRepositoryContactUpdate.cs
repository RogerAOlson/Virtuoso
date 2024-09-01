using ContactManager.Models;
using Microsoft.Extensions.Logging;

namespace ContactManager.Repositories
{
    public interface IContactManagerRepositoryContactUpdate
    {
        public Task ContactUpdateAsync(ContactUpdate model, ILogger logger);
    }
}
