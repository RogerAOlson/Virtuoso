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
                    return new ContactSelectResult(ContactServiceResultType.ContactNotFound);
                }

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
            catch(RepositoryExceptions)
            {
                logger.Log(LogLevel.Error, "Unexpected database error while inserting contact");
            }
            catch (Exception)
            {
                logger.Log(LogLevel.Error, "Unexpected database error while getting contact");
            }

            return new ContactSelectResult(ContactServiceResultType.UnknownError);
        }
    }
}
