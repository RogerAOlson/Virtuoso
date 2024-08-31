using Microsoft.Extensions.Logging;

namespace ContactManager.Repository.ContactManager
{
    public interface IContactManangerRepositoryContactSelect
    {
        public Task<ContactSelectRepositoryResult> ContactSelectAsync(int contactId, ILogger logger);
    }
}