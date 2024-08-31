using ContactManager.Commands;
using ContactManager.Models;
using Microsoft.Extensions.Logging;

namespace ContactManager.Services
{
    public interface IContactAddService : IServiceAsync
    {
        Task<ContactAddResult> ExecuteAsync(ContactAdd model, ILogger logger);
    }
}