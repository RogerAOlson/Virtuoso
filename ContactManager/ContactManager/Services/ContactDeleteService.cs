using ContactManager.Models;
using ContactManager.Repositories;
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
                await ContactManagerRepository.ContactDeleteAsync(contactId, logger).ConfigureAwait(false);

                logger.Log(LogLevel.Debug, "Successfully deleted {ContactId}", contactId);

                return new ContactDeleteResult();
            }
            catch(RecordNotFoundException)
            {
                logger.Log(LogLevel.Error, "Unable to locate contact {ContactId}", contactId);
                return new ContactDeleteResult(ContactServiceResultType.ContactNotFound);
            }
            catch(RepositoryExceptions)
            {
                logger.Log(LogLevel.Error, "Unexpected database error while deleting contact {ContactId}", contactId);
            }
            catch (Exception)
            {
                logger.Log(LogLevel.Error, "Unexpected error while deleting contact {ContactId}", contactId);
            }

            return new ContactDeleteResult(ContactServiceResultType.UnknownError);
        }
    }
}
