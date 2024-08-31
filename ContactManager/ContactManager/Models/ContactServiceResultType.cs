namespace ContactManager.Models
{
    public enum ContactServiceResultType
    {
        Success = 1,

        UnknownError = 1001,
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