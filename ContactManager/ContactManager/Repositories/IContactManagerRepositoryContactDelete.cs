using Microsoft.Extensions.Logging;

namespace ContactManager.Repositories
{
    public interface IContactManagerRepositoryContactDelete
    {
        public Task ContactDeleteAsync(int contactId, ILogger logger);
    }
}
