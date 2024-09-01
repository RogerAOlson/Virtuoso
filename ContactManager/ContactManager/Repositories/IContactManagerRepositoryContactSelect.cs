using Microsoft.Extensions.Logging;

namespace ContactManager.Repositories
{
    public interface IContactManagerRepositoryContactSelect
    {
        public Task<IContactManagerRepositoryContactSelectResult?> ContactSelectAsync(int contactId, ILogger logger);
    }
}