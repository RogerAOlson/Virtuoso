using ContactManager.Commands;
using ContactManager.Models;
using Microsoft.Extensions.Logging;

namespace ContactManager.Services
{
    public interface IContactUpdateService : IServiceAsync
    {
        Task<ContactUpdateResult> ExecuteAsync(ContactUpdate model, ILogger logger);
    }
}