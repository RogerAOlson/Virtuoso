using ContactManager.Models;
using ContactManager.Repositories;
using ContactManager.Services;
using Microsoft.Extensions.Logging;

namespace ContactManager.Commands
{
    public class ContactSelectService : ContactService, IContactSelectService
    {
        public ContactSelectService(IContactManangerRepositoryContactSelect repository)
        {
            ContactManagerRepository = repository;
        }

        private IContactManangerRepositoryContactSelect ContactManagerRepository {  get; set; }

        public async Task<ContactSelectResult> ExecuteAsync(int contactId, ILogger logger)
        {
            try
            {
                var model = await ContactManagerRepository.ContactSelectAsync(contactId, logger).ConfigureAwait(false);
                if(model == null)
                {
                    logger.Log(LogLevel.Debug, "Contact {ContactId} does not exist", contactId);
                    return new ContactSelectResult(ContactServiceResultType.ContactNotFound);
                }

                logger.Log(LogLevel.Debug, "Successfully selected contact {ContactId}", contactId);

                var result = new ContactSelectResult
                {
                    Record = new ContactSelectResult.ContactSelectResultRecord
                    {
                        Id = model.Id,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber
                    },
                };
                return result;
            }
            catch (RepositoryException)
            {
                logger.Log(LogLevel.Error, "Unexpected database error while deleting contact {ContactId}", contactId);
            }
            catch (Exception)
            {
                logger.Log(LogLevel.Error, "Unexpected error while deleting contact {ContactId}", contactId);
            }

            return new ContactSelectResult(ContactServiceResultType.UnknownError);
        }
    }
}
