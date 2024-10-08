﻿using ContactManager.Models;
using ContactManager.Repositories;
using ContactManager.Services;
using Microsoft.Extensions.Logging;

namespace ContactManager.Commands
{
    public class ContactUpdateService : ContactService, IContactUpdateService
    {
        public ContactUpdateService(IContactManagerRepositoryContactUpdate repository)
        {
            ContactManagerRepository = repository;
        }

        private IContactManagerRepositoryContactUpdate ContactManagerRepository {  get; set; }

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

                logger.Log(LogLevel.Debug, "Successfully updated contact {ContactId}", model.Id);

                return result;
            }
            catch(RecordNotFoundException)
            {
                logger.Log(LogLevel.Error, "Unable to locate contact {ContactId}", model.Id);
                return new ContactUpdateResult(ContactServiceResultType.ContactNotFound);
            }
            catch(RepositoryException)
            {
                logger.Log(LogLevel.Error, "Unexpected database error while inserting user");
            }
            catch (Exception)
            {
                logger.Log(LogLevel.Error, "Unexpected error while inserting user");
            }

            return new ContactUpdateResult(ContactServiceResultType.UnknownError);
        }
    }
}
