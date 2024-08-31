namespace ContactManager.Models
{
    public enum ContactServiceResultType
    {
        Success,
        UnknownError,

        IdIsRequired,
        IdIsInvalid,
        FirstNameIsRequired,
        FirstNameIsInvalid,
        LastNameIsRequired,
        LastNameIsInvalid,
        EmailIsRequired,
        EmailIsInvalid,
        PhoneNumberIsRequired,
        PhoneNumberIsInvalid,

        ContactAlreadyExists,
        ContactNotFound,
    }
}