using ContactManager.Models;
using ContactManager.Repository.ContactManager;
using ContactManager.Repository.Exceptions;
using ContactManager.Services;
using Microsoft.Extensions.Logging;

namespace ContactManager.Commands
{
    public class ContactDeleteService : ContactService, IContactDeleteService
    {
        public ContactDeleteService(IContactManangerRepositoryContactDelete repository)
        {
            ContactManagerRepository = repository;
        }

        private IContactManangerRepositoryContactDelete ContactManagerRepository {  get; set; }

        public async Task<ContactDeleteResult> ExecuteAsync(int contactId, ILogger logger)
        {
            try
            {
                await ContactManagerRepository.ContactDeleteAsync(contactId, logger);
                var result = new ContactDeleteResult
                {
                    Id = contactId,
                };

                return result;
            }
            catch(RecordNotFoundException ex)
            {
                return new ContactDeleteResult(ContactServiceResultType.ContactNotFound);
            }
            catch(RepositoryExceptions ex)
            {
                logger.Log(LogLevel.Error, "Unexpected database error while deleting contact");
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, "Unexpected database error while deleting contact");
            }

            return new ContactDeleteResult(ContactServiceResultType.UnknownError);
        }
    }
}
