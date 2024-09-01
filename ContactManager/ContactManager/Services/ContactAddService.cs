using ContactManager.Models;
using ContactManager.Repositories;
using ContactManager.Services;
using Microsoft.Extensions.Logging;

namespace ContactManager.Commands
{
    public class ContactAddService : ContactService, IContactAddService
    {
        public ContactAddService(IContactManagerRepositoryContactAdd repository)
        {
            ContactManagerRepository = repository;
        }

        private IContactManagerRepositoryContactAdd ContactManagerRepository {  get; set; }

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

                logger.Log(LogLevel.Debug, "Successfully added contact {ContactId}", contactId);

                return result;
            }
            catch(RecordAlreadyExistsException)
            {
                logger.Log(LogLevel.Error, "Contact already exists");
                return new ContactAddResult(ContactServiceResultType.ContactAlreadyExists);
            }
            catch (RepositoryException)
            {
                logger.Log(LogLevel.Error, "Unexpected database error while deleting contact");
            }
            catch (Exception)
            {
                logger.Log(LogLevel.Error, "Unexpected error while deleting contact");
            }

            return new ContactAddResult(ContactServiceResultType.UnknownError);
        }
    }
}
