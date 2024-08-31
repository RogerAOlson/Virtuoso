using Microsoft.Extensions.Logging;

namespace ContactManager.Repository.ContactManager
{
    public interface IContactManangerRepositoryContactDelete
    {
        public Task ContactDeleteAsync(int contactId, ILogger logger);
    }
}
