using ContactManager.Models;
using ContactManager.Repository.ContactManager;
using ContactManager.Repository.Exceptions;
using ContactManager.Services;
using Microsoft.Extensions.Logging;

namespace ContactManager.Commands
{
    public class ContactUpdateService : ContactService, IContactUpdateService
    {
        public ContactUpdateService(IContactManangerRepositoryContactUpdate repository)
        {
            ContactManagerRepository = repository;
        }

        private IContactManangerRepositoryContactUpdate ContactManagerRepository {  get; set; }

        public async Task<ContactUpdateResult> ExecuteAsync(ContactUpdate model, ILogger logger)
        {
            try
            {
                if (!IdIsRequired(model.Id))
                    return new ContactUpdateResult(ContactServiceResultType.IdIsRequired);
                if (!IdIsValid(model.Id))
                    return new ContactUpdateResult(ContactServiceResultType.IdIsInvalid);

                if (!FirstNameIsRequired(model.FirstName))
                    return new ContactUpdateResult(ContactServiceResultType.FirstNameIsRequired);
                if (!FirstNameIsValid(model.FirstName))
                    return new ContactUpdateResult(ContactServiceResultType.FirstNameIsInvalid);

                if (!LastNameIsRequired(model.LastName))
                    return new ContactUpdateResult(ContactServiceResultType.LastNameIsRequired);
                if (!LastNameIsValid(model.LastName))
                    return new ContactUpdateResult(ContactServiceResultType.LastNameIsInvalid);

                if (!EmailIsRequired(model.Email))
                    return new ContactUpdateResult(ContactServiceResultType.EmailIsRequired);
                if (!EmailIsValid(model.Email))
                    return new ContactUpdateResult(ContactServiceResultType.EmailIsInvalid);

                if (!PhoneNumberIsRequired(model.PhoneNumber))
                    return new ContactUpdateResult(ContactServiceResultType.PhoneNumberIsRequired);
                if (!PhoneNumberIsValid(model.PhoneNumber))
                    return new ContactUpdateResult(ContactServiceResultType.PhoneNumberIsInvalid);

                await ContactManagerRepository.ContactUpdateAsync(model, logger).ConfigureAwait(false);
                var result = new ContactUpdateResult
                {
                    Id = model.Id,
                };

                return result;
            }
            catch(RecordNotFoundException)
            {
                return new ContactUpdateResult(ContactServiceResultType.ContactNotFound);
            }
            catch(RepositoryExceptions)
            {
                logger.Log(LogLevel.Error, "Unexpected database error while inserting user");
            }
            catch (Exception)
            {
                logger.Log(LogLevel.Error, "Unexpected database error while inserting user");
            }

            return new ContactUpdateResult(ContactServiceResultType.UnknownError);
        }
    }
}
