using ContactManager.Models;
using ContactManager.Repository.ContactManager;
using ContactManager.Repository.Exceptions;
using ContactManager.Services;
using Microsoft.Extensions.Logging;

namespace ContactManager.Commands
{
    public class ContactAddService : ContactService, IContactAddService
    {
        public ContactAddService(IContactManangerRepositoryContactAdd repository)
        {
            ContactManagerRepository = repository;
        }

        private IContactManangerRepositoryContactAdd ContactManagerRepository {  get; set; }

        public async Task<ContactAddResult> ExecuteAsync(ContactAdd model, ILogger logger)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            try
            {
                if(!FirstNameIsRequired(model.FirstName))
                    return new ContactAddResult(ContactServiceResultType.FirstNameIsRequired);
                if(!FirstNameIsValid(model.FirstName))
                    return new ContactAddResult(ContactServiceResultType.FirstNameIsInvalid);

                if (!LastNameIsRequired(model.LastName))
                    return new ContactAddResult(ContactServiceResultType.LastNameIsRequired);
                if (!LastNameIsValid(model.LastName))
                    return new ContactAddResult(ContactServiceResultType.LastNameIsInvalid);

                if (!EmailIsRequired(model.Email))
                    return new ContactAddResult(ContactServiceResultType.EmailIsRequired);
                if (!EmailIsValid(model.Email))
                    return new ContactAddResult(ContactServiceResultType.EmailIsInvalid);

                if (!PhoneNumberIsRequired(model.PhoneNumber))
                    return new ContactAddResult(ContactServiceResultType.PhoneNumberIsRequired);
                if (!PhoneNumberIsValid(model.PhoneNumber))
                    return new ContactAddResult(ContactServiceResultType.PhoneNumberIsInvalid);

                var contactId = await ContactManagerRepository.ContactAddAsync(model, logger).ConfigureAwait(false);
                var result = new ContactAddResult
                {
                    Id = contactId,
                };

                return result;
            }
            catch(RecordAlreadyExistsException)
            {
                return new ContactAddResult(ContactServiceResultType.ContactAlreadyExists);
            }
            catch(RepositoryExceptions)
            {
                logger.Log(LogLevel.Error, "Unexpected database error while adding contact");
            }
            catch (Exception)
            {
                logger.Log(LogLevel.Error, "Unexpected database error while adding contact");
            }

            return new ContactAddResult(ContactServiceResultType.UnknownError);
        }
    }
}
