using ContactManager.Models;
using Microsoft.Extensions.Logging;

namespace ContactManager.Repositories
{
    public interface IContactManangerRepositoryContactAdd
    {
        public Task<int> ContactAddAsync(ContactAdd model, ILogger logger);
    }
}
