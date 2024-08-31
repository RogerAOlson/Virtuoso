using Microsoft.Extensions.Logging;

namespace ContactManager.Repositories
{
    public interface IContactManangerRepositoryContactSelect
    {
        public Task<IContactSelectRepositoryResult> ContactSelectAsync(int contactId, ILogger logger);
    }
}