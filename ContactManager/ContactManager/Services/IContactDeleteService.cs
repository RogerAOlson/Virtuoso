using ContactManager.Commands;
using ContactManager.Models;
using Microsoft.Extensions.Logging;

namespace ContactManager.Services
{
    public interface IContactDeleteService : IServiceAsync
    {
        Task<ContactDeleteResult> ExecuteAsync(int contactId, ILogger logger);
    }
}