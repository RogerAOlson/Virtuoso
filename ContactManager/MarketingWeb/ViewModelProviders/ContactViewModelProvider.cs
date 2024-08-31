using ContactManager.Models;

namespace MarketingWeb.ViewModelProviders
{
    public class ContactViewModelProvider
    {
        public IResult ConvertToActionResult(ContactSelectResult result)
        {
            if (result.StatusCode == ContactServiceResultType.Success)
                return Results.Ok(result.Record);

            return ConvertToActionResultCommon(result);
        }

        public IResult ConvertToActionResult(ContactAddResult result)
        {
            if (result.StatusCode == ContactServiceResultType.Success)
                return Results.Ok(new { result.Id });

            return ConvertToActionResultCommon(result);
        }

        public IResult ConvertToActionResult(ContactUpdateResult result)
        {
            return ConvertToActionResultCommon(result);
        }

        public IResult ConvertToActionResult(ContactDeleteResult result)
        {
            return ConvertToActionResultCommon(result);
        }

        public IResult ConvertToActionResultCommon<T>(T result) where T : ContactResult
        {
            return result.StatusCode switch
            {
                ContactServiceResultType.Success => Results.Ok(),
                ContactServiceResultType.UnknownError => Results.Problem("Unexpected error"),

                ContactServiceResultType.IdIsRequired => MyBadRequest("Id is required"),
                ContactServiceResultType.IdIsInvalid => MyBadRequest("Id is invalid"),
                ContactServiceResultType.FirstNameIsRequired => MyBadRequest("First Name is required"),
                ContactServiceResultType.FirstNameIsInvalid => MyBadRequest("First Name is invalid"),
                ContactServiceResultType.LastNameIsRequired => MyBadRequest("Last Name is required"),
                ContactServiceResultType.LastNameIsInvalid => MyBadRequest("Last Name is invalid"),
                ContactServiceResultType.EmailIsRequired => MyBadRequest("Email is required"),
                ContactServiceResultType.EmailIsInvalid => MyBadRequest("Email is invalid"),
                ContactServiceResultType.PhoneNumberIsRequired => MyBadRequest("PhoneNumber is required"),
                ContactServiceResultType.PhoneNumberIsInvalid => MyBadRequest("PhoneNumber is invalid"),

                ContactServiceResultType.ContactNotFound => MyNotFound(result, "Contact not found"),
                ContactServiceResultType.ContactAlreadyExists => MyBadRequest("Contact already exists"),

                _ => throw new NotImplementedException("doh!")
            };
        }

        public IResult MyNotFound<T>(T result, string errorMessage) where T : ContactResult
        {
            result.ErrorMessage = errorMessage;
            return Results.NotFound(result);
        }

        public IResult MyBadRequest(string errorMessage)
        {
            return Results.BadRequest(new { ErrorMessage = errorMessage });
        }
    }
}