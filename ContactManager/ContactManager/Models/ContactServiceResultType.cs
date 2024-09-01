namespace ContactManager.Models
{
    public enum ContactServiceResultType
    {
        Success = 1,

        UnknownError = 1001,
        ContactAlreadyExists,
        ContactNotFound,

        IdIsRequired = 2001,
        IdIsInvalid,
        FirstNameIsRequired,
        FirstNameIsInvalid,
        LastNameIsRequired,
        LastNameIsInvalid,
        EmailIsRequired,
        EmailIsInvalid,
        PhoneNumberIsRequired,
        PhoneNumberIsInvalid,
    }
}