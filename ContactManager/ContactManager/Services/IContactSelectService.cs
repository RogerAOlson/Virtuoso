using ContactManager.Commands;
using Microsoft.Extensions.Logging;

namespace ContactManager.Services
{
    public interface IContactSelectService : IServiceAsync
    {
        Task<ContactSelectResult> ExecuteAsync(int contactId, ILogger logger);
    }
}