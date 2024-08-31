using Microsoft.Extensions.Logging;

namespace ContactManager.Repositories
{
    public interface IContactManangerRepositoryContactDelete
    {
        public Task ContactDeleteAsync(int contactId, ILogger logger);
    }
}
